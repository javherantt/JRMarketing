#pragma checksum "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17e4cea9e8069839936815a43051f250cd4c9c6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\_ViewImports.cshtml"
using JRMarketing.Gui;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\_ViewImports.cshtml"
using JRMarketing.Gui.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17e4cea9e8069839936815a43051f250cd4c9c6a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c94c9ee24af97ab588ea9a66c9618d6badbea139", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JRMarketing.Domain.DTOs.UsuarioResponseDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Inicio";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Inicio</h1>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 11 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Contrasenia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Apellidos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Contrasenia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Apellidos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 55 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 58 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\Index.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JRMarketing.Domain.DTOs.UsuarioResponseDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
