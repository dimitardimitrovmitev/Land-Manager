#pragma checksum "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8e84479acb74bf36a1b43ab74d2392058ba6e80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Land_Add), @"mvc.1.0.view", @"/Views/Land/Add.cshtml")]
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
#line 1 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\_ViewImports.cshtml"
using Land_Manager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\_ViewImports.cshtml"
using Land_Manager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8e84479acb74bf36a1b43ab74d2392058ba6e80", @"/Views/Land/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"055f268576c91a24fa3e1f7b2ade4fc374356946", @"/Views/_ViewImports.cshtml")]
    public class Views_Land_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Data.Models.Land>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
  
    ViewData["Title"] = "Add Land";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"centered-form\">\r\n        <div class=\"mb-3 ml-3\">\r\n            <h2>Add Property</h2>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 15 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
       Write(Html.LabelFor(model => model.Address, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-12\">\r\n                ");
#nullable restore
#line 17 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
           Write(Html.EditorFor(m => m.Address, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 18 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Address, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-row\">\r\n            \r\n           \r\n            <div class=\"form-group col-sm-4\">\r\n                ");
#nullable restore
#line 25 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
           Write(Html.LabelFor(model => model.Area, new { @class = "control-label col-12" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-12\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
               Write(Html.EditorFor(m => m.Area, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 28 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
               Write(Html.ValidationMessageFor(model => model.Area, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 33 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
       Write(Html.LabelFor(model => model.Rent, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-12\">\r\n                ");
#nullable restore
#line 35 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
           Write(Html.EditorFor(m => m.Rent, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 36 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Rent, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""form-group centered-button"">
            <div class=""col-offset-2 col-3"">
                <button type=""submit"" class=""btn btn-success btn-block"">Add</button>
            </div>
        </div>
    </div>
");
#nullable restore
#line 45 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Land\Add.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Data.Models.Land> Html { get; private set; }
    }
}
#pragma warning restore 1591
