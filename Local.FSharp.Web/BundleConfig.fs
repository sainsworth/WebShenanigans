namespace Local.FSharp.Web

open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Mvc
open System.Web.Routing
open System.Web.Optimization

type BundleConfig() =
    static member RegisterBundles (bundles:BundleCollection) =
        bundles.Add(ScriptBundle("~/bundles/jquery").Include([|"~/Scripts/jquery-{version}.js"|]))

        bundles.Add(ScriptBundle("~/bundles/modernizr").Include([|"~/Scripts/modernizr-*"|]))

        bundles.Add(ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Scripts/moment.js"))
         
        //Bootstrap wins with it's map to the less files: so not all these stylings are applied...
        bundles.Add(StyleBundle("~/Content/jquery-ui-css").Include([|"~/Scripts/jquery-ui-*"|]))

        bundles.Add(StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css",
                        "~/Content/sweetalert.css"))