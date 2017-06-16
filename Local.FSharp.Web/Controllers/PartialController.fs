namespace webshenanigans.Controllers

//open System
//open System.Collections.Generic
//open System.Linq
//open System.Web
open System.Web.Mvc
//open System.Web.Mvc.Ajax
open webshenanigans.Types

type PartialController() =
    inherit Controller()
    member this.BlueBox (id:string, label:string) = 
      let oi = OntologyItem.from id label
      this.PartialView("_BlueBox", oi)