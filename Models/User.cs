using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityCenter.Models
{
    public class User
    {
       [Key]
       public int UserId {get;set;}
       
       [Required]
       [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long!")]
       public string FirstName {get;set;}

       [Required]
       [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long!")]
       public string LastName {get;set;}

       [Required]
       [EmailAddress]
       public string Email {get;set;}

       [Required]
       [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = " Password should be a min length of 8 characters, contain at least 1 number, 1 letter, and a special character.")]
       [DataType(DataType.Password)]
       public string Password {get;set;}

       [NotMapped]
       [Compare("Password")]
       [DataType(DataType.Password)]
       public string Confirm {get;set;}

       public List<DojoEvent> Activities {get;set;}
       public List<Participate> Join {get;set;}

       public DateTime CreatedAt {get;set;} = DateTime.Now;
       public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}