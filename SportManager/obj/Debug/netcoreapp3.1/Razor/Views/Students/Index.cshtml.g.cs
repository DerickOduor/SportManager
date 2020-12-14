#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd8136483e021d0af6aa9ef1b03e9936881cbe91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Students_Index), @"mvc.1.0.view", @"/Views/Students/Index.cshtml")]
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
#line 3 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd8136483e021d0af6aa9ef1b03e9936881cbe91", @"/Views/Students/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Students_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SportManager.Models.Student>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
  
    ViewData["Title"] = "Index";
    string UserProfile = "";
    try
    {
        UserProfile = Context.Session.GetString("USERPROFILE");
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
                        <h5>Students</h5>
                    </div>
                    <div class=""card-block"">
");
            WriteLiteral("                        <div class=\"table-responsive dt-responsive\">\r\n");
#nullable restore
#line 53 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
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
#line 62 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(ViewBag.Failed);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 64 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
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
#line 74 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 76 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
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
#line 82 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.RegistrationNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 85 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 88 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 91 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 94 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th></th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 100 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                      
                                        if (Model != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 107 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.RegistrationNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 110 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 113 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 116 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 119 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 122 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                                   Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 125 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 125 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                             
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                                <tfoot>\r\n                                    <tr>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 132 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.RegistrationNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 135 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 138 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 141 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 144 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\Students\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Phone));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SportManager.Models.Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591
