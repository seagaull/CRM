
using System.Web.Optimization;

namespace Overtime.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles").Include(
                "~/Content/style/bootstrap.css",
                   "~/Content/style/bootstrapRTL.css",
                    "~/Content/style/bootstrapCustom.css",
                "~/Content/style/font-awesome.css"));

            bundles.Add(new StyleBundle("~/style/front").Include
                ("~/Content/style/site/Site.css"));

            bundles.Add(new StyleBundle("~/style/back").Include
                ("~/Content/style/admin/Site.css"));


            bundles.Add(new ScriptBundle("~/scripts").Include(
                "~/Scripts/jquery-2.1.3.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/plugin.js"));
            bundles.Add(new ScriptBundle("~/admin/scripts").Include(
             
           
              "~/Areas/Admin/Scripts/Adminplugin.js"));
        }

    }
}