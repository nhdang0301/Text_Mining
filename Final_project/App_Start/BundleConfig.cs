using System.Web;
using System.Web.Optimization;

namespace Final_project
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Thêm các tệp CSS vào bundle
            bundles.Add(new StyleBundle("~/Content").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/prettyPhoto.css",
                      "~/Content/price-range.css",
                      "~/Content/animate.css",
                      "~/Content/main.css",
                      "~/Content/responsive.css"));

            // Thêm các tệp JavaScript vào bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.scrollUp.min.js",
                        "~/Scripts/price-range.js",
                        "~/Scripts/jquery.prettyPhoto.js",
                        "~/Scripts/main.js"));

            // Mặc định đã có phần này cho modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
        }


    }
}
