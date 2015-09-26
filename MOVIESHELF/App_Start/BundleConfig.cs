﻿using System.Web;
using System.Web.Optimization;

namespace MOVIESHELF
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/ScriptMovieShelf").Include(
                        "~/Scripts/MovieShelf.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.11.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryraty").Include(
                        "~/Scripts/jquery.raty.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryrateit").Include(
                       "~/Scripts/jquery.rateit.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.8.3"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            
            bundles.Add(new StyleBundle("~/Content/css_main").Include("~/Content/main.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/rateit").Include("~/Content/rateit.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}