#pragma checksum "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\Attendance\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c328999b6358efd19abbe73adf2dfb8eba2d2d61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Attendance_Index), @"mvc.1.0.view", @"/Views/Attendance/Index.cshtml")]
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
#line 1 "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\_ViewImports.cshtml"
using Black_Mesa_HRMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\_ViewImports.cshtml"
using Black_Mesa_HRMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\_ViewImports.cshtml"
using Black_Mesa_HRMS.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\_ViewImports.cshtml"
using Black_Mesa_HRMS.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c328999b6358efd19abbe73adf2dfb8eba2d2d61", @"/Views/Attendance/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a1e48472f57e3847419bfa6705d7cd0e497bd12", @"/Views/_ViewImports.cshtml")]
    public class Views_Attendance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FilterDataModal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Attendance.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\Attendance\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section id=""AttendanceTable"">
    <section class=""attendance-table-con"">
        <div class=""table-top"">
            <span>Attendance</span>
            <button class=""btn btn-filter-dataset"" data-bs-toggle=""modal"" data-bs-target=""#FilterDataModal""><i class=""fa-solid fa-filter""></i>Filter Dataset</button>
        </div>
        <div class=""table-con"">
            <table class=""table table-striped table-hover m-auto"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">ID</th>
                        <th scope=""col"">FullName</th>
                        <th scope=""col"">1</th>
                        <th scope=""col"">2</th>
                        <th scope=""col"">3</th>
                        <th scope=""col"">4</th>
                        <th scope=""col"">5</th>
                        <th scope=""col"">6</th>
                        <th scope=""col"">7</th>
                        <th scope=""col"">8</th>
     ");
            WriteLiteral(@"                   <th scope=""col"">9</th>
                        <th scope=""col"">10</th>
                        <th scope=""col"">11</th>
                        <th scope=""col"">12</th>
                        <th scope=""col"">13</th>
                        <th scope=""col"">14</th>
                        <th scope=""col"">15</th>
                        <th scope=""col"">16</th>
                        <th scope=""col"">17</th>
                        <th scope=""col"">18</th>
                        <th scope=""col"">19</th>
                        <th scope=""col"">20</th>
                        <th scope=""col"">21</th>
                        <th scope=""col"">22</th>
                        <th scope=""col"">23</th>
                        <th scope=""col"">24</th>
                        <th scope=""col"">25</th>
                        <th scope=""col"">26</th>
                        <th scope=""col"">27</th>
                        <th scope=""col"">28</th>
                        <th scope=""col"">29</th>
 ");
            WriteLiteral(@"                       <th scope=""col"">30</th>
                        <th scope=""col"">31</th>
                        <th scope=""col"">Total Absent</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td scope=""row"">1</td>
                        <td>101</td>
                        <td>Gordon Freeman</td>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
 ");
            WriteLiteral(@"                       <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""");
            WriteLiteral(@"attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
        ");
            WriteLiteral(@"                <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attenda");
            WriteLiteral(@"nce-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
                        <th scope=""col"">
                            <span class=""attendance-status"" date-for=""31"">A</span>
                        </th>
               ");
            WriteLiteral("         <th scope=\"col\">\r\n                            <span class=\"attendance-status\" date-for=\"31\">A</span>\r\n                        </th>\r\n                        <th scope=\"col\" class=\"attendance-count\">31</th>\r\n                        <th scope=\"col\"");
            BeginWriteAttribute("class", " class=\"", 7466, "\"", 7474, 0);
            EndWriteAttribute();
            WriteLiteral("><button class=\"btn table-btn\" data-bs-toggle=\"modal\" data-bs-target=\"#EditAttendanceModal\">Edit Attendance</button></th>\r\n                        <th scope=\"col\"");
            BeginWriteAttribute("class", " class=\"", 7637, "\"", 7645, 0);
            EndWriteAttribute();
            WriteLiteral(@"><a href=""#"" type=""button"" class="" btn table-btn"">Profile</i></a></th>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class=""table-bottom"">
            <nav>
                <ul class=""pagination"">
                    <li class=""page-item""><a class=""page-link"" href=""#"">Previous</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">Next</a></li>
                </ul>
            </nav>
        </div>
    </section>
</section>
<div class=""modal fade"" id=""FilterDataModal"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-titl");
            WriteLiteral(@"e employee-salary-modal-title "" id=""exampleModalLabel"">Filter Dataset</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""employee-salary-modal-con"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c328999b6358efd19abbe73adf2dfb8eba2d2d6115676", async() => {
                WriteLiteral(@"
                        <div class=""form-floating mb-3"">
                            <input type=""email"" class=""form-control"" id=""floatingInput"" placeholder=""name@example.com"">
                            <label for=""floatingInput"">ID or FullName</label>
                        </div>
                        <div class=""form-floating"">
                            <select class=""form-select"" id=""floatingSelect"" aria-label=""Floating label select example"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c328999b6358efd19abbe73adf2dfb8eba2d2d6116450", async() => {
                    WriteLiteral("ID");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c328999b6358efd19abbe73adf2dfb8eba2d2d6117816", async() => {
                    WriteLiteral("FullName");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c328999b6358efd19abbe73adf2dfb8eba2d2d6119074", async() => {
                    WriteLiteral("Total Absent");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                            <label for=""floatingSelect"">Sort By</label>
                        </div>
                        <div class=""form-check form-switch mt-2"">
                            <input class=""form-check-input"" type=""checkbox"" role=""switch"" id=""flexSwitchCheckDefault"">
                            <label class=""form-check-label"" for=""flexSwitchCheckDefault"">Sort Descending</label>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn-cancel-modal"" data-bs-dismiss=""modal"">Cancel</button>
                <button type=""button"" id=""FilterDataModalAddBtn"" class=""btn-apply-modal"">Search</button>
            </div>
        </div>
    </div>
</div>
<div class=""modal fade"" id=""EditAttendanceModal"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title employee-salary-modal-title "" id=""exampleModalLabel"">Edit Attendance</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""employee-salary-modal-con"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c328999b6358efd19abbe73adf2dfb8eba2d2d6122922", async() => {
                WriteLiteral(@"
                        <div class=""mb-3"">
                            <label for=""exampleFormControlInput1"" class=""form-label"">Edit Attendance for</label>
                            <input type=""date"" class=""form-control"" id=""exampleFormControlInput1"">
                        </div>
                        <div class=""form-check"">
                            <input class=""form-check-input"" type=""radio"" name=""flexRadioDefault"" id=""flexRadioDefault1"">
                            <label class=""form-check-label"" for=""flexRadioDefault1"">
                                Absent
                            </label>
                        </div>
                        <div class=""form-check"">
                            <input class=""form-check-input"" type=""radio"" name=""flexRadioDefault"" id=""flexRadioDefault2"">
                            <label class=""form-check-label"" for=""flexRadioDefault2"">
                                Present
                            </label>
                        </d");
                WriteLiteral(@"iv>
                        <div class=""form-check"">
                            <input class=""form-check-input"" type=""radio"" name=""flexRadioDefault"" id=""flexRadioDefault2"">
                            <label class=""form-check-label"" for=""flexRadioDefault2"">
                                Allowed
                            </label>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn-cancel-modal"" data-bs-dismiss=""modal"">Cancel</button>
                <button type=""button"" id=""FilterDataModalAddBtn"" class=""btn-apply-modal"">Apply</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c328999b6358efd19abbe73adf2dfb8eba2d2d6126287", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
