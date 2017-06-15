module webShenanigans.ServiceInterfaces

open webshenanigans.Domain
open webshenanigans.Types

type ITypeaheadService =
  abstract member getTypeaheads: unit -> Result<seq<Ontology>>
