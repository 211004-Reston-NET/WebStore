#pragma checksum "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9094acfd31a5260bc3f1ce3f59ac7e68c440266b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BookList), @"mvc.1.0.view", @"/Views/Home/BookList.cshtml")]
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
#line 1 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\_ViewImports.cshtml"
using BookStore.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\_ViewImports.cshtml"
using BookStore.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9094acfd31a5260bc3f1ce3f59ac7e68c440266b", @"/Views/Home/BookList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a02baff6454fdcb17aea482168d005cffcd9aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_BookList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookStore.BL.DTO.BookDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddBook", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
  
    ViewData["Title"] = "BookList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>BookList</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9094acfd31a5260bc3f1ce3f59ac7e68c440266b3659", async() => {
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayNameFor(model => model.BookId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayNameFor(model => model.BookTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayNameFor(model => model.BookAuthor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayNameFor(model => model.ShopName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayNameFor(model => model.ShopState));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayFor(modelItem => item.BookId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayFor(modelItem => item.BookTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayFor(modelItem => item.BookAuthor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n          \r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ShopName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 63 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ShopState));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 66 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
           Write(Html.ActionLink("Edit", "EditBook", new {  bookId=item.BookId  }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 69 "C:\Users\Ayogh\Desktop\BookStore\BookStore.Web\Views\Home\BookList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookStore.BL.DTO.BookDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
