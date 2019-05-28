using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ActivityCenter.Models;

namespace ActivityCenter.Controllers
{
    public class ActivityCenterController : Controller
    {
        private ActivityCenterContext context;
        
        public ActivityCenterController(ActivityCenterContext ac)
        {
            context = ac;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                var dbUser = context.UserList.FirstOrDefault(u => u.Email  == newUser.Email);
                if(dbUser != null)
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> PWHasher = new PasswordHasher<User>();
                    newUser.Password = PWHasher.HashPassword(newUser, newUser.Password);
                    context.UserList.Add(newUser);
                    context.SaveChanges();
                    HttpContext.Session.SetInt32("UserId", newUser.UserId);
                    return Redirect("home");
                }
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser User)
        {
            if(ModelState.IsValid)
            {
                var user = context.UserList.FirstOrDefault(u => u.Email == User.LoginEmail);
                if(user == null)
                {
                    ModelState.AddModelError("LoginEmail", "This Email doesn't exist, please Register");
                    return View("Index");
                }
                else
                {
                    var hasher = new PasswordHasher<LoginUser>();
                    var result = hasher.VerifyHashedPassword(User, user.Password, User.LoginPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("LoginPassword", "Incorrect Password");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        return Redirect("home");
                    }
                }
            }
            return View("Index");
        }

        [HttpGet("home")]
        public IActionResult Home()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return Redirect("/");
            }
            else
            {
                User User = context.UserList.FirstOrDefault(x => x.UserId == HttpContext.Session.GetInt32("UserId"));
                List<DojoEvent> Activities = context.ActivityList.Include(x => x.Coordinator).Include(y => y.Attendees).ThenInclude(z => z.AUser).ToList();
                ViewBag.Activities = Activities.OrderBy(z => z.ActivityStart);
                ViewBag.User = User;
                return View();
            }
        }

        [HttpGet("{activityId}")]
        public IActionResult Display(int activityId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return Redirect("/");
            }
            else
            {
                User User = context.UserList.FirstOrDefault(x => x.UserId == HttpContext.Session.GetInt32("UserId"));
                DojoEvent dojoEvent = context.ActivityList.Include(x => x.Coordinator).Include(y => y.Attendees).ThenInclude(z => z.AUser).FirstOrDefault(w => w.DojoEventId == activityId);
                ViewBag.DojoEvent = dojoEvent;
                ViewBag.User = User;
                
                List<Participate> userAttending = context.Join.Where(a => a.UserId == User.UserId).Include(d => d.DojoEvent).ToList();
                List<int> attendingIds = new List<int>();
                foreach (Participate d in userAttending)
                {
                    attendingIds.Add(d.DojoEventId);
                }
                ViewBag.UserAttending = attendingIds;
                return View();
            }
        }

        [HttpGet("new")]
        public IActionResult Create()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return Redirect("/");
            }
            else
            {
                User User = context.UserList.FirstOrDefault(x => x.UserId == HttpContext.Session.GetInt32("UserId"));
                ViewBag.User = User;
                return View();
            }
        }

        [HttpPost("generateActivity")]
        public IActionResult GenerateActivity(DojoEvent newEvent)
        {
            if(ModelState.IsValid)
            {
                Participate newJoin = new Participate();
                newEvent.UserID = (int)HttpContext.Session.GetInt32("UserId");
                context.ActivityList.Add(newEvent);
                context.SaveChanges();
                newJoin.DojoEventId = newEvent.DojoEventId;
                newJoin.UserId = newEvent.UserID;
                context.Join.Add(newJoin);
                context.SaveChanges();
                return Redirect($"{newEvent.DojoEventId}");
            }
            else
            {
                return View("Create");
            }
        }

        [HttpGet("delete/{activityId}")]
        public IActionResult Delete(int activityId)
        {
            DojoEvent Event = context.ActivityList.FirstOrDefault(x => x.DojoEventId == activityId);
            context.ActivityList.Remove(Event);
            context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet("join/{eventId}/{userId}")]
        public IActionResult Attend(int eventId, int userId)
        {
            Participate newJoin = new Participate();
            newJoin.UserId = userId;
            newJoin.DojoEventId = eventId;
            context.Join.Add(newJoin);
            context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet("leave/{eventId}/{userId}")]
        public IActionResult Leave(int eventId, int userId)
        {
            Participate Leave = context.Join.FirstOrDefault(l => l.DojoEventId == eventId && l.UserId == userId);
            context.Join.Remove(Leave);
            context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}

