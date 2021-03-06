﻿module webshenanigans.Types

open FSharp.Configuration
open FSharp.Data
open System
open Domain

type Setting = AppSettings<"Web.config">

type ApiResponse = JsonProvider<"Schemas/OntologyApiResponse.json">
type ApiPingResponse = JsonProvider<"Schemas/OntologyPingResponse.json">

type Ontology =
  {
    Accessor: string
    Label: string
  }
  static member from x y = {
      Accessor=x
      Label=y
    }
 
type OntologyItem =
  {
    Id: string
    Label: string
  }
  static member from x y = {
      Id = x
      Label = y
    }

type PingResponse =
  {
    Status: string
    Exception: Exception option
  }
  static member Ok = {
      Status = "OK"
      Exception = None
    }
  static member Failure (x:WebShenanigansError) = 
    {
      Status = "Failure"
      Exception = Some x.AsException
    }

type DataResponse<'T> =
  {
    Status: string
    Data: 'T
    Exception: Exception option
  }
  static member Ok x = {
      Status = "OK"
      Data = x
      Exception = None
    }
  static member Failure (x:WebShenanigansError) = 
    {
      Status = "Failure"
      Data = [] |> List.toSeq
      Exception = Some x.AsException
    }
