module webshenanigans.WebCalls

open FSharp.Data

open webshenanigans.Domain
open webshenanigans.Railway
open webshenanigans.Types

let accessorsUri = Setting.ApiRootOntologyTypeahead.ToString() |> sprintf "%slookup/accessors/all"

let queryUri a q = Setting.ApiRootOntologyTypeahead.ToString()
                   |> fun x -> sprintf "%slookup/%s/?query=%s" x a q 

let getSyncResponse uri =
    try
        Http.RequestString(uri)
        |> Success
    with
        | ex -> ex |> WebCallFailureException |> Failure

let parseResponse f x =
    try
        x
        |> ApiResponse.Parse
        |> function x -> x.Response.Data |> Array.toSeq
                                         |> Seq.map (function x -> f x.Id x.Label)

        |> Success
    with
      | ex -> ex |> ParseWebResponseException |> Failure

let webcall f =
  getSyncResponse
  >=> parseResponse f

let getAccessors =
  accessorsUri
  |> webcall Ontology.from

let getValues (a:string) (q:string) =
  queryUri a q
  |> webcall OntologyItem.from