#pragma checksum "C:\Users\Woody\OneDrive\Documents\Development\SearchEngineKeywordTracker\SearchEngineKeywordTracker\SearchEngineKeywordTracker.Application\Views\Shared\_Loader.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2316d044b4d49b412ffd735f3913193de2252b5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Loader), @"mvc.1.0.view", @"/Views/Shared/_Loader.cshtml")]
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
#line 1 "C:\Users\Woody\OneDrive\Documents\Development\SearchEngineKeywordTracker\SearchEngineKeywordTracker\SearchEngineKeywordTracker.Application\Views\_ViewImports.cshtml"
using SearchEngineKeywordTracker.Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Woody\OneDrive\Documents\Development\SearchEngineKeywordTracker\SearchEngineKeywordTracker\SearchEngineKeywordTracker.Application\Views\_ViewImports.cshtml"
using SearchEngineKeywordTracker.Application.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2316d044b4d49b412ffd735f3913193de2252b5d", @"/Views/Shared/_Loader.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aed38e9754601f795b8d3811f891986cfb765329", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Loader : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"loader loader-sm\"");
            BeginWriteAttribute("id", " id=\"", 44, "\"", 55, 1);
#nullable restore
#line 2 "C:\Users\Woody\OneDrive\Documents\Development\SearchEngineKeywordTracker\SearchEngineKeywordTracker\SearchEngineKeywordTracker.Application\Views\Shared\_Loader.cshtml"
WriteAttributeValue("", 49, Model, 49, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"fa-3x loading-spinner\">\r\n        <i class=\"fas fa-circle-notch fa-spin\"></i>\r\n    </div>\r\n    <span class=\"loading-text\">Loading</span>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591