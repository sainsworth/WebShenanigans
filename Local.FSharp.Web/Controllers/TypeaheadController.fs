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
open webShenanigans.Interfaces

type TypeaheadController(
        _typeaheadService : ITypeaheadService
    ) =
    inherit Controller()
    member this.Error(e:WebShenanigansError) =
        this.View("Error", e.ErrorString)
    member this.Status () =
        this.View()
    member this.Index() =
//        let p = getAccessors
//                >=> parseResponse
//        let d = Setting.ApiRootOntologyTypeahead
//                |> p
//        match d with
//        | Success s -> this.ViewData.Add("model", s)
//                       this.View()
//        | Failure f -> this.Error(f)
        match _typeaheadService.getTypeaheads () with
        | Success s -> this.View(s)
        | Failure f -> this.Error(f)
//        this.View( ontologies)
