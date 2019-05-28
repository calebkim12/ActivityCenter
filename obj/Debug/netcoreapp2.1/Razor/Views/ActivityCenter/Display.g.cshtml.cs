#pragma checksum "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83b93f793306e57a3233df910319c2fe27daefe4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ActivityCenter_Display), @"mvc.1.0.view", @"/Views/ActivityCenter/Display.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ActivityCenter/Display.cshtml", typeof(AspNetCore.Views_ActivityCenter_Display))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/_ViewImports.cshtml"
using ActivityCenter;

#line default
#line hidden
#line 2 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/_ViewImports.cshtml"
using ActivityCenter.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83b93f793306e57a3233df910319c2fe27daefe4", @"/Views/ActivityCenter/Display.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e339c4346f16b3c5483ad512c481a4e17eb8f1c", @"/Views/_ViewImports.cshtml")]
    public class Views_ActivityCenter_Display : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DojoEvent>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(17, 473, true);
            WriteLiteral(@"
<a href=""home"" class=""btn btn-primary"" style=""float:right;"">Home</a>
<a href=""logout"" class=""btn btn-primary"" style=""float:right;"">Logout</a><br>
<br>

<div class=""container"">
    <div class=""jumbotron"" style=""background-image: url(https://suraenlinea.cdn.prismic.io/suraenlinea/92b8af2721625e19b65c45e6ffca69c1ef2213b5_bg-home.jpg); background-size: 100%;"">
            <div class=""container"">
                <h1 style=""color:white"" class=""display-2 text-center"">Event: ");
            EndContext();
            BeginContext(491, 31, false);
#line 10 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
                                                                        Write(ViewBag.DojoEvent.ActivityTitle);

#line default
#line hidden
            EndContext();
            BeginContext(522, 126, true);
            WriteLiteral("!</h1> \n            </div>\n    </div>\n    <div class=\"row\">\n        <div class=\"col-lg-6\">\n            <h2>Event Coordinator: ");
            EndContext();
            BeginContext(649, 39, false);
#line 15 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
                              Write(ViewBag.DojoEvent.Coordinator.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(688, 35, true);
            WriteLiteral("</h2>\n            <h2>Description: ");
            EndContext();
            BeginContext(724, 37, false);
#line 16 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
                        Write(ViewBag.DojoEvent.ActivityDescription);

#line default
#line hidden
            EndContext();
            BeginContext(761, 58, true);
            WriteLiteral("</h2>\n            <h4>Participants:</h4>\n            <ul>\n");
            EndContext();
#line 20 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
                     foreach(var j in ViewBag.DojoEvent.Attendees)
                    {

#line default
#line hidden
            BeginContext(927, 28, true);
            WriteLiteral("                        <li>");
            EndContext();
            BeginContext(956, 17, false);
#line 22 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
                       Write(j.AUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(973, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 23 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
                    }

#line default
#line hidden
            BeginContext(1019, 44, true);
            WriteLiteral("            </ul>\n        </div>\n    </div>\n");
            EndContext();
#line 28 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
          
            if(@ViewBag.UserAttending.Contains(@ViewBag.DojoEvent.DojoEventId) && @ViewBag.User.UserId != @ViewBag.DojoEvent.Coordinator.UserId)
            {

#line default
#line hidden
            BeginContext(1233, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1251, "\"", 1315, 4);
            WriteAttributeValue("", 1258, "leave/", 1258, 6, true);
#line 31 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
WriteAttributeValue("", 1264, ViewBag.DojoEvent.DojoEventId, 1264, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 1294, "/", 1294, 1, true);
#line 31 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
WriteAttributeValue("", 1295, ViewBag.User.UserId, 1295, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1316, 35, true);
            WriteLiteral(" class=\"btn btn-primary\">Leave</a>\n");
            EndContext();
#line 32 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
            }
            else if(@ViewBag.User.UserId != @ViewBag.DojoEvent.Coordinator.UserId)
            {

#line default
#line hidden
            BeginContext(1462, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1480, "\"", 1543, 4);
            WriteAttributeValue("", 1487, "join/", 1487, 5, true);
#line 35 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
WriteAttributeValue("", 1492, ViewBag.DojoEvent.DojoEventId, 1492, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 1522, "/", 1522, 1, true);
#line 35 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
WriteAttributeValue("", 1523, ViewBag.User.UserId, 1523, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1544, 41, true);
            WriteLiteral(" class=\"btn btn-primary\">Join Event!</a>\n");
            EndContext();
#line 36 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
            }
            else if(@ViewBag.User.UserId == @ViewBag.DojoEvent.Coordinator.UserId)
            {

#line default
#line hidden
            BeginContext(1696, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1714, "\"", 1758, 2);
            WriteAttributeValue("", 1721, "delete/", 1721, 7, true);
#line 39 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
WriteAttributeValue("", 1728, ViewBag.DojoEvent.DojoEventId, 1728, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1759, 42, true);
            WriteLiteral(" class=\"btn btn-danger\">Delete Event?</a>\n");
            EndContext();
#line 40 "/Users/CalebKim/Desktop/CSharp_DotNet/ActivityCenter/Views/ActivityCenter/Display.cshtml"
            }
        

#line default
#line hidden
            BeginContext(1825, 7, true);
            WriteLiteral("</div> ");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DojoEvent> Html { get; private set; }
    }
}
#pragma warning restore 1591
