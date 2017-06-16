namespace webshenanigans.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http

open webshenanigans.Types
open webShenanigans.ServiceInterfaces

/// Retrieves values.
[<RoutePrefix("values/typeahead")>]
type TypeaheadValuesController(_typeaheadService : ITypeaheadService) =
    inherit ApiController()

    [<Route"ping">]
    member x.GetPing() : IHttpActionResult =
      let data = _typeaheadService.ping ()
      x.Ok(data) :> _

    [<Route("alltypeaheads")>]
    member x.GetAll() : IHttpActionResult =
      let data = _typeaheadService.getTypeaheads ()
      x.Ok(data) :> _

    [<Route("{accessor}/{query}")>]
    member x.GetQuery(accessor,query) : IHttpActionResult =
      let data = _typeaheadService.getTypeahead (accessor, query)
      x.Ok(data) :> _

//        if id > values.Length - 1 then
//            x.BadRequest() :> _
//        else x.Ok(values.[id]) :> _