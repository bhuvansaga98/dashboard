using System.Web;
using System.Web.Optimization;

namespace Litmus.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/extra/*.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/script/spa").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/ngStorage.js",
                        "~/Scripts/ocLazyLoad.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/angular-*",
                        "~/Scripts/vendors/*.js",
                        "~/js/app.js",
                        "~/Scripts/modules/*.js",
                        "~/js/config.js",
                        "~/js/config.*",
                        "~/js/main.js",
                        "~/js/services/*.js",
                        "~/js/filters/*.js",
                        "~/js/directives/*.js",
                        "~/js/controllers/*.js"
                ).IncludeDirectory("~/js/app/", "*.js", true));

            bundles.Add(new ScriptBundle("~/Script/jquery-{version}.js").Include(
                      "~/Script/bootstrap.css",
                      "~/Script/extra/*.css",
                      "~/Script/site.css"));
        }
    }
}
