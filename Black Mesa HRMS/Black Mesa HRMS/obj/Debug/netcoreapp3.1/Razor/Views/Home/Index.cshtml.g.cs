#pragma checksum "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1054aabd38b372eb5f8da057e7f27dc688f1666"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1054aabd38b372eb5f8da057e7f27dc688f1666", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a1e48472f57e3847419bfa6705d7cd0e497bd12", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FormTodoList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/dashboard.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/chartCustom.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Huseyn\source\repos\Black Mesa HRMS\Black Mesa HRMS\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""general-info-con"">
    <div class=""row"">
        <section id=DashboardTopCards class=""col-xxl-3 col-12"">
            <div class=""dashboard-top-cards-con"">
                <div class=""row"">
                    <div class=""card col-sm-6 col-xl-6  "">
                        <div class=""card-body"">
                            <div class=""card-logo"">
                                <i class=""fa-solid fa-user-plus""></i>
                            </div>
                            <div class=""card-context"">
                                <h5 class=""card-title"">New Employee</h5>
                                <p class=""card-text"">0</p>
                            </div>
                        </div>
                    </div>
                    <div class=""card col-sm-6 col-xl-6  "">
                        <div class=""card-body"">
                            <div class=""card-logo"">
                                <i class=""fa-solid fa-user-group""></i>
                       ");
            WriteLiteral(@"     </div>
                            <div class=""card-context"">
                                <h5 class=""card-title"">Total Employee</h5>
                                <p class=""card-text"">0</p>
                            </div>
                        </div>
                    </div>
                    <div class=""card col-sm-6 col-xl-6  "">
                        <div class=""card-body"">
                            <div class=""card-logo"">
                                <i class=""fa-solid fa-hand-holding-dollar""></i>
                            </div>
                            <div class=""card-context"">
                                <h5 class=""card-title"">Total Salary</h5>
                                <p class=""card-text"">0 $ </p>
                            </div>
                        </div>
                    </div>
                    <div class=""card col-sm-6 col-xl-6  "">
                        <div class=""card-body"">
                            <div class=""card-l");
            WriteLiteral(@"ogo"">
                                <i class=""fa-solid fa-wallet""></i>
                            </div>
                            <div class=""card-context"">
                                <h5 class=""card-title"">Saveings</h5>
                                <p class=""card-text"">9999 $</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section id=IncomeChart class=""col-xxl-9 col-12"">
            <section class=""income-chart-con"">
                <div class=""row"">
                    <div class="" chart-main-con col-xxl-4 col-xl-5 col-xs-12 "">
                        <div class=""row"">
                            <div class=""chart-name"">
                                <span>Employee Salary by Percent</span>
                            </div>
                            <div class=""chart-con"">
                                <canvas id=""IncomeChartjs""></canvas>
          ");
            WriteLiteral(@"                  </div>
                        </div>
                    </div>
                    <div class=""chart-context-con col-xxl-8 col-xl-7 col-xs-12"">
                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item"">
                                <div class=""list-context"">
                                    <span class=""color-con "" style=""background-color: rgb(204, 0, 255) ;""></span>
                                    <span class=""text-con "">Total Scientist salary</span>
                                    <span class=""salary-con ""> 999 $</span>
                                </div>
                            </li>
                            <li class=""list-group-item"">
                                <div class=""list-context"">
                                    <span class=""color-con "" style=""background-color: rgb(25, 0, 255) ;""></span>
                                    <span class=""text-con "">Total Security salary<");
            WriteLiteral(@"/span>
                                    <span class=""salary-con ""> 999 $</span>
                                </div>
                            </li>
                            <li class=""list-group-item"">
                                <div class=""list-context"">
                                    <span class=""color-con "" style=""background-color: rgb(255, 0, 0) ;""></span>
                                    <span class=""text-con "">Total Administration salary</span>
                                    <span class=""salary-con ""> 999 $</span>
                                </div>
                            </li>
                            <li class=""list-group-item"">
                                <div class=""list-context"">
                                    <span class=""color-con "" style=""background-color: rgb(255, 196, 0) ;""></span>
                                    <span class=""text-con "">Total Maintenance salary</span>
                                    <span class=""salary-con");
            WriteLiteral(@" ""> 999 $</span>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </section>
        </section>
    </div>
</section>
<section id=""GenderandSalary"">
    <div class=""container-fluid gender-salary-con "">
        <div class=""row"">
            <div class=""gender-chart-con col-xxl-3 col-xl-4  col-xs-12"">
                <div class=""container-fluid"">
                    <div class=""row"">
                        <div class=""chart-top-con"">
                            <span>Employee Genders</span>
                        </div>
                        <div class=""chart-main-con"">
                            <canvas id=""GenderChartjs""></canvas>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""salary-by-date-con col-xxl-9 col-xl-8 col-xs-12"">
                <div class=""container-fluid"">
                 ");
            WriteLiteral(@"   <div class=""row"">
                        <div class=""chart-top-con"">
                            <span>Employee Salaries </span>
                            <div class=""btn-group "" role=""group"" aria-label=""Basic outlined example"">
                                <button type=""button"" class=""btn month-view-btn-ES active"">Monthly</button>
                                <button type=""button"" class=""btn year-view-btn-ES  "">Yearly</button>
                            </div>
                        </div>
                        <div class=""chart-main-con"">
                            <canvas id=""SalaryByDateChartjs""></canvas>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section id=""TodoListDashboard"">
    <div class=""to-do-list-con"">
        <div class=""to-do-top-con"">
            <span>To-do List</span>
            <button type=""button"" class=""btn"" data-bs-toggle=""modal"" data-bs-target=""#exampleM");
            WriteLiteral(@"odal"">Add <i class=""fa-solid fa-plus""></i></button>
        </div>
        <ul class=""list-group"">
            <li class=""list-group-item"">
                <div class=""list-item-top"">
                    <input class=""form-check-input me-1"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 7472, "\"", 7480, 0);
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""..."">
                    Second checkbox
                </div>
                <div class=""list-item-title"">
                    <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis dolorem, dolores inventore quidem quas ducimus mollitia placeat officia! Corporis cum porro iure at praesentium quibusdam ea consectetur, unde voluptas deserunt.</span>
                </div>
                <div class=""list-item-time"">
                    <span>SCHEDULED FOR 4:30 P.M. ON JUN 2021</span>
                </div>
            </li>
            <li class=""list-group-item"">
                <div class=""list-item-top"">
                    <input class=""form-check-input me-1"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 8209, "\"", 8217, 0);
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""..."">
                    Second checkbox
                </div>
                <div class=""list-item-title"">
                    <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis dolorem, dolores inventore quidem quas ducimus mollitia placeat officia! Corporis cum porro iure at praesentium quibusdam ea consectetur, unde voluptas deserunt.</span>
                </div>
                <div class=""list-item-time"">
                    <span>SCHEDULED FOR 4:30 P.M. ON JUN 2021</span>
                </div>
            </li>
            <li class=""list-group-item"">
                <div class=""list-item-top"">
                    <input class=""form-check-input me-1"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 8946, "\"", 8954, 0);
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""..."">
                    Second checkbox
                </div>
                <div class=""list-item-title"">
                    <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis dolorem, dolores inventore quidem quas ducimus mollitia placeat officia! Corporis cum porro iure at praesentium quibusdam ea consectetur, unde voluptas deserunt.</span>
                </div>
                <div class=""list-item-time"">
                    <span>SCHEDULED FOR 4:30 P.M. ON JUN 2021</span>
                </div>
            </li>
            <li class=""list-group-item"">
                <div class=""list-item-top"">
                    <input class=""form-check-input me-1"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 9683, "\"", 9691, 0);
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""..."">
                    Second checkbox
                </div>
                <div class=""list-item-title"">
                    <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis dolorem, dolores inventore quidem quas ducimus mollitia placeat officia! Corporis cum porro iure at praesentium quibusdam ea consectetur, unde voluptas deserunt.</span>
                </div>
                <div class=""list-item-time"">
                    <span>SCHEDULED FOR 4:30 P.M. ON JUN 2021</span>
                </div>
            </li>
        </ul>
    </div>
</section>
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title to-do-list-modal-title "" id=""exampleModalLabel"">To-do</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""");
            WriteLiteral("modal\" aria-label=\"Close\"></button>\r\n            </div>\r\n            <div class=\"modal-body\">\r\n                <div class=\"to-do-list-modal-con\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1054aabd38b372eb5f8da057e7f27dc688f166617362", async() => {
                WriteLiteral(@"
                        <div class=""input-group mb-3"">
                            <span class=""input-group-text"" id=""basic-addon1"">Title</span>
                            <input type=""text"" class=""form-control"" data-for=""to-do-list-title"" aria-describedby=""basic-addon1"">
                        </div>
                        <div class=""input-group mb-3"">
                            <span class=""input-group-text"" id=""basic-addon1"">Context</span>
                            <textarea class=""form-control"" data-for=""to-do-list-context"" aria-label=""With textarea""></textarea>
                        </div>
                        <div class=""input-group mb-3"">
                            <span class=""input-group-text"" id=""basic-addon1"">Schedule for</span>
                            <input type=""date"" class=""form-control"" data-for=""to-do-list-schedule"" aria-describedby=""basic-addon1"">
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
                <button type=""button"" id=""TodoListAddBtn"" class=""btn-apply-modal"">Add</button>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.1/chart.min.js"" integrity=""sha512-QSkVNOCYLtj73J4hbmVoOV6KVZuMluZlioC+trLpewV8qMjsWqlIQvkn1KGX2StWvPMdWGBqim1xlC8krl1EKQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1054aabd38b372eb5f8da057e7f27dc688f166620472", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1054aabd38b372eb5f8da057e7f27dc688f166621572", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
