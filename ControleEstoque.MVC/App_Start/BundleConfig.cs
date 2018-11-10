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
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/jquery.slimscroll.min.js",
                       "~/Scripts/jquery.mask.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/sweetalert2.min.js"));

            //AdminLTE
            bundles.Add(new StyleBundle("~/Bundles/adminlte/css").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/buttons.bootstrap.min.css",
                    "~/Content/bootstrap-select.min.css",
                    "~/Content/bootstrap-datepicker3.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/Site.css",
                    "~/Content/AdminLTE.min.css",
                    "~/Content/_all-skins.css",
                    "~/Content/sweetalert2.min.css"));

            //DataTables
            bundles.Add(new StyleBundle("~/Bundles/datatables/css").Include(
                 "~/Content/DataTables-1.10.18/css/dataTables.bootstrap.min.css"));

            //DataTables
            bundles.Add(new ScriptBundle("~/Bundles/datatables/js").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.bootstrap.min.js",
                "~/Scripts/dataTables.buttons.min.js",
                "~/Scripts/pdfmake.js",
                "~/Scripts/vfs_fonts.js",
                "~/Scripts/buttons.html5.min.js",
                "~/Scripts/buttons.print.min.js"));

            //AdminLTE
            bundles.Add(new ScriptBundle("~/Bundles/adminltejs").Include(
                "~/Scripts/moment.min.js",
                "~/Scripts/validator.min.js",
                "~/Scripts/fastclick.min.js",
                "~/Scripts/adminlte.js",
                "~/Scripts/init.js"));
        }
    }
}
