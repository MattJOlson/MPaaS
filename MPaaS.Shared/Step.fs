module MPaaS.Shared.Step

type Step<'S,'F> =
    | Succ of 'S
    | Fail of 'F

let bind (fn : 'A -> Step<'B, 'F>) (a: Step<'A, 'F>) =
    match a with
    | Succ s -> fn s
    | Fail f -> Fail <| f