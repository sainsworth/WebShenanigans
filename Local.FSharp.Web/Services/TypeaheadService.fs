module webShenanigans.TypeaheadService

open webshenanigans.Domain
open webshenanigans.Railway
open webshenanigans.Types
open webshenanigans.WebCalls
open webShenanigans.ServiceInterfaces

type DummyTypeAheadService () = class end
  with
    interface ITypeaheadService with
//      member x.getTypeaheads() =
//        let data = [ Ontology.from "dummyaccessor" "This is a dummy typeahead source" ]
//        data |> List.toSeq |> Success
      member x.getTypeaheads() =
        let data = [ Ontology.from "dummyaccessor" "This is a dummy typeahead source" ]
        data |> List.toSeq |> DataResponse<seq<Ontology>>.Ok
      member x.getTypeahead (accessor, query) =
        let data = [ Ontology.from "dummyaccessor" "This is a dummy typeahead response"
                     Ontology.from accessor query]
        data |> List.toSeq |> DataResponse<seq<Ontology>>.Ok

type OntologyTypeAheadService () = class end
  with
    interface ITypeaheadService with
//      member x.getTypeaheads() =
//        let p = getAccessors
//                >=> parseResponse
//        Setting.ApiRootOntologyTypeahead
//        |> p
      member x.getTypeaheads() =
        getAccessors
        |> function x -> match x with
                         | Success s -> DataResponse<seq<Ontology>>.Ok s
                         | Failure f -> DataResponse<seq<Ontology>>.Failure f
      member x.getTypeahead (accessor, query) =
        let data = [ Ontology.from "dummyaccessor" "This is a dummy typeahead response"
                     Ontology.from accessor query]
        data |> List.toSeq |> DataResponse<seq<Ontology>>.Ok
        
//        NotYetImplemented |> Failure

//http://blog.tamizhvendan.in/blog/2014/12/10/web-application-development-in-fsharp-using-asp-dot-net-mvc/