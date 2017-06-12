namespace Local.FSharp.Web

open FSharp.Configuration
open FSharp.Data

type Setting = AppSettings<"Web.config">

type ApiResponse = JsonProvider<"Schemas/OntologiApiResponse.json">

type BoxItem(id:string, label:string) =
  member this.Id = id
  member this.Label = label
 
//type Ontology(accessor:string, label:string) =
//  member this.Accessor = accessor
//  member this.Label = label
type Ontology = {
    Accessor: string
    Label: string
  }
  with static member from x y = {
      Accessor=x
      Label=y
    }
  