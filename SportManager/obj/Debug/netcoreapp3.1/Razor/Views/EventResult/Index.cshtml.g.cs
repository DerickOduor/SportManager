#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef6ab13c7f32196a567e32d8eca646cce1e5960a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EventResult_Index), @"mvc.1.0.view", @"/Views/EventResult/Index.cshtml")]
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
#line 2 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
using SportManager.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef6ab13c7f32196a567e32d8eca646cce1e5960a", @"/Views/EventResult/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_EventResult_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SportManager.Models.EventResult>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Report", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary waves-effect waves-light btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
  
    ViewData["Title"] = "Index";
    SportDisciplinesInEvent disciplineInEvent = null;
    string UserProfile = "";
    try
    {
        UserProfile = Context.Session.GetString("USERPROFILE");
    }
    catch (Exception ex) { }
    try
    {
        if (ViewBag.SportDisciplineInEvent != null)
            disciplineInEvent = (SportDisciplinesInEvent)ViewBag.SportDisciplineInEvent;
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
                        <h5>Event results for ");
#nullable restore
#line 53 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                         Write(disciplineInEvent.SportDiscipine.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    </div>\r\n                    <div class=\"card-block\">\r\n                        <p>\r\n");
#nullable restore
#line 57 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                              
                                if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary"))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef6ab13c7f32196a567e32d8eca646cce1e5960a6673", async() => {
                WriteLiteral("Add result");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                             WriteLiteral(disciplineInEvent.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 61 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n");
#nullable restore
#line 65 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                         if (Model != null)
                        {
                            if (Model.Count() > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"container\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef6ab13c7f32196a567e32d8eca646cce1e5960a9616", async() => {
                WriteLiteral("Generate report");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n");
#nullable restore
#line 72 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"table-responsive dt-responsive\">\r\n");
#nullable restore
#line 75 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
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
#line 84 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(ViewBag.Failed);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 86 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
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
#line 96 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 98 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
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
#line 104 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.SportDisciplinesInEvent.Event.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 107 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.NoOfMatches));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 110 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.MatchesWon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 113 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.MatchesDrawn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 116 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.MatchesLost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 119 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.SportDisciplinesInEvent.SportDiscipine.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th></th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 125 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                      
                                        if (Model != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 128 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 132 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.SportDisciplinesInEvent.Event.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 135 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.NoOfMatches));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 138 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.MatchesWon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 141 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.MatchesDrawn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 144 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.MatchesLost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 147 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.SportDisciplinesInEvent.SportDiscipine.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 150 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                          
                                                            try
                                                            {
                                                                if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary"))
                                                                    if (ViewBag.CanAddResult != null)
                                                                    {
                                                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 156 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                                   Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 157 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                                   Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 158 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                                   Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 159 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                                   Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 159 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                                                        
                                                                    }
                                                            }
                                                            catch (Exception ex) { }
                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        ");
#nullable restore
#line 165 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                                   Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 168 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 168 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                             
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                                <tfoot>\r\n                                    <tr>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 175 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.SportDisciplinesInEvent.Event.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 178 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.NoOfMatches));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 181 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.MatchesWon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 184 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.MatchesDrawn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 187 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.MatchesLost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 190 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\EventResult\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.SportDisciplinesInEvent.SportDiscipine.Name));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SportManager.Models.EventResult>> Html { get; private set; }
    }
}
#pragma warning restore 1591
