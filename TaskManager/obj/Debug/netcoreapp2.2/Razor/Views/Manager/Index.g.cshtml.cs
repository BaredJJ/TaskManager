#pragma checksum "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c162d7110974a3288b2e194166f893761f8324d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Index), @"mvc.1.0.view", @"/Views/Manager/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Manager/Index.cshtml", typeof(AspNetCore.Views_Manager_Index))]
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
#line 1 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\_ViewImports.cshtml"
using TaskManager.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c162d7110974a3288b2e194166f893761f8324d2", @"/Views/Manager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e259a7a12937b47945ab97c295d1e2baff4e3478", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TaskManager.Models.Manager>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(80, 330, true);
            WriteLiteral(@"
<h1>Список менеджеров</h1>

<table class=""table table-striped table-bordered table-sm"">
    <thead>
    <tr>
        <th class=""text-left"">Имя</th>
        <th class=""text-left"">Отчество</th>
        <th class=""text-left"">Фамилия</th>
        <th class=""text-right"">Должность</th>
    </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 18 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml"
     foreach (var manager in Model)
    {

#line default
#line hidden
            BeginContext(454, 48, true);
            WriteLiteral("        <tr>\r\n            <th class=\"text-left\">");
            EndContext();
            BeginContext(503, 17, false);
#line 21 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml"
                             Write(manager.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(520, 41, true);
            WriteLiteral("</th>\r\n            <th class=\"text-left\">");
            EndContext();
            BeginContext(562, 15, false);
#line 22 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml"
                             Write(manager.SurName);

#line default
#line hidden
            EndContext();
            BeginContext(577, 41, true);
            WriteLiteral("</th>\r\n            <th class=\"text-left\">");
            EndContext();
            BeginContext(619, 16, false);
#line 23 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml"
                             Write(manager.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(635, 42, true);
            WriteLiteral("</th>\r\n            <th class=\"text-right\">");
            EndContext();
            BeginContext(678, 16, false);
#line 24 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml"
                              Write(manager.Position);

#line default
#line hidden
            EndContext();
            BeginContext(694, 22, true);
            WriteLiteral("</th>\r\n        </tr>\r\n");
            EndContext();
#line 26 "E:\Coding\AspNetCore\TaskManager\TaskManager\Views\Manager\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(723, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TaskManager.Models.Manager>> Html { get; private set; }
    }
}
#pragma warning restore 1591