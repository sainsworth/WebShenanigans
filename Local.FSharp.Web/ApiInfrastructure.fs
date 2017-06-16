module webshenanigans.ApiInfrastructure

open System
open System.Web.Http.Dispatcher
open System.Web.Http.Controllers
open webshenanigans.Controllers
open webShenanigans.TypeaheadService
open System


  let (|TypeaheadValuesController|_|) type' =
    if type' = typeof<TypeaheadValuesController> then
//      let tas = new DummyTypeAheadService()
      let tas = new OntologyTypeAheadService()
      let typeaheadValuesController = new TypeaheadValuesController(tas)
      Some (typeaheadValuesController :> IHttpController)
    else
      None

  type CompositionRoot() =
    interface IHttpControllerActivator with
      member this.Create(request, controllerDescriptor, controllerType) =
        match controllerType with
        | TypeaheadValuesController typeaheadValuesController -> typeaheadValuesController
        | _ -> raise <| ArgumentException((sprintf "Unknown controller type requested: %A" controllerType))