module webshenanigans.Domain

open System

let (|NonNull|_|) (a:Nullable<_>) =
  if a.HasValue then Some(a.Value) else None

type WebShenanigansError =
| WebCallFailureGeneric
| WebCallFailureException of System.Exception 
| WebCallFailure of string
| ParseWebResponseException of System.Exception

type Result<'TSuccess> = 
    | Success of 'TSuccess
    | Failure of WebShenanigansError