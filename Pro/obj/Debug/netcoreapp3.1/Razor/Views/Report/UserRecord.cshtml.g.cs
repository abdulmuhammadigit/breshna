#pragma checksum "D:\ASP.NET CORE\Pro\Pro\Views\Report\UserRecord.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ed206b833c0fb4c426af3b6431cd7ae4ce83c8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_UserRecord), @"mvc.1.0.view", @"/Views/Report/UserRecord.cshtml")]
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
#line 1 "D:\ASP.NET CORE\Pro\Pro\Views\_ViewImports.cshtml"
using Pro;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP.NET CORE\Pro\Pro\Views\_ViewImports.cshtml"
using Pro.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ed206b833c0fb4c426af3b6431cd7ae4ce83c8b", @"/Views/Report/UserRecord.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"988d9c0a9d5e4d89a657ab43e6ded71078865bd4", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_UserRecord : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Pro.ViewModels.Report.UserRecordViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserRecord", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/Parsley.js-2.9.2/dist/parsley.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/Parsley.js-2.9.2/dist/i18n/fa.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ASP.NET CORE\Pro\Pro\Views\Report\UserRecord.cshtml"
  
    ViewData["Title"] = "راپور ریکارد کاربران ";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .table.table-sm td, .table.table-sm th {
        padding: 0.5rem 0.5em;
    }

    .popover {
        right: unset;
        left: unset;
    }
</style>
<div class=""card"">
    <div class=""col-sm-12"">



        <a class=""btn btn-info btn-block"" data-toggle=""collapse"" href=""#collapseExample"" role=""button"" aria-expanded=""false"" aria-controls=""collapseExample"">
            راپور تعداد ریکارد کاربران
        </a>



        <div class=""collapse"" id=""collapseExample"">
            <div class=""card card-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ed206b833c0fb4c426af3b6431cd7ae4ce83c8b5950", async() => {
                WriteLiteral(@"
                    <div class=""col-sm-12 row center-block"">


                            <div class=""form-group col-sm-4"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text"" id=""inputGroup-sizing-sm"">از تاریخ </span>
                                </div>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <span class=""input-group-text  cursor-pointer la la-calendar-times-o"" id=""date5""></span>
                                    </div>
                                    <input type=""text"" id=""inputDate5"" class=""form-control"" placeholder=""تاریخ را انتخاب کنید"" aria-label=""date5""
                                           aria-describedby=""date5""");
                BeginWriteAttribute("required", " required=\"", 1656, "\"", 1667, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""Date1Farsi"">
                                </div>
                            </div>
                            <div class=""form-group col-sm-4"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text"" id=""inputGroup-sizing-sm"">الی تاریخ </span>
                                </div>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <span class=""input-group-text  cursor-pointer la la-calendar-times-o date5"" id=""date6""></span>
                                    </div>
                                    <input type=""text"" id=""inputDate6"" class=""form-control inputDate5"" placeholder=""تاریخ را انتخاب کنید"" aria-label=""date5""
                                           aria-describedby=""date5""");
                BeginWriteAttribute("required", " required=\"", 2582, "\"", 2593, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""Date2Farsi"">
                                </div>
                            </div>
                        


                        <div class=""col-sm-4"">
                            <div class=""form-group col-sm-12 row"" style=""margin-top: 30px;"">
                                <input type=""submit"" class=""btn btn-info btn-block col-sm-9"" value=""جستجو"">
                                <button class=""btn btn btn-info  col-sm-2 ml-1 btn-print"">
                                    <i class=""la la-print"">
                                    </i>
                                </button>
                            </div>

                        </div>

                    </div>


                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n\r\n    <div class=\"col-sm-12\" id=\"tableContent\">\r\n\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ed206b833c0fb4c426af3b6431cd7ae4ce83c8b10608", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ed206b833c0fb4c426af3b6431cd7ae4ce83c8b11648", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    jQuery(function ($) {

        $('#search').parsley().on('field:validated', function () {
            var ok = $('.parsley-error').length === 0;
            $('.bs-callout-info').toggleClass('hidden', !ok);
            $('.bs-callout-warning').toggleClass('hidden', ok);
        })
            .on('form:submit', function () {
                return true; // Don't submit form for this demo
            });

        $('#search').submit(function (e) {
            e.preventDefault();

            var form = $(this);
            var url = form.attr('action');

            var dataToSend = new FormData(form.get(0));
            $.ajax({
                url: url, type: ""post"", data: dataToSend, processData: false, contentType: false, error: function () {

                    ShowSweetErrorAlert();
                },
                beforeSend: function () { ShowLoading(); },
                complete: function () { $(""body"").preloader('remove'); },
            }).done(function (");
            WriteLiteral(@"result) {


                $(""#tableContent"").html(result);



            });

        });

        function ShowSweetErrorAlert() {
            Swal.fire({
                type: 'error',
                title: 'خطایی رخ داده است !!!',
                text: 'لطفا تا برطرف شدن خطا شکیبا باشید.',
                confirmButtonText: 'بستن'
            });
        }

        function ShowLoading() {
            $(""body"").preloader({ text: 'لطفا صبر کنید ...' });
        }

        function ShowSweetSuccessAlert(message) {

            Snackbar.show({
                text: message,
                actionText: 'بستن',
                actionTextColor: '#e2a03f',
                pos: 'top-right'
            });

        }
        function ShowSweetAlert(message) {

            Snackbar.show({
                text: message,
                pos: 'bottom-right'
            });

        }
    });
</script>



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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Pro.ViewModels.Report.UserRecordViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591