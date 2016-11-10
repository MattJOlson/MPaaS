module MPaaS.Tests.StepTests

open NUnit.Framework
open FsUnit

open System
open MPaaS.Shared.Step

let makeZs n =
    if n < 0 then Fail "zomg"
    else String.init n (fun i -> "z") |> Succ

[<Test>]
let ``bind works on Succ`` () =
    match (Succ 3) |> bind makeZs with
    | Succ s -> s |> should equal "zzz"
    | Fail f -> failwith "bind should pass Succ"

[<Test>]
let ``bind allows its fn arg to fail`` () =
    match (Succ -7) |> bind makeZs with
    | Succ s -> failwith "bind should allow failure"
    | Fail f -> f |> should equal "zomg"

[<Test>]
let ``bind passes through Fail`` () =
    match (Fail "doh") |> bind makeZs with
    | Succ s -> failwith "bind should pass Fail"
    | Fail f -> f |> should equal "doh"