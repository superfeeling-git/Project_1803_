using System.Web;
using System.Web.Optimization;

namespace Project_1803
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Content/js/jquery*"));


            bundles.Add(new StyleBundle("~/Content/style").Include(
                      "~/Content/css/style*"));

            ///BundleTable.EnableOptimizations = false;
        }
    }
}
