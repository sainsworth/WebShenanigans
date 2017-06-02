module webshenanigans.Preamble

open Local.FSharp.Web

let accessorsUri = Setting.ApiRootOntologyTypeahead.ToString() |> sprintf "%s/accessors/all" 