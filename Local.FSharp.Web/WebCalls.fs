module webshenanigans.WebCalls

open webshenanigans.Domain
open webshenanigans.Railway
open Local.FSharp.Web
open webshenanigans.Preamble
open FSharp.Data

let getSyncResponse uri =
    try
        Http.RequestString(uri)
        |> Success
    with
        | ex -> ex |> WebCallFailureException |> Failure

let getAccessors (x:System.Uri) =
     x.ToString()
     |> sprintf "%slookup/accessors/all"
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

