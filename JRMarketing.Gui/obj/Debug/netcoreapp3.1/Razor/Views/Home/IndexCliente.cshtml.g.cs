#pragma checksum "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\IndexCliente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c4a2b23c3cdd925e23da04529640b1bf66f0f34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexCliente), @"mvc.1.0.view", @"/Views/Home/IndexCliente.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c4a2b23c3cdd925e23da04529640b1bf66f0f34", @"/Views/Home/IndexCliente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c94c9ee24af97ab588ea9a66c9618d6badbea139", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_IndexCliente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JRMarketing.Gui.Models.Usuarios>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\IndexCliente.cshtml"
  
    ViewData["Title"] = "Inicio";
    Layout = "~/Views/Shared/LayoutUser.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <center>\r\n        <h2>Welcome ");
#nullable restore
#line 9 "C:\Users\Javier Hernández\Documents\Universidad\4° Cuatrimestre\Proyecto Integrador\JRMarketing\JRMarketing.Gui\Views\Home\IndexCliente.cshtml"
               Write(Model.NombreUsuario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    </center>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JRMarketing.Gui.Models.Usuarios> Html { get; private set; }
    }
}
#pragma warning restore 1591
