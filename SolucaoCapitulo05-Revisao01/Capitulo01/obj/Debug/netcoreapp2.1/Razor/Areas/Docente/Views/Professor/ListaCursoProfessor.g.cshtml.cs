#pragma checksum "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f5fff5671132cca7954d8908a6958d6156330c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Docente_Views_Professor_ListaCursoProfessor), @"mvc.1.0.view", @"/Areas/Docente/Views/Professor/ListaCursoProfessor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Docente/Views/Professor/ListaCursoProfessor.cshtml", typeof(AspNetCore.Areas_Docente_Views_Professor_ListaCursoProfessor))]
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
#line 1 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\_ViewImports.cshtml"
using Capitulo01;

#line default
#line hidden
#line 2 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\_ViewImports.cshtml"
using Capitulo01.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f5fff5671132cca7954d8908a6958d6156330c5", @"/Areas/Docente/Views/Professor/ListaCursoProfessor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5010076b92bf8e2a381f732b3119b570f2558932", @"/Areas/Docente/Views/_ViewImports.cshtml")]
    public class Areas_Docente_Views_Professor_ListaCursoProfessor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Modelo.Docente.CursoProfessor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(80, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(109, 114, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "383e775c132641cda621aa2c3006f2c5", async() => {
                BeginContext(115, 101, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>ListaCursoProfessor</title>\r\n");
                EndContext();
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
            EndContext();
            BeginContext(223, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(225, 984, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa12cebcaa834189845fc841a2cf3d23", async() => {
                BeginContext(231, 11, true);
                WriteLiteral("\r\n<p>\r\n    ");
                EndContext();
                BeginContext(242, 37, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0bfbad7e4a8483dbdd1b25e34f6101b", async() => {
                    BeginContext(265, 10, true);
                    WriteLiteral("Create New");
                    EndContext();
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
                EndContext();
                BeginContext(279, 92, true);
                WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(372, 41, false);
#line 22 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
           Write(Html.DisplayNameFor(model => model.Curso));

#line default
#line hidden
                EndContext();
                BeginContext(413, 55, true);
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(469, 50, false);
#line 25 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
           Write(Html.DisplayNameFor(model => model.Professor.Nome));

#line default
#line hidden
                EndContext();
                BeginContext(519, 86, true);
                WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
                EndContext();
#line 31 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
                BeginContext(637, 48, true);
                WriteLiteral("        <tr>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(686, 45, false);
#line 34 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
           Write(Html.DisplayFor(modelItem => item.Curso.Nome));

#line default
#line hidden
                EndContext();
                BeginContext(731, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(787, 49, false);
#line 37 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
           Write(Html.DisplayFor(modelItem => item.Professor.Nome));

#line default
#line hidden
                EndContext();
                BeginContext(836, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(892, 65, false);
#line 40 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
                EndContext();
                BeginContext(957, 20, true);
                WriteLiteral(" |\r\n                ");
                EndContext();
                BeginContext(978, 71, false);
#line 41 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
                EndContext();
                BeginContext(1049, 20, true);
                WriteLiteral(" |\r\n                ");
                EndContext();
                BeginContext(1070, 69, false);
#line 42 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
                EndContext();
                BeginContext(1139, 36, true);
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
                EndContext();
#line 45 "C:\Users\ander\Desktop\SolucaoCapitulo05-Revisao01\Capitulo01\Areas\Docente\Views\Professor\ListaCursoProfessor.cshtml"
}

#line default
#line hidden
                BeginContext(1178, 24, true);
                WriteLiteral("    </tbody>\r\n</table>\r\n");
                EndContext();
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
            EndContext();
            BeginContext(1209, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Modelo.Docente.CursoProfessor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
