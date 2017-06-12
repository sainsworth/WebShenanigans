module webShenanigans.Services

open Local.FSharp.Web
open webshenanigans.Domain
open webshenanigans.Railway
open webShenanigans.Interfaces
open webshenanigans.WebCalls

type DummyTypeAheadService () = class end
  with
    interface ITypeaheadService with
      member x.getTypeaheads() =
        let data = [ Ontology.from "dummyaccessor" "This is a dummy typeahead source" ]
        data |> List.toSeq |> Success

type OntologyTypeAheadService () = class end
  with
    interface ITypeaheadService with
      member x.getTypeaheads() =
        let p = getAccessors
                >=> parseResponse
        Setting.ApiRootOntologyTypeahead
        |> p
        
//        NotYetImplemented |> Failure