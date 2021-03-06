﻿module webShenanigans.ServiceInterfaces

open webshenanigans.Domain
open webshenanigans.Types

type ITypeaheadService =
  abstract member ping: unit -> PingResponse
  abstract member getTypeaheads: unit -> DataResponse<seq<Ontology>>
  abstract member getTypeahead: string * string -> DataResponse<seq<OntologyItem>>