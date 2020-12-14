#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fde665b8a88cf3b7245ac347e0e962742d965844"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StoreCategory_Index), @"mvc.1.0.view", @"/Views/StoreCategory/Index.cshtml")]
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
#line 2 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fde665b8a88cf3b7245ac347e0e962742d965844", @"/Views/StoreCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_StoreCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SportManager.Models.StoreItem>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
  
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
                        <h5>");
#nullable restore
#line 46 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                       Write(ViewBag.StoreCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    </div>\r\n                    <div class=\"card-block\">\r\n                        <p>\r\n");
#nullable restore
#line 51 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                              
                                if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary") || UserProfile.Equals("StoreKeeper"))
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                               Write(Html.ActionLink("Create New Item", "Create", "StoreItems", new { id = ViewBag.StoreCategoryId != null ? ViewBag.StoreCategoryId : "" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                                                                                                                                            
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <div class=\"table-responsive dt-responsive\">\r\n");
#nullable restore
#line 60 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
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
#line 69 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                       Write(ViewBag.Failed);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 71 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
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
#line 81 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                       Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </code>\r\n                                    </div> ");
#nullable restore
#line 83 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
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
#line 89 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 92 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </th>
                                        <th>
                                            No. of items in use
                                        </th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 101 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                      
                                        if (Model != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 108 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 111 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 114 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                   Write(item.StoreItemsInUse.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 118 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                          
                                                            if (UserProfile.Equals("Coordinator") || UserProfile.Equals("Secretary") || UserProfile.Equals("StoreKeeper"))
                                                            {
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                           Write(Html.ActionLink("Edit", "Edit", "StoreItems", new { id = item.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                                                                                                Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                           Write(Html.ActionLink("Delete", "Delete", "StoreItems", new { id = item.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                                                                                                    Write(Html.Raw(" | "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                                                                                                                         
                                                            }
                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        ");
#nullable restore
#line 126 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                                   Write(Html.ActionLink("Details", "Details", "StoreItems", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 129 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                             
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                                <tfoot>\r\n                                    <tr>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 136 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            ");
#nullable restore
#line 139 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\StoreCategory\Index.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </th>
                                        <th>
                                            No. of items in use
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SportManager.Models.StoreItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
