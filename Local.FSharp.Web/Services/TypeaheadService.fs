module webShenanigans.TypeaheadService

open webshenanigans.Domain
open webshenanigans.Railway
open webshenanigans.Types
open webshenanigans.WebCalls
open webShenanigans.ServiceInterfaces

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

//http://blog.tamizhvendan.in/blog/2014/12/10/web-application-development-in-fsharp-using-asp-dot-net-mvc/