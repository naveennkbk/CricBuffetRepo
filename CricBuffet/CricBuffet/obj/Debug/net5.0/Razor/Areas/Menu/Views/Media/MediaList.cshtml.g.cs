#pragma checksum "C:\Users\kiwitech\source\repos\Naveen\CricBuffet\CricBuffet\Areas\Menu\Views\Media\MediaList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3096ab2a5bce6b172fe20b2c070dddda3e9053ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Menu_Views_Media_MediaList), @"mvc.1.0.view", @"/Areas/Menu/Views/Media/MediaList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3096ab2a5bce6b172fe20b2c070dddda3e9053ee", @"/Areas/Menu/Views/Media/MediaList.cshtml")]
    public class Areas_Menu_Views_Media_MediaList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
    .dataTable > thead > tr > th[class*=""sort""]:before,
    .dataTable > thead > tr > th[class*=""sort""]:after {
        content: """" !important;
    }

    .ui-widget-content {
        background: none
    }

    .ui-widget-header {
        background: none
    }

    hr:not([size]) {
        height: 0px;
    }

    #btnu {
        background: #1F3BB3;
        color: white;
        padding: 7px;
        font-size: 12px;
        text-decoration: none;
        border-radius: 25px
    }

        #btnu:hover {
            color: white
        }

    .table th, .table td {
        vertical-align: middle;
        line-height: 1;
        white-space: nowrap;
        padding: 1.125rem 1.375rem;
        font-size: 11px;
        padding: 14px;
        text-align: center;
        font-weight: bold
    }
</style>

<div class=""col-lg-12 grid-margin stretch-card"" style=""margin-top:-36px"">
    <div class=""card"">
        <div class=""card-body"">
            <h4 class=""card-");
            WriteLiteral("title\">\r\n                <span style=\"color: #76bf70\">Menu</span> List\r\n            </h4>\r\n            <p class=\"card-description\">\r\n                <a class=\"btn btn-default\" id=\"btnu\"");
            BeginWriteAttribute("href", " href=\'", 1209, "\'", 1273, 1);
#nullable restore
#line 51 "C:\Users\kiwitech\source\repos\Naveen\CricBuffet\CricBuffet\Areas\Menu\Views\Media\MediaList.cshtml"
WriteAttributeValue("", 1216, Url.Action("MenuCreate", "Media", new { Area = "Menu" }), 1216, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-plus"" style=""color:white""></i> Add Menu</a>
            </p>
            <div class=""table-responsive"">
                <table class=""table table-striped"" id=""menuTable"">
                    <thead>
                        <tr>
                            <th>Menu Name</th>
                            <th>Created Date</th>
                            <th></th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>

");
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
    <script src=""https://code.jquery.com/ui/1.11.1/jquery-ui.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap4.min.js ""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta2/js/all.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/notify/0.4.2/notify.min.js""></script>
    <script type=""text/javascript"" src=""https://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.12/jquery.validate.unobtrusive.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.12/jquery.validate.unobtrusive.js""></script>

    <link href=""https://cdn.");
                WriteLiteral(@"datatables.net/1.10.15/css/dataTables.bootstrap.min.css"" rel=""stylesheet"" />
    <link href=""https://cdn.datatables.net/responsive/2.1.1/css/responsive.bootstrap.min.css"" rel=""stylesheet"" />

    <link rel=""stylesheet"" href=""https://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css"" />

    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/notify/0.4.2/styles/metro/notify-metro.min.css"" />

    <script type=""text/javascript"">
        var submitted, datatable;
        $(document).ready(function () {
            datatable = $('#menuTable').DataTable({
                ""autoWidth"": false,
                ""ajax"": {
                    'url': ""/Menu/Media/MenuListing"",
                    ""type"": ""GET"",
                    ""datatype"": ""json""

                },
                ""columns"": [

                    { ""data"": ""mediaMenuName"" },

                    { ""data"": ""createdDate"" },
                    {
                        ""data"": ""id"", ""render"":function (da");
                WriteLiteral("ta) {\r\n                            return \"<a   href=\'");
#nullable restore
#line 125 "C:\Users\kiwitech\source\repos\Naveen\CricBuffet\CricBuffet\Areas\Menu\Views\Media\MediaList.cshtml"
                                          Write(Url.Action("MenuEdit", "Media", new { Area = "Menu" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("/\" + data + \"\'><i  class=\'fa fa-pencil\'></i> </a><a style=\'margin-left:20px;color:green\' onclick=submission(\'");
#nullable restore
#line 125 "C:\Users\kiwitech\source\repos\Naveen\CricBuffet\CricBuffet\Areas\Menu\Views\Media\MediaList.cshtml"
                                                                                                                                                                                                              Write(Url.Action("MenuView", "Media", new { Area = "Menu" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + data + ""')><i  class='fa fa-eye'></i></a><a  style='color:red;font-size:15px;margin-left:20px' onclick=DEl("" + data + "") style='margin-left:0px;color:blue;font-size:10px'><i class='fa fa-trash'></i> </a>""
                         },
                        ""orderable"": false,
                        ""width"": ""150px"",
                        ""searchable"":false
                    }
                ]
            });
        });

         function DEl(id)
        {
            if (confirm(""Hey Buddy, are you sure want to delete your buddy!!""))
            {
                $.ajax({
                    type: ""Post"",
                    url: '");
#nullable restore
#line 141 "C:\Users\kiwitech\source\repos\Naveen\CricBuffet\CricBuffet\Areas\Menu\Views\Media\MediaList.cshtml"
                     Write(Url.Action("MenuDelete", "Media", new { Area = "Menu" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/' + id,
                    success: function (data) {
                        alert(""deleted"");
                        datatable.ajax.reload();
                        if (data.success) {

                            $.notify(data.message, {
                                globalPosition: ""topright"",
                                className: ""success""

                            });
                        }
                    }
                });
            }
        }
    </script>

");
            }
            );
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
