#pragma checksum "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30009fb9bbdbdf692a963671dff89c4aecf3233d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PunchCard_PunchCardLogPage), @"mvc.1.0.view", @"/Views/PunchCard/PunchCardLogPage.cshtml")]
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
#line 1 "C:\work_project\practice_mvc02\Views\_ViewImports.cshtml"
using practice_mvc02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\work_project\practice_mvc02\Views\_ViewImports.cshtml"
using practice_mvc02.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30009fb9bbdbdf692a963671dff89c4aecf3233d", @"/Views/PunchCard/PunchCardLogPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d59638b4ba1e16a34566544d8d088e305c7ad9ae", @"/Views/_ViewImports.cshtml")]
    public class Views_PunchCard_PunchCardLogPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/my_style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/baseJS.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/punchCardLogPage.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
  
    ViewData["Title"] = ViewData["loginName"] + "歡迎回來";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"zh-TW\">\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30009fb9bbdbdf692a963671dff89c4aecf3233d5417", async() => {
                WriteLiteral(@"
		<meta charset=""utf-8"">
		<meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">				    
        <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">      
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "30009fb9bbdbdf692a963671dff89c4aecf3233d6105", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30009fb9bbdbdf692a963671dff89c4aecf3233d7996", async() => {
                WriteLiteral(@"			
        <div class=""container""><!--內容-->
            <div class=""row mx-0 align-items-center justify-content-center w-100"">
                <div class=""col-12"">
                    <div id=""PunchCardLogPage"" style=""text-align:center;"">
                        <div id=""punchLogDiv"">
                            <div><h3>");
#nullable restore
#line 21 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                                Write(ViewBag.punchLogName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" 的打卡紀錄</h3></div>
                            <table class=""table table-hover table-bordered punchLog_table"">
                                <thead class=""thead-dark"" >
                                    <tr>
                                        <th scope=""col"">日期</th>
                                        <th scope=""col"">上班時間</th>
                                        <th scope=""col"">下班時間</th>
                                        <th scope=""col"">狀態</th>
");
#nullable restore
#line 29 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                                         if(ViewBag.canEditPunchLog)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <th scope=\"col\">管理動作</th>\r\n");
#nullable restore
#line 32 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </tr>\r\n                                </thead> \r\n                                <tbody id=\"punchLogList\">\r\n                                </tbody>\r\n                            </table>\r\n");
#nullable restore
#line 38 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                             if(ViewBag.canEditPunchLog)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <a href=\"javascript:void(0);\" class=\"btn btn-primary btnActive add_punchLog\" style=\"float:right\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2141, "\"", 2226, 5);
                WriteAttributeValue("", 2151, "showAddPunchLogRow(", 2151, 19, true);
#nullable restore
#line 40 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
WriteAttributeValue("", 2170, ViewBag.lookEmployeeID, 2170, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2193, ",", 2193, 1, true);
#nullable restore
#line 40 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
WriteAttributeValue(" ", 2194, ViewBag.lookEmployeeDepartID, 2195, 29, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2224, ");", 2224, 2, true);
                EndWriteAttribute();
                WriteLiteral(">新增紀錄</a>\r\n");
#nullable restore
#line 41 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </div> 

                       
                    </div>  
                </div>
            </div>		
        </div>	
        	


        <div class=""template"">
            <table>
                <tr name=""punchLogRow"">
                    <td scope=""col"" name=""logDate""></td>
                    <td scope=""col"" name=""logOnlineTime""></td>
                    <td scope=""col"" name=""logOfflineTime""></td>
                    <td scope=""col"" name=""logPunchStatus""></td>
");
#nullable restore
#line 59 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                     if(ViewBag.canEditPunchLog)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <td scope=""col"" width=""20%"">
                        <a href=""javascript:void(0);"" class=""btn btn-primary edit_punchLog btnActive"" >編輯</a>
                        <a href=""javascript:void(0);"" class=""btn btn-danger del_punchLog btnActive"" >刪除</a>
                    </td>
");
#nullable restore
#line 65 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tr>

                <tr name=""addPunchLogRow"">
                    <td scope=""col"" name=""dateTime"">
                        <input type='date' name=""newDateTime"" style='zoom:75%'>
                    </td>
                    <td scope=""col"" name=""onlineTime"">
                        <input type='time' name=""newOnlineTime"" style='zoom:75%'>
                    </td>
                    <td scope=""col"" name=""offlineTime"">
                        <input type='time' name=""newOfflineTime"" style='zoom:75%'>
                    </td>
                    <td scope=""col"" name=""punchStatus"">
                    </td>
");
#nullable restore
#line 80 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                     if(ViewBag.canEditPunchLog)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <td scope=""col"" width=""20%"">
                        <a href=""javascript:void(0);"" class=""btn btn-primary create_punchLog"" >新增</a>
                        <a href=""javascript:void(0);"" class=""btn btn-primary update_punchLog"" >更新</a>
                        <a href=""javascript:void(0);"" class=""btn btn-danger cancel_punchLog"" >取消</a>
                    </td>
");
#nullable restore
#line 87 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tr>
            </table>
        </div>







        <script src=""https://code.jquery.com/jquery-3.4.1.slim.min.js"" integrity=""sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n"" crossorigin=""anonymous""></script>
        <script src=""https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"" integrity=""sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo"" crossorigin=""anonymous""></script>
        <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"" integrity=""sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6"" crossorigin=""anonymous""></script>
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30009fb9bbdbdf692a963671dff89c4aecf3233d15223", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\t \r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30009fb9bbdbdf692a963671dff89c4aecf3233d16417", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\t \r\n\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onload", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 604, "getAllPunchLogByID(", 604, 19, true);
#nullable restore
#line 15 "C:\work_project\practice_mvc02\Views\PunchCard\PunchCardLogPage.cshtml"
AddHtmlAttributeValue("", 623, ViewBag.lookEmployeeID, 623, 23, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 646, ");", 646, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
