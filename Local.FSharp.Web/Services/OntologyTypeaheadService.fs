module webShenanigans.Services

open Local.FSharp.Web
open webshenanigans.Domain
open webshenanigans.Railway
open webShenanigans.Interfaces

type OntologyTypeAheadService () = class end
  with
    interface ITypeaheadService with
    member x.getTypeaheads() =
      let data = [ Ontology.from "1" "one"
                   Ontology.from "2" "two" ]
      data |> List.toSeq |> Success