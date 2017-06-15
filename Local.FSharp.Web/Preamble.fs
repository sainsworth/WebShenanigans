module webshenanigans.Preamble

open webshenanigans.Types

let accessorsUri = Setting.ApiRootOntologyTypeahead.ToString() |> sprintf "%s/accessors/all" 