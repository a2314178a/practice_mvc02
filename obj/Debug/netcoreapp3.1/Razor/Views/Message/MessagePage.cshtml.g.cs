#pragma checksum "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b341fd8282353fb128f1a87ea37d4da37c35b97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Message_MessagePage), @"mvc.1.0.view", @"/Views/Message/MessagePage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b341fd8282353fb128f1a87ea37d4da37c35b97", @"/Views/Message/MessagePage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d59638b4ba1e16a34566544d8d088e305c7ad9ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Message_MessagePage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/my_style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/baseJS.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/message.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
  
    ViewData["Title"] = "歡迎";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"zh-TW\">\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b976054", async() => {
                WriteLiteral(@"
		<meta charset=""utf-8"">
		<meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">				    
        <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">      
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3b341fd8282353fb128f1a87ea37d4da37c35b976742", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b978633", async() => {
                WriteLiteral(@"			
        <div class=""container""><!--內容-->
            <div class=""row mx-0 align-items-center justify-content-center w-100"">
                <div class=""col-12"">
                    <div id=""messagePage"">

                        <ul class=""nav nav-tabs justify-content-end"" group=""table"">                         
                            <span style=""width:30px;""></span>
                            <li class=""nav-item"">
                                <a");
                BeginWriteAttribute("class", " class=\'", 1043, "\'", 1095, 2);
                WriteAttributeValue("", 1051, "nav-link", 1051, 8, true);
#nullable restore
#line 24 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
WriteAttributeValue(" ", 1059, @ViewBag.Page=="new"?"active":"", 1060, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" href=\"#\" name=\"newMessage\" onclick=\"showMessagePage(\'new\');\">最新訊息</a>\r\n                            </li>\r\n                            <li class=\"nav-item\">\r\n                                <a");
                BeginWriteAttribute("class", " class=\'", 1288, "\'", 1340, 2);
                WriteAttributeValue("", 1296, "nav-link", 1296, 8, true);
#nullable restore
#line 27 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
WriteAttributeValue(" ", 1304, @ViewBag.Page=="all"?"active":"", 1305, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" href=\"#\" name=\"allMessage\" onclick=\"showMessagePage(\'all\');\">全部訊息</a>\r\n                            </li>\r\n                            <li class=\"nav-item\">\r\n                                <a");
                BeginWriteAttribute("class", " class=\'", 1533, "\'", 1587, 2);
                WriteAttributeValue("", 1541, "nav-link", 1541, 8, true);
#nullable restore
#line 30 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
WriteAttributeValue(" ", 1549, @ViewBag.Page=="write"?"active":"", 1550, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" href=\"#\" name=\"writeMessage\" onclick=\"showMessagePage(\'write\');\">寫訊息</a>\r\n                            </li>\r\n                            <li class=\"nav-item\">\r\n                                <a");
                BeginWriteAttribute("class", " class=\'", 1783, "\'", 1838, 2);
                WriteAttributeValue("", 1791, "nav-link", 1791, 8, true);
#nullable restore
#line 33 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
WriteAttributeValue(" ", 1799, @ViewBag.Page=="backup"?"active":"", 1800, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" href=\"#\" name=\"backMessage\" onclick=\"showMessagePage(\'backup\');\">寄件備份</a>\r\n                            </li>\r\n                        </ul>\r\n                        <div>\r\n\r\n");
#nullable restore
#line 38 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                             if(ViewBag.Page == "new" || ViewBag.Page == "all" || ViewBag.Page == "backup")
                            {                                                               

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div");
                BeginWriteAttribute("id", " id=\'", 2249, "\'", 2342, 1);
#nullable restore
#line 40 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
WriteAttributeValue("", 2254, ViewBag.Page=="all"? "allMsgDiv": ViewBag.Page=="backup"? "backupMsgDiv" :"newMsgDiv", 2254, 88, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                <table class=""table table-hover table-bordered message_table"">
                                    <thead class=""thead-dark"" >
                                        <tr>
                                            <th scope=""col"" style=""width:15%"">時間</th>
                                            <th scope=""col"" style=""width:35%"">標題</th>
");
#nullable restore
#line 46 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                                             if(ViewBag.Page != "backup"){

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <th scope=\"col\" style=\"width:35%\">寄件人</th>\r\n");
#nullable restore
#line 48 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                                            }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <th scope=\"col\" style=\"width:35%\">收件人</th>\r\n");
#nullable restore
#line 50 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                                            }  

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                            <th scope=""col"" style=""width:15%"">管理動作</th>         
                                        </tr>
                                    </thead> 
                                    <tbody id=""messageList"">
                                    </tbody>
                                </table>
                            </div>
");
#nullable restore
#line 58 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                            }
                            else if(ViewBag.Page == "write")
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div id=""writeMsgDiv"">
                                <table class=""table table-hover table-bordered writeMsg_table"">
                                    <tr>
                                        <td class=""msgTitle"">標題</td>
                                        <td><textarea id=""msgTitle""></textarea></td>
                                    </tr>
                                    <tr>
                                        <td class=""msgTitle"">收件人</td>
                                        <td>
                                            <select id=""selReceiveDepart"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b9715555", async() => {
                    WriteLiteral("請選擇");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b9716824", async() => {
                    WriteLiteral("全體");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </select>\r\n                                            <select id=\"selReceiveID\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b9718225", async() => {
                    WriteLiteral("請選擇");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b9719494", async() => {
                    WriteLiteral("全體");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class=""msgTitle"">內容</td>
                                        <td><textarea id=""content""></textarea></td>
                                    </tr>
                                </table>
                                <a href=""javascript:void(0);"" class=""btn btn-primary"" onclick=""sendMsg();"">送出</a>
                                <span style=""margin:20px""></span>
                                <a href=""javascript:void(0);"" class=""btn btn-danger"" onclick=""clearMsg();"">清空</a>
                            </div>
");
#nullable restore
#line 89 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\t\t\r\n        </div>\t\r\n\r\n\r\n\r\n        <div class=\"template\">\r\n            <table>\r\n");
#nullable restore
#line 100 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
             if(ViewBag.Page == "new" || ViewBag.Page == "all" || ViewBag.Page == "backup")
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr name=\"receiveMsgRow\">\r\n                    <td scope=\"col\" name=\"dateTime\" style=\"width:15%\"></td>\r\n                    <td scope=\"col\" name=\"title\" style=\"width:35%\"><a href=\"javascript:void(0);\"></a></td>\r\n");
#nullable restore
#line 105 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                     if(ViewBag.Page != "backup"){

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td scope=\"col\" name=\"sendName\" style=\"width:35%\"></td>\r\n");
#nullable restore
#line 107 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                    }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td scope=\"col\" name=\"receiveName\" style=\"width:35%\"></td>\r\n");
#nullable restore
#line 109 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td scope=\"col\" style=\"width:15%\">\r\n");
#nullable restore
#line 111 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                         if(ViewBag.Page == "new"){

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <a href=\"javascript:void(0);\" class=\"btn btn-danger ignore_message btnActive\" >忽略訊息</a>\r\n");
#nullable restore
#line 113 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                        }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <a href=\"javascript:void(0);\" class=\"btn btn-danger del_message btnActive\" >刪除訊息</a>\r\n");
#nullable restore
#line 115 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td> \r\n                </tr>\r\n                <tr name=\"msgContentRow\"><td scope=\"col\" colspan=\"4\" name=\"content\" data-id=\"\"></td></tr>\r\n");
#nullable restore
#line 119 "C:\work_project\practice_mvc02\Views\Message\MessagePage.cshtml"
                
            }
            else if(ViewBag.Page == "write")
            {
            
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </table>
        </div>





        	
        <script src=""https://code.jquery.com/jquery-3.4.1.slim.min.js"" integrity=""sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n"" crossorigin=""anonymous""></script>
        <script src=""https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"" integrity=""sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo"" crossorigin=""anonymous""></script>
        <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"" integrity=""sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6"" crossorigin=""anonymous""></script>
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b9725395", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\t \r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b341fd8282353fb128f1a87ea37d4da37c35b9726589", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
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