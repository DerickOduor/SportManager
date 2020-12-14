#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "329d6625f1b12e39f54d7f754c4c48f2a50431e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_Index), @"mvc.1.0.view", @"/Views/Event/Index.cshtml")]
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
#line 2 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
using SportManager.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"329d6625f1b12e39f54d7f754c4c48f2a50431e8", @"/Views/Event/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SportManager.Models.Event>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
  
    ViewData["Title"] = "Index";
    List<EventType> eventTypes = null;
    string UserProfile = "";
    try
    {
        UserProfile = Context.Session.GetString("USERPROFILE");
    }
    catch (Exception ex) { }
    try
    {
        if (ViewBag.EventTypes != null)
        {
            eventTypes = (List<EventType>)ViewBag.EventTypes;
        }
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

                <div class=""card"">
                    <div class=""card-header"">
                        <h5>Events</h5>
                    </div>
                    <div class=""card-block"">
                        <p>
");
#nullable restore
#line 60 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                              
                                if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary"))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "329d6625f1b12e39f54d7f754c4c48f2a50431e85622", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n");
#nullable restore
#line 64 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <div class=\"table-responsive dt-responsive\">\r\n");
#nullable restore
#line 69 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                               if (ViewBag.Failed != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""alert alert-danger background-danger"">
                                        <button type=""button"" class=""close""
                                                data-dismiss=""alert"" aria-label=""Close"">
                                            <i class=""icofont icofont-close-line-circled text-white""></i>
                                        </button>
                                        <strong>Failed!</strong>
                                        <code>
                                            ");
#nullable restore
#line 78 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(ViewBag.Failed);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 80 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                           }
                                if (ViewBag.Success != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""alert alert-success background-success"">
                                        <button type=""button"" class=""close""
                                                data-dismiss=""alert"" aria-label=""Close"">
                                            <i class=""icofont icofont-close-line-circled text-white""></i>
                                        </button>
                                        <strong>Success!</strong>
                                        <code>
                                            ");
#nullable restore
#line 90 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 92 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                           }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <table id=""dom-jqry"" class=""table table-striped table-bordered nowrap"">
                                <thead>
                                    <tr>
                                        <th>
                                            ");
#nullable restore
#line 98 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 101 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 104 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 107 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.EventTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th></th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 113 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                      
                                        if (Model != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 120 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 123 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 126 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 130 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                          
                                                            if (eventTypes != null)
                                                            {
                                                                foreach (EventType eventType in eventTypes)
                                                                {
                                                                    if (eventType.Id.Equals(item.EventTypeId))
                                                                    {
                                                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 137 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                   Write(eventType.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 137 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                                       
                                                                    }
                                                                }
                                                            }
                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 144 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                          
                                                            try
                                                            {
                                                                if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary"))
                                                                    if (ViewBag.CanAddEvent != null)
                                                                    {
                                                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                   Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 151 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                   Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 152 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                   Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 153 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                   Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                   Write(Html.ActionLink("Add session", "Create", "EventSession", new { id = item.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                   Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                                                        
                                                                    }
                                                            }
                                                            catch (Exception ex) { }
                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        ");
#nullable restore
#line 161 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                                   Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 164 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 164 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                             
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                                <tfoot>\r\n                                    <tr>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 171 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 174 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 177 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 180 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Event\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.EventTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </th>
                                        <th></th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SportManager.Models.Event>> Html { get; private set; }
    }
}
#pragma warning restore 1591
