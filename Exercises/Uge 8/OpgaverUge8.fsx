type expr = 
    | Const of int 
    | Add of expr * expr 
    | Mul of expr * expr
    | Sub of expr * expr
    | Div of expr * expr

type ('a ,'b) result = OK of 'a | Err of 'b


// 7ø14 og 7ø15

let rec eval (e:expr) : (int,string) result = 
    match e with 
        | Const c -> OK c
        | Add (a,b) -> 
            match eval a with
                | Err err -> Err err
                | OK aRes -> 
                    match eval b with
                        | Err err -> Err err
                        | OK bRes -> OK (aRes + bRes)
        | Sub (a,b) -> 
            match eval a with
                | Err err -> Err err
                | OK aRes -> 
                    match eval b with
                        | Err err -> Err err
                        | OK bRes -> OK (aRes - bRes)
        | Mul (a,b) -> 
            match eval a with
                | Err err -> Err err
                | OK aRes -> 
                    match eval b with
                        | Err err -> Err err
                        | OK bRes -> OK (aRes * bRes) 
        | Div (a,b) -> 
            match eval a with
                | Err err -> Err err
                | OK aRes -> 
                    match eval b with
                        | Err err -> Err err
                        | OK 0 -> Err "Divide by zero"
                        | OK bRes -> OK (aRes / bRes)

        | _ -> Err "Divide by zero"






printfn "%A" (eval (Sub(Const 3,Mul(Const 2,Const 4))))