#pragma checksum "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0214ac7f1a58e63288f6f86c71bbdcdba7143538"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Add), @"mvc.1.0.view", @"/Views/Customer/Add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0214ac7f1a58e63288f6f86c71bbdcdba7143538", @"/Views/Customer/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"055f268576c91a24fa3e1f7b2ade4fc374356946", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Land_Manager.Models.CustomerModels.AddCustomerModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
  
    ViewData["Title"] = "Add Customer";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"centered-form\">\r\n        <div class=\"mb-3 ml-3\">\r\n            <h2>Add Customer</h2>\r\n        </div>\r\n        <div class=\"form-row\">\r\n            <div class=\"form-group col-sm-6\">\r\n                ");
#nullable restore
#line 16 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.LabelFor(model => model.Customer.FirstName, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-12\">\r\n                    ");
#nullable restore
#line 18 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
               Write(Html.EditorFor(m => m.Customer.FirstName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 19 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
               Write(Html.ValidationMessageFor(model => model.Customer.FirstName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group col-sm-6\">\r\n                ");
#nullable restore
#line 23 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.LabelFor(model => model.Customer.LastName, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-12\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
               Write(Html.EditorFor(m => m.Customer.LastName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 26 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
               Write(Html.ValidationMessageFor(model => model.Customer.LastName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 31 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
       Write(Html.LabelFor(model => model.Customer.Email, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-12\">\r\n                ");
#nullable restore
#line 33 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.EditorFor(m => m.Customer.Email, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 34 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Customer.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n         </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 38 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
       Write(Html.LabelFor(model => model.Customer.PhoneNumber, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-12\">\r\n                ");
#nullable restore
#line 40 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.EditorFor(m => m.Customer.PhoneNumber, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 41 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Customer.PhoneNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n         </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 45 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
       Write(Html.LabelFor(model => model.Customer.DateOfRenting, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-12\">\r\n                ");
#nullable restore
#line 47 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.EditorFor(m => m.Customer.DateOfRenting, new { htmlAttributes = new { @class = "form-control", @type = "date" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 48 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Customer.DateOfRenting, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n         </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 52 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
       Write(Html.LabelFor(model => model.Customer.RentedLand, new { @class = "control-label col-6" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-12\">\r\n                ");
#nullable restore
#line 54 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
           Write(Html.DropDownListFor(model => model.RentedLandId, new SelectList(Model.Lands.Select(m => m), "Id", "Address"), "Select Land", new { @class = "form-control" }));

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
#line 63 "C:\Users\SHTERIO\Desktop\Land_Manager\Land-Manager\Land_Manager\Land_Manager\Views\Customer\Add.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Land_Manager.Models.CustomerModels.AddCustomerModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
