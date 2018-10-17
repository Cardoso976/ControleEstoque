using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace ControleEstoque.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/sweetalert2.min.js"));

            //AdminLTE
            bundles.Add(new StyleBundle("~/Bundles/adminlte/css").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/Buttons-1.5.2/css/buttons.bootstrap.min.css",
                    "~/Content/css/bootstrap-select.css",
                    "~/Content/css/bootstrap-datepicker3.min.css",
                    "~/Content/css/font-awesome.min.css",
                    "~/Content/Site.css")
                .Include("~/Content/css/skins/_all-skins.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute()));

            //DataTables
            bundles.Add(new StyleBundle("~/Bundles/datatables/css").Include(
                 "~/Content/DataTables-1.10.18/css/dataTables.bootstrap.min.css",
                 "~/Content/Buttons-1.5.2/css/buttons.bootstrap.min.css",
                 "~/Content/sweetalert2.min.css"));

            //DataTables
            bundles.Add(new ScriptBundle("~/Bundles/datatables/js").Include(
                "~/Content/DataTables-1.10.18/js/jquery.dataTables.min.js",
                "~/Content/DataTables-1.10.18/js/dataTables.bootstrap.min.js",
                "~/Scripts/dataTables.buttons.min.js",
                "~/Content/pdfmake-0.1.36/pdfmake.min.js",
                "~/Scripts/vfs_fonts.js",
                "~/Scripts/buttons.html5.min.js",
                "~/Scripts/buttons.print.min.js"));


            //AdminLTE
            bundles.Add(new ScriptBundle("~/Bundles/adminltejs").Include(
                "~/Content/js/plugins/moment/moment.js",
                "~/Content/js/plugins/datepicker/bootstrap-datepicker.js",
                "~/Content/js/plugins/slimscroll/jquery.slimscroll.js",
                "~/Content/js/plugins/validator.js",
                "~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js",
                "~/Content/js/plugins/fastclick/fastclick.js",
                "~/Content/js/adminlte.js",
                "~/Content/js/init.js"));

        }
    }
}
