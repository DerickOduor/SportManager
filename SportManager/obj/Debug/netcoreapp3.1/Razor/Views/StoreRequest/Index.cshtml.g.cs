#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c412662c9ec3dc8a2081d3f50dc7a2f12230f324"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StoreRequest_Index), @"mvc.1.0.view", @"/Views/StoreRequest/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c412662c9ec3dc8a2081d3f50dc7a2f12230f324", @"/Views/StoreRequest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_StoreRequest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SportManager.Models.StoreItemInUse>>
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
#line 3 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
  
    ViewData["Title"] = "Index";

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
                        <h5>Store items requested</h5>
                    </div>
                    <div class=""card-block"">
                        <p>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c412662c9ec3dc8a2081d3f50dc7a2f12230f3244754", async() => {
                WriteLiteral("Make new requested");
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
            WriteLiteral("\r\n                        </p>\r\n                        <div class=\"table-responsive dt-responsive\">\r\n");
#nullable restore
#line 46 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
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
#line 55 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(ViewBag.Failed);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 57 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
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
#line 67 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 69 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
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
#line 75 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.StoreItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 78 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.EventId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 81 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 84 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Approved));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 87 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.DateRequested));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th></th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 93 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                      
                                        if (Model != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 100 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.StoreItem.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 103 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Event.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 106 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 109 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                          
                                                            string appr = "";
                                                            if (item.Approved & !item.Rejected)
                                                                appr = "Yes";
                                                            else if (item.Rejected)
                                                                appr = "No";
                                                            else
                                                                appr = "Pending";

                                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 118 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                       Write(appr);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 122 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                          
                                                            item.DateRequested.ToString("dd/MM/yyyy");
                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 127 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                   Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                                        ");
#nullable restore
#line 128 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                   Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                                        ");
#nullable restore
#line 129 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                                   Write(Html.ActionLink("Cancel Request", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 132 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 132 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                             
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                                <tfoot>\r\n                                    <tr>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 139 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.StoreItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 142 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.EventId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 145 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 148 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Approved));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 151 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreRequest\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.DateRequested));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SportManager.Models.StoreItemInUse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
