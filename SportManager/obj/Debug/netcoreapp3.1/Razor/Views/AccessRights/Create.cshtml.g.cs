#pragma checksum "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27b0c3f5e9e93e5a000135a088b2baf8b4617e95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AccessRights_Create), @"mvc.1.0.view", @"/Views/AccessRights/Create.cshtml")]
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
#line 2 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
using SportManager.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27b0c3f5e9e93e5a000135a088b2baf8b4617e95", @"/Views/AccessRights/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38928028cc44023d9a025fcd7f4b8ff98ff531c2", @"/Views/_ViewImports.cshtml")]
    public class Views_AccessRights_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SportManager.Models.AccessRight>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control Right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("profileForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary waves-effect waves-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Profile profile = null;
    List<Menu> menus = null;
    string UserType = "";
    string UserProfile="";
    try
    {
        UserProfile = Context.Session.GetString("USERPROFILE");
    }
    catch (Exception ex) { }
    try
    {
        UserType = Context.Session.GetString("USERTYPE");
        if (ViewBag.Profile != null)
        {
            profile = (Profile)ViewBag.Profile;
        }

        if (ViewBag.Menus != null)
        {
            menus = (List<Menu>)ViewBag.Menus;
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
                <div class=""row"">
                    <div class=""col-sm-12"">

                        <div class=""card"">
                            <div class=""card-header"">
                                <h5>Access right</h5>
                            </div>
                            <div class=""card-block"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b0c3f5e9e93e5a000135a088b2baf8b4617e958995", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 69 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                       if (ViewBag.Failed != null)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                            <div class=""alert alert-danger background-danger"">
                                                <button type=""button"" class=""close""
                                                        data-dismiss=""alert"" aria-label=""Close"">
                                                    <i class=""icofont icofont-close-line-circled text-white""></i>
                                                </button>
                                                <strong>Failed!</strong>
                                                <code>
                                                    ");
#nullable restore
#line 78 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                               Write(ViewBag.Failed);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                </code>\r\n                                            </div> ");
#nullable restore
#line 80 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                   }
                                        if (ViewBag.Success != null)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                            <div class=""alert alert-success background-success"">
                                                <button type=""button"" class=""close""
                                                        data-dismiss=""alert"" aria-label=""Close"">
                                                    <i class=""icofont icofont-close-line-circled text-white""></i>
                                                </button>
                                                <strong>Success!</strong>
                                                <code>
                                                    ");
#nullable restore
#line 90 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                               Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                </code>\r\n                                            </div> ");
#nullable restore
#line 92 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                   }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""form-group row"">
                                        <label class=""col-sm-2 col-form-label"">Profile&nbsp;<span style=""color:red;"">*</span></label>
                                        <div class=""col-sm-10"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b0c3f5e9e93e5a000135a088b2baf8b4617e9512632", async() => {
                    WriteLiteral("\r\n");
#nullable restore
#line 98 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                  
                                                    try
                                                    {
                                                        if (profile != null)
                                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b0c3f5e9e93e5a000135a088b2baf8b4617e9513470", async() => {
#nullable restore
#line 103 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                                            Write(profile.Name);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 103 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                               WriteLiteral(profile.Id);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 104 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b0c3f5e9e93e5a000135a088b2baf8b4617e9516294", async() => {
                        WriteLiteral("--select--");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 108 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                        }
                                                    }
                                                    catch (Exception ex) { }
                                                

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 97 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProfileId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 97 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Profiles;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b0c3f5e9e93e5a000135a088b2baf8b4617e9520511", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 113 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProfileId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 116 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                      
                                        if (menus != null)
                                        {
                                            foreach (var item in menus)
                                            {
                                                if (item.MenuType.ToUpper().Trim().Equals("MAINMENU"))
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                    <div class=""container card"" style=""margin-bottom:20px;"">
                                                        <div class=""card-body"">
                                                            <div class=""checkbox-zoom zoom-primary"">
");
#nullable restore
#line 126 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                  
                                                                    if (item.Assigned)
                                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                        <input type=\"checkbox\" class=\"parent_menu\" name=\"menuid\"");
                BeginWriteAttribute("id", " id=\"", 6645, "\"", 6658, 1);
#nullable restore
#line 129 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 6650, item.Id, 6650, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 6659, "\"", 6675, 1);
#nullable restore
#line 129 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 6667, item.Id, 6667, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" checked>\r\n");
#nullable restore
#line 130 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                    }
                                                                    else
                                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                        <input type=\"checkbox\" class=\"parent_menu\" name=\"menuid\"");
                BeginWriteAttribute("id", " id=\"", 7031, "\"", 7044, 1);
#nullable restore
#line 133 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 7036, item.Id, 7036, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 7045, "\"", 7061, 1);
#nullable restore
#line 133 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 7053, item.Id, 7053, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 134 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                    }
                                                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                <label for=\"vehicle1\">");
#nullable restore
#line 136 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                                 Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label><br>\r\n                                                            </div>\r\n                                                            <div class=\"container\">\r\n");
#nullable restore
#line 139 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                  
                                                                    var submenulist = menus.Where(b => b.ParentId == item.Id & b.MenuType.ToUpper().Trim().Equals("SUB-MENU")).ToList();
                                                                    foreach (var submenuitem in submenulist)
                                                                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                        <div class=\"checkbox-zoom zoom-primary\">\r\n");
#nullable restore
#line 145 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                              
                                                                                if (submenuitem.Assigned)
                                                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                                    <input type=\"checkbox\"");
                BeginWriteAttribute("class", " class=\"", 8393, "\"", 8422, 3);
                WriteAttributeValue("", 8401, "sub_menu", 8401, 8, true);
                WriteAttributeValue(" ", 8409, "men", 8410, 4, true);
