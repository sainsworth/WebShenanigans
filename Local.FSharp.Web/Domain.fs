module webshenanigans.Domain

open System
open Microsoft.FSharp.Reflection

let (|NonNull|_|) (a:Nullable<_>) =
  if a.HasValue then Some(a.Value) else None

type WebShenanigansError =
  | WebCallFailureGeneric
  | WebCallFailureException of System.Exception 
  | WebCallFailure of string
  | ParseWebResponseException of System.Exception
  with
    member this.ErrorString =
      let gerErrorName (e:'a) =
        match FSharpValue.GetUnionFields(e, typeof<'a>) with
        | case, _ -> case.Name
      let getErrorString e ex =
        sprintf "%s: %s" (e |> gerErrorName) (ex.ToString())
  
      match this with
      | WebCallFailureException e -> getErrorString this e
      | ParseWebResponseException e -> getErrorString this e
      | _ -> this |> gerErrorName

type Result<'TSuccess> = 
    | Success of 'TSuccess
    | Failure of WebShenanigansError