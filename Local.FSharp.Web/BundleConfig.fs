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
                        "~/Scripts/moment.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/typeahead.bundle.js"))
         
        bundles.Add(StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css",
                        "~/Content/sweetalert.css",
                        "~/Content/jquery-ui.css"))