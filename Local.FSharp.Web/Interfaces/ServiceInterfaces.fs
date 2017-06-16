module webShenanigans.ServiceInterfaces

open webshenanigans.Domain
open webshenanigans.Types

type ITypeaheadService =
//  abstract member getTypeaheads: unit -> Result<seq<Ontology>>
  abstract member getTypeaheads: unit -> DataResponse<seq<Ontology>>
  abstract member getTypeahead: string * string -> DataResponse<seq<Ontology>>