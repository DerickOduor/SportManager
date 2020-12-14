#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b72b0d7c283ada3cb6fa25cbaf87db409f90cd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_Details), @"mvc.1.0.view", @"/Views/Event/Details.cshtml")]
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
#nullable restore
#line 2 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b72b0d7c283ada3cb6fa25cbaf87db409f90cd6", @"/Views/Event/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SportManager.Models.Event>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Event _event = null;
    string UserProfile = "";
    try
    {
        UserProfile = Context.Session.GetString("USERPROFILE");
    }
    catch (Exception ex) { }
    try
    {
        _event = Model;
    }
    catch (Exception ex) { }

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
                                <h5>Event Details</h5>
                            </div>
                            <div class=""card-block"">
                                <dl class=""row"">
                               ");
            WriteLiteral("     <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 59 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 62 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 65 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 68 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 71 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 74 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 77 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.EventTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 80 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(ViewBag.EventType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 83 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.PostPoned));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 86 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.PostPoned));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n                                    <dt class=\"col-sm-2\">\r\n                                        ");
#nullable restore
#line 89 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayNameFor(model => model.Cancelled));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dt>\r\n                                    <dd class=\"col-sm-10\">\r\n                                        ");
#nullable restore
#line 92 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.DisplayFor(model => model.Cancelled));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </dd>\r\n");
#nullable restore
#line 94 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                      
                                        try
                                        {
                                            bool CanAdd = false;
                                            if (ViewBag.CanAddDiscipline != null)
                                                CanAdd = (bool)ViewBag.CanAddDiscipline;

                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                       Write(Html.ActionLink("View sport disciplines", "Index", "EventDisciplines", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                                                                                                                          
                                            if (CanAdd)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                           Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                                                
                                            }
                                            if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary"))
                                                if (CanAdd)
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 109 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                               Write(Html.ActionLink("Add sport disciplines", "Create", "EventDisciplines", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 109 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                                                                                                                                  
                                                }

                                        }
                                        catch (Exception ex)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                       Write(Html.ActionLink("View sport disciplines", "Index", "EventDisciplines", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                                                                                                                          
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </dl>\r\n                                <div class=\"card\">\r\n                                    <div class=\"card-block\">\r\n");
            WriteLiteral("                                        ");
#nullable restore
#line 122 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                   Write(Html.ActionLink("View sessions", "Index", "EventSession", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div>
");
#nullable restore
#line 134 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
              
                if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary"))
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Details.cshtml"
                                                                       Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b72b0d7c283ada3cb6fa25cbaf87db409f90cd615861", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SportManager.Models.Event> Html { get; private set; }
    }
}
#pragma warning restore 1591
