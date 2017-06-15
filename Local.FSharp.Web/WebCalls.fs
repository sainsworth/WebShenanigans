module webshenanigans.WebCalls

open FSharp.Data

open webshenanigans.Domain
open webshenanigans.Types

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