#nullable restore
#line 148 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue(" ", 8413, item.Id, 8414, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"menuid\"");
                BeginWriteAttribute("id", " id=\"", 8437, "\"", 8450, 1);
#nullable restore
#line 148 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 8442, item.Id, 8442, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 8451, "\"", 8474, 1);
#nullable restore
#line 148 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 8459, submenuitem.Id, 8459, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" checked>\r\n");
#nullable restore
#line 149 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                                }
                                                                                else
                                                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                                    <input type=\"checkbox\"");
                BeginWriteAttribute("class", " class=\"", 8844, "\"", 8873, 3);
                WriteAttributeValue("", 8852, "sub_menu", 8852, 8, true);
                WriteAttributeValue(" ", 8860, "men", 8861, 4, true);
#nullable restore
#line 152 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue(" ", 8864, item.Id, 8865, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"menuid\"");
                BeginWriteAttribute("id", " id=\"", 8888, "\"", 8901, 1);
#nullable restore
#line 152 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 8893, item.Id, 8893, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 8902, "\"", 8925, 1);
#nullable restore
#line 152 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
WriteAttributeValue("", 8910, submenuitem.Id, 8910, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 153 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                                }
                                                                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                            <label for=\"vehicle1\">");
#nullable restore
#line 155 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                                                             Write(submenuitem.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label><br>\r\n                                                                        </div>\r\n");
#nullable restore
#line 157 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"

                                                                    }
                                                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            </div>\r\n                                                        </div>\r\n                                                    </div>\r\n");
#nullable restore
#line 163 "C:\Users\doduor\source\repos\SportManager\SportManager\Views\AccessRights\Create.cshtml"
                                                }
                                            }
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""form-group row"">
                                        <label class=""col-sm-2""></label>
                                        <div class=""col-sm-10"">
                                            <button type=""submit"" class=""btn btn-primary m-b-0"">Submit</button>
                                        </div>
                                    </div>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b0c3f5e9e93e5a000135a088b2baf8b4617e9535171", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SportManager.Models.AccessRight> Html { get; private set; }
    }
}
#pragma warning restore 1591
