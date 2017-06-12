module webShenanigans.Interfaces

open Local.FSharp.Web
open webshenanigans.Domain
open webshenanigans.Railway

type ITypeaheadService =
  abstract member getTypeaheads: unit -> Result<seq<Ontology>>
