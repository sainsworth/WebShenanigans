namespace Local.FSharp.Web

open System
open webShenanigans
open System.Web.Mvc
open Local.FSharp.Web.Controllers
open webShenanigans.Services

module MvcInfrastructure =

  let (|HomeController|_|) type' =
    if type' = typeof<HomeController> then
      let homeController = new HomeController()
      Some (homeController :> IController)
    else
      None
  
  let (|TypeaheadController|_|) type' =
    if type' = typeof<TypeaheadController> then
      let otas = new OntologyTypeAheadService()
      let typeaheadController = new TypeaheadController(otas)
      Some (typeaheadController :> IController)
    else
      None

  type CompositionRoot() =          
    inherit DefaultControllerFactory() with
      override this.GetControllerInstance(requestContext, controllerType) = 
        let anonymousId = requestContext.HttpContext.Request.AnonymousID
        match controllerType with
        | HomeController homeController -> homeController
        | TypeaheadController typeaheadController -> typeaheadController  
        | _ -> raise <| ArgumentException((sprintf "Unknown controller type requested: %A" controllerType))