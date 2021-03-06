#pragma checksum "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6cd5254d3af553fd0dd7aaedff900e2fe33e1ad"
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
#line 1 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\_ViewImports.cshtml"
using AplicacaoClienteSeparada;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\_ViewImports.cshtml"
using AplicacaoClienteSeparada.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6cd5254d3af553fd0dd7aaedff900e2fe33e1ad", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d117e141270fb26df6286fbb18af43879cd91228", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClienteModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <td>Ações</td>\r\n        <td>Id</td>\r\n        <td>Nome</td>\r\n    </tr>\r\n    <tbody>\r\n");
#nullable restore
#line 10 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\Home\Index.cshtml"
         foreach (var cliente in (List<ClienteModel>)ViewBag.ListarTodosClientes)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td style=\"width:50px\"><button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 345, "\"", 384, 3);
            WriteAttributeValue("", 355, "RegistrarCliente(", 355, 17, true);
#nullable restore
#line 13 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\Home\Index.cshtml"
WriteAttributeValue("", 372, cliente.id, 372, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 383, ")", 383, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button></td>\r\n                <td style=\"width:50px\"><button class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 477, "\"", 514, 3);
            WriteAttributeValue("", 487, "ExcluirCliente(", 487, 15, true);
#nullable restore
#line 14 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\Home\Index.cshtml"
WriteAttributeValue("", 502, cliente.id, 502, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 513, ")", 513, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Excluir</button></td>\r\n                <td>");
#nullable restore
#line 15 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\Home\Index.cshtml"
               Write(cliente.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 16 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\Home\Index.cshtml"
               Write(cliente.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 18 "D:\Estudos\WebApi-MySql\Desenvolvimento de Web APIs .NET Core com MySQL\AplicacaoClienteSeparada\AplicacaoClienteSeparada\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<button class=""btn btn-primary"" onclick=""RegistrarCliente()"">Registrar Cliente</button>

<script>
    function RegistrarCliente(id) {
        if (id == null) {
            window.location.href = window.location.origin + ""/Home/Registrar"";
        }
        else {
            window.location.href = window.location.origin + ""/Home/Registrar/"" + id;
        }
    }

    function ExcluirCliente(id) {
        window.location.href = window.location.origin + ""/Home/Excluir/"" + id;
    }

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClienteModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
