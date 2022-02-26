#pragma checksum "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9257a9d46d9dbb532e89aa3f0b9fd137d19fb9f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report__RentTable), @"mvc.1.0.view", @"/Views/Report/_RentTable.cshtml")]
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
#nullable restore
#line 2 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
using Pro.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9257a9d46d9dbb532e89aa3f0b9fd137d19fb9f3", @"/Views/Report/_RentTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"988d9c0a9d5e4d89a657ab43e6ded71078865bd4", @"/Views/_ViewImports.cshtml")]
    public class Views_Report__RentTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Pro.Entities.Rent>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app-assets/js/scripts/tables/datatables-extensions/datatable-button/datatable-html5.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table class=""table table-striped table-bordered dataex-html5-export"">


    <thead>
        <tr>

            <th width=""20px"">#</th>
            <th class=""text-center"">نمبر فارم </th>
            <th class=""text-center"">نمبر جکشن </th>
            <th class=""text-center"">نام</th>
            <th class=""text-center"">تخلص</th>
            <th class=""text-center"">اسم پدر</th>
            <th class=""text-center"">نمبر تذکره</th>
            <th class=""text-center"">شماره تماس</th>
            <th class=""text-center"">حالت مدنی</th>
            <th class=""text-center"">سن</th>
            <th class=""text-center"">جنسیت</th>

            <th class=""text-center"">نوع درآمد</th>
            <th class=""text-center"">مقدار درآمد ماهانه</th>
            <th class=""text-center""> ولایت  آدس ملکیت</th>
            <th class=""text-center""> والسوالی/ناحیه  آدس ملکیت</th>
            <th class=""text-center""> گذر آدس ملکیت</th>
            <th class=""text-center""> نمبر خانه آدس ملکیت</th>
            <th ");
            WriteLiteral(@"class=""text-center""> ولایت</th>
            <th class=""text-center""> والسوالی/ناحیه</th>
            <th class=""text-center"">گذر </th>
            <th class=""text-center"">کشور </th>
            <th class=""text-center"">شماره تماس صاحب ملک </th>
            <th class=""text-center""> آیا شما همراه فامیل در خانه زنده گی میکنید</th>
            <th class=""text-center"">چند سال  </th>
");
            WriteLiteral(@"            <th class=""text-center""> تعداد ساکنین</th>
            <th class=""text-center""> برق شما کدام نوع است</th>
            <th class=""text-center"">شما چند عدد میتر دارید </th>
            <th class=""text-center""> آیا شما جنراتور استفاده می کنید</th>
            <th class=""text-center""> جنراتور به کدام ظرفیت </th>
            <th class=""text-center""> حد اوسط مدت استفاده از جنراتور در طول روز چند ساعت است</th>
            <th class=""text-center""> چه وقت از جنراتور استفاده می کنید </th>
            <th class=""text-center"">هزینه سوخت جنراتور شما در یک ماه تقریبا چند افغانی است  </th>
            <th class=""text-center"">آیا شما کدام منبع انرژی دیگری دارید  </th>
            <th class=""text-center"">اگر جواب بله هست مشخص کنید </th>
            <th class=""text-center"">تعداد اتاق  </th>
            <th class=""text-center"">تعداد منزل </th>
            <th class=""text-center"">تعداد تشناب  </th>
            <th class=""text-center"">تعداد آشپزخانه </th>
            <th class=""text-center"">نوع ملکیت  </");
            WriteLiteral(@"th>
            <th class=""text-center"">اندازه تقریبی تعمیر به متر مربع  </th>
            <th class=""text-center"">اندازه تقریبی زمین به متر مربع  </th>
            <th class=""text-center"">نوعیت کرایی یا گروی </th>
            <th class=""text-center"">شما در تابستان چند ساعت در روز ایرکندیشن استفاده می کنید </th>
            <th class=""text-center""> شما از کدام سیستم گرم کننده استفاده میکنید </th>
            <th class=""text-center""> شما در زمستان چند ساعت در روز بخاری برقی استفاده می کنید </th>
            <th class=""text-center"">  آیا از ملکیت برای مقاصد تجاری استفاده میکنید</th>
            <th class=""text-center""> از ملکیت برای کدام مقاصد تجاری استفاده میکنید </th>
            <th class=""text-center"">  اسم نهاد تجارتی</th>
            <th class=""text-center""> چند سال </th>
            <th class=""text-center""> چند نفر کارمند مصروف کار در این ملکیت هستند </th>
            <th class=""text-center"">  آیا شما برق خود را در وقت معین دریافت می کنید</th>
            <th class=""text-center"">  اگر نخیر، ");
            WriteLiteral(@"چند روز تاخیر دارد</th>
            <th class=""text-center"">  آیا تا حال برای پرداخت بل به صورت قسط وار درخواست نموده اید</th>
            <th class=""text-center""> مبلغ بل برق قبلی تان چند بود به افغانی </th>
            <th class=""text-center"">آیا در وقت تعین شده بل خود را پرداخت نموده اید</th>
            <th class=""text-center"">آیا شما 24 ساعت برق دارید</th>
            <th class=""text-center"">اگر نخیر،در طول روز چند ساعت برق دارید</th>
            <th class=""text-center"">اگرنخیر، آیا می خواهید 24 ساعت برق داشته باشید</th>
            <th class=""text-center"">آیا شما حاضر هستید پول بیشتر برای داشتن برق 24 ساعته بپردازید و از هزینه گزاف جنراتور جلو گیری کنید</th>
            <th class=""text-center"">آیا شما میخواهید بخاطر سیستم سولری در خانه تان جهت داشتن برق 24 ساعته و کاهش بل برق، در برنامه سولر شرکت برشنا اشتراک کنید</th>
            <th class=""text-center"">شما چقدر بودجه جهت سرمایه گذاری در برنامه سولری برشنا شرکت دارید</th>
            <th class=""text-center"">لسان را که شما ترجیح میدهد با کارمن");
            WriteLiteral(@"د ده افغانستان برشنا شرکت در ارتباط باشید، کدام است</th>
            <th class=""text-center"">لطف نموده ایمیل تان را بدهید</th>
            <th class=""text-center"">شما جهت برقراری ارتباط کدام راه ترجیح میدهید</th>
            <th class=""text-center"">از خدمات ما چقدر احساس رضایت دارید</th>
            <th class=""text-center"">نظریات، پیشنهادات خود جهت بهبود خدمات د افغانستان برشنا شرکت با ما شریک بسازید</th>
            <th class=""text-center"">تاریخ ثبت</th>


        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 84 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
          int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 87 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n\r\n            <td>");
#nullable restore
#line 92 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 93 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.FormNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 94 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.AccountBrashna);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 95 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 96 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 97 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.FatherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 98 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Tazkira);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 99 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 100 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 101 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 102 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 103 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.TypeIncome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 104 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.IncomeMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 105 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Province);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 106 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Village);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 107 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Ghozar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 108 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.HouseNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 109 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.ProvinceLive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 110 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.VillageLive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 111 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.GhozarLive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 112 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.CountryLive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 113 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.PhoneLive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 114 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.LiveWF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 115 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.LiveWFAge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("            <td class=\"text-center\">");
#nullable restore
#line 117 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.CountLiveINFamily);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 118 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.EType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 119 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.EMCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 120 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.UseGenerator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 121 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.CapacityG);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 122 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.HourUG);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 123 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.WhenUG);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 124 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.ExpenseG);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 125 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.SourceE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 126 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.SourceEType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 127 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Room);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 128 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Floor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 129 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.WC);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 130 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Kichen);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 131 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.TypeHome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 132 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.AreaBuilding);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 133 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Land);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 134 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.RentType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 135 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.AirCandition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 136 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.UseTypeWarming);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 137 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.HourOnStove);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 138 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.TradeHome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 139 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.TypeTrade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 140 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.TradeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 141 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.TradeYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 142 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.StaffCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 143 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.BillRecive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 144 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.BillDayDaily);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 145 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.GhastVar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 146 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.ExpenseOld);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 147 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.PayOnTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 148 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.EAlltime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 149 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.EHour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 150 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.WantEAT);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 151 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.PayForEAT);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 152 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.BSolor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 153 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.SolorAmountAssets);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 154 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 155 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 156 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.WayContact);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 157 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Rezayat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">");
#nullable restore
#line 158 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
                               Write(item.Suggestion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center\">\r\n\r\n\r\n                ");
#nullable restore
#line 162 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
           Write(DateTimeExtensions.ConvertMiladiToShamsi(item.RegisterDateTime, "yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 168 "D:\ASP.NET CORE\Pro\Pro\Views\Report\_RentTable.cshtml"
            i++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9257a9d46d9dbb532e89aa3f0b9fd137d19fb9f327730", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Pro.Entities.Rent>> Html { get; private set; }
    }
}
#pragma warning restore 1591
