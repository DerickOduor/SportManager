#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "577a0ba541ba14853eff17da0dbc6858495e157b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EventSession_Details), @"mvc.1.0.view", @"/Views/EventSession/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\_ViewImports.cshtml"
using SportManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\_ViewImports.cshtml"
using SportManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"577a0ba541ba14853eff17da0dbc6858495e157b", @"/Views/EventSession/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_EventSession_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SportManager.Models.EventSession>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header card\">\r\n    <div class=\"row align-items-end\">\r\n        <div class=\"col-lg-8\">\r\n");
            WriteLiteral(@"        </div>
        <div class=""col-lg-4"">
            <div class=""page-header-breadcrumb"">
                <ul class="" breadcrumb breadcrumb-title"">
                    <li class=""breadcrumb-item"">
                        <a href=""/home""><i class=""feather icon-home""></i></a>
                    </li>
                    <li class=""breadcrumb-item""><a href=""#!"">Dashboard</a> </li>
                </ul>
            </div>
        </div>
    </div>
</div>

<div class=""pcoded-inner-content"">
    <div class=""main-body"">
        <div class=""page-wrapper"">

            <div class=""page-body"">
                <div class=""row"">
                    <div class=""col-sm-12"">

                        <div class=""card"">
                            <div class=""card-header"">
                                <h5>Event Session Details</h5>
                            </div>
                            <div class=""card-block"">
                                <dl class=""row"">
                       ");
            WriteLiteral("             <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 46 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 49 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 52 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Event.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 55 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.Event.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 58 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Venue.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 61 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.Venue.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 64 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 67 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 70 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 73 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </dd>
                                </dl>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <div>
            ");
#nullable restore
#line 86 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
       Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
            WriteLiteral("            ");
#nullable restore
#line 88 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventSession\Details.cshtml"
       Write(Html.ActionLink("Back to List", "Index", new { id = Model.EventId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SportManager.Models.EventSession> Html { get; private set; }
    }
}
#pragma warning restore 1591
