using System.Web.Optimization;

namespace Overtime.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles").Include(
                 "~/Content/jquery.jqGrid/ui.jqgrid.css",
                "~/Content/style/bootstrap.css",
                "~/Content/style/bootstrapRTL.css",
                "~/Content/style/bootsnipp.css",
                "~/Content/style/bootstrapCustom.css",
                "~/Content/style/font-awesome.css",
                "~/Content/themes/base/all.css"
                
                ));

            bundles.Add(new StyleBundle("~/style/front").Include
                ("~/Content/style/site/Site.css"));

            bundles.Add(new StyleBundle("~/style/back").Include
                ("~/Content/style/admin/Site.css"));


            bundles.Add(new ScriptBundle("~/scripts").Include(
                "~/Scripts/jquery-2.1.3.js",
                "~/Scripts/jquery-ui-1.11.4.js",
                "~/Scripts/jquery.validate.js",
               "~/Scripts/jquery.validate.unobtrusive.js",
                 "~/Scripts/i18n/grid.locale-ar.js",
                 "~/Scripts/jquery.jqGrid.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootsnipp.js",
                "~/Scripts/plugin.js"));
            bundles.Add(new ScriptBundle("~/admin/scripts").Include(
                "~/Areas/Admin/Scripts/Adminplugin.js"));
        }
    }
}