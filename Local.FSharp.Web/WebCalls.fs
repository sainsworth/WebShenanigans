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

let getValues (a:string) (q:string) =
  queryUri a q
  |> getSyncResponse

let parseResponse x =
    try
        x
        |> ApiResponse.Parse
        |> function x -> x.Response.Data |> Array.toSeq
                                         |> Seq.map (function x -> Ontology.from x.Id x.Label)

        |> Success
    with
      | ex -> ex |> ParseWebResponseException |> Failure

let getAccessors =
  let f = getSyncResponse
          >=> parseResponse
  accessorsUri |> f
