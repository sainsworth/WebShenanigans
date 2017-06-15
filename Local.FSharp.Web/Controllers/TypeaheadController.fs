namespace Local.FSharp.Web.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax
open Local.FSharp.Web
open webshenanigans.Domain
open webshenanigans.Preamble
open webshenanigans.WebCalls
open webshenanigans.Railway
open webShenanigans.ServiceInterfaces

type TypeaheadController(_typeaheadService : ITypeaheadService) =
  inherit Controller()
    member this.Error(e:WebShenanigansError) =
      let ex = new HandleErrorInfo(e.AsException, this.RouteData.Values.Item("controller").ToString(), this.RouteData.Values.Item("action").ToString())
      this.View("Error", ex)
    member this.Status () =
      this.View()
    member this.Index() =
      match _typeaheadService.getTypeaheads () with
      | Success s -> this.View(s)
      | Failure f -> this.Error(f)

//        let p = getAccessors
//                >=> parseResponse
//        let d = Setting.ApiRootOntologyTypeahead
//                |> p
//        match d with
//        | Success s -> this.ViewData.Add("model", s)
//                       this.View()
//        | Failure f -> this.Error(f)
//        this.View( ontologies)