type 'a tree = 
| Leaf of 'a 
| Tree of 'a tree * 'a tree


let rec sum (t:int tree) : int =
    match t with
    | Leaf x -> x
    | Tree (t1,t2) -> sum t1 + sum t2

let rec leafs (l:'a tree) : int =
    match l with
    | Leaf x -> 1
    | Tree (t1,t2) -> leafs t1 + leafs t2


let rec find (func:'a -> bool) (t:'a tree) :'a option =
    match t with
    | 
    | Tree (t1, t2) -> (find func t1) (find func t2)
    | _ -> None


printfn "%A" (sum(Tree (Tree (Leaf 1, Leaf 2), Leaf 3)))
printfn "%A" (leafs(Tree (Tree (Leaf 1, Leaf 2), Leaf 3)))