type expr = 
    | Const of int 
    | Add of expr * expr 
    | Mul of expr * expr
    | Sub of expr * expr
    | Divide of expr * expr

type ('a ,'b) result = Ok of 'a | Err of 'b


// 7ø14 og 7ø15

// let rec eval (e:expr) : Result<int,string> = 
//     match e with 
//     | Add (a,b) -> Ok (eval a) + (eval b) 
//     | Sub (a,b) -> Ok (eval a) - (eval b) 
//     | Mul (a,b) -> Ok (eval a) * (eval b)
//     | Divide (a,b) -> Ok (eval a) / (eval b)
//     | Const n -> n
//     | 0 -> Err "Divide by zero"






printfn "%A" (eval (Sub(Const 3,Mul(Const 2,Const 4))))