#pragma checksum "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\Features\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "693c5798a05957621d86a1361b73c211f5648291"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Features_Info), @"mvc.1.0.view", @"/Areas/Manage/Views/Features/Info.cshtml")]
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
#line 1 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\_ViewImports.cshtml"
using Pustok;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\_ViewImports.cshtml"
using Pustok.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\_ViewImports.cshtml"
using Pustok.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\_ViewImports.cshtml"
using Pustok.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\_ViewImports.cshtml"
using Pustok.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"693c5798a05957621d86a1361b73c211f5648291", @"/Areas/Manage/Views/Features/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df21a9fc34c7d2f5f0d205e80eb1eacc20b5a290", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Features_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Feature>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\Features\Info.cshtml"
  
    ViewData["Title"] = "Info";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<ul>\r\n    <li>Id : ");
#nullable restore
#line 8 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\Features\Info.cshtml"
        Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Header : ");
#nullable restore
#line 9 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\Features\Info.cshtml"
            Write(Model.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Title : ");
#nullable restore
#line 10 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\Features\Info.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("/li>\r\n    <li>Logo : ");
#nullable restore
#line 11 "C:\Users\Huseyn\source\repos\Pustok\Pustok\Areas\Manage\Views\Features\Info.cshtml"
          Write(Model.Logo);

#line default
#line hidden
#nullable disable
            WriteLiteral("/li>\r\n</ul>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Feature> Html { get; private set; }
    }
}
#pragma warning restore 1591