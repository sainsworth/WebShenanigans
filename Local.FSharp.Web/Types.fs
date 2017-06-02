namespace Local.FSharp.Web

open FSharp.Configuration
open FSharp.Data

type Setting = AppSettings<"Web.config">

type ApiResponse = JsonProvider<"Schemas/OntologiApiResponse.json">

type BoxItem(id:string, label:string) =
  member this.Id = id
  member this.Label = label
  
