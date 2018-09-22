using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace ControleEstoque.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //AdminLTE
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/DataTables-1.10.18/css/dataTables.bootstrap.min.css")
                .Include("~/Content/Buttons-1.5.2/css/buttons.bootstrap.min.css")
                .Include("~/Content/css/bootstrap-select.css")
                .Include("~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/skins/skin-blue.css"));

            ////DataTables
            //bundles.Add(new StyleBundle("~/Bundles/DataTables/css").Include(
            //          "~/Content/DataTables-1.10.18/css/dataTables.bootstrap.min.css",
            //          "~/Content/Buttons-1.5.2/css/buttons.bootstrap.min.css"));

            //DataTables
            bundles.Add(new ScriptBundle("~/Bundles/DataTables/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Content/pdfmake-0.1.36/pdfmake.min.js",
                "~/Content/pdfmake-0.1.36/pdfmake.min.js",
                "~/Content/pdfmake-0.1.36/vfs_fonts.js",
                "~/Content/DataTables-1.10.18/js/jquery.dataTables.min.js",
                "~/Content/DataTables-1.10.18/js/dataTables.bootstrap.min.js",
                "~/Content/Buttons-1.5.2/js/dataTables.buttons.min.js",
                "~/Content/Buttons-1.5.2/js/buttons.bootstrap.min.js",
                "~/Content/Buttons-1.5.2/js/buttons.flash.min.js",
                "~/Content/Buttons-1.5.2/js/buttons.html5.js"));


            //AdminLTE
            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Scripts/bootbox.min.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Content/js/init.js"));


#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
