module webshenanigans.WebCalls

open Local.FSharp.Web
open webshenanigans.Preamble
open FSharp.Data

let getSyncResponse uri =
    try
        let r = Http.RequestString(uri)
                |> ApiResponse.Parse
        ()
    with
        | ex -> match ex with
                | _ -> ()

//let getAccessors =
//    sprintf "%s/accessors/all" Setting.ApiRootOntologyTypeahead |> 