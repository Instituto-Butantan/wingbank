using System.Web.Optimization;

namespace MosquitoLab.WingBank
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/vendors/font-awesine-4.7.0/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/Content/vendors/js").Include(
                "~/Content/vendors/jquery.mask/jquery.mask.js",
                "~/Content/vendors/iziModal/iziModal.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/vendors/css").Include(
                "~/Content/vendors/iziModal/iziModal.min.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
