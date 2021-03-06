﻿module webShenanigans.TypeaheadService

open webshenanigans.Domain
open webshenanigans.Railway
open webshenanigans.Types
open webshenanigans.WebCalls
open webShenanigans.ServiceInterfaces

let internalToExternalPing (x:Result<unit>) =
  match x with
  | Success s -> PingResponse.Ok
  | Failure f -> PingResponse.Failure f

let internalToExternalSeq (x:Result<seq<'a>>) =
  match x with
  | Success s -> DataResponse<'a>.Ok s
  | Failure f -> DataResponse<'a>.Failure f

type DummyTypeAheadService () = class end
  with
    interface ITypeaheadService with
//      member x.getTypeaheads() =
//        let data = [ Ontology.from "dummyaccessor" "This is a dummy typeahead source" ]
//        data |> List.toSeq |> Success
      member x.ping () =
        PingResponse.Ok
      member x.getTypeaheads() =
        let data = [ Ontology.from "dummyaccessor" "This is a dummy typeahead source" ]
        data |> List.toSeq |> DataResponse<seq<Ontology>>.Ok
      member x.getTypeahead (accessor, query) =
        let data = [ OntologyItem.from "dummyaccessor" "This is a dummy typeahead response"
                     OntologyItem.from accessor query]
        data |> List.toSeq |> DataResponse<seq<OntologyItem>>.Ok

type OntologyTypeAheadService () = class end
  with
    interface ITypeaheadService with
      member x.ping () =
        pingApi |> internalToExternalPing
      member x.getTypeaheads() =
        getAccessors
        |> internalToExternalSeq
      member x.getTypeahead (accessor, query) =
        getValues accessor query
        |> internalToExternalSeq

        
//        NotYetImplemented |> Failure

//http://blog.tamizhvendan.in/blog/2014/12/10/web-application-development-in-fsharp-using-asp-dot-net-mvc/