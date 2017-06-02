﻿namespace Local.FSharp.Web.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax
open Local.FSharp.Web

type PartialController() =
    inherit Controller()
    member this.BlueBox (id:string, label:string) = this.PartialView("_BlueBox", new BoxItem(id, label))