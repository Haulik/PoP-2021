type suit = Hearts | Diamonds | Clubs | Spades

type rank = Two | Three | Four | Five | Six
          | Seven | Eight | Nine | Ten
          | Jack | Queen | King | Ace

type card = rank * suit

//7ø4
let succSuit (suit:suit) : suit option =
    match suit with
        | Hearts -> Some Diamonds
        | Diamonds -> Some Clubs
        | Clubs -> Some Spades
        | Spades -> None

//7ø5
let succRank (rank:rank) : rank option =
    match rank with
        | Two -> Some Three
        | Three -> Some Four
        | Four -> Some Five
        | Five -> Some Six
        | Six -> Some Seven
        | Seven -> Some Eight
        | Eight -> Some Nine
        | Nine -> Some Ten
        | Ten -> Some Jack
        | Jack -> Some Queen
        | Queen -> Some King
        | King -> Some Ace
        | Ace -> None


//7ø6
let succCard (card:card) : card option =
    match card with
        | (Ace,Spades) -> None
        | _ -> match (succRank (fst card), succSuit (snd card)) with
                | (None, None) -> None
                | (Some rank, None) -> Some (rank, Hearts)
                | (None, Some suit) -> Some (Two,suit)
                | (Some rank, Some suit) -> Some (rank, suit)

let succCard2 (card:card) : card option =
    match card with
        | (Ace, Spades) -> None
        | (Ace, suit) -> Some (Two, Option.get (succSuit suit))
        | (rank, suit) -> Some (Option.get (succRank rank), suit)

//7ø7
let rec initHelper (c1:card) : card list =
    match (succCard c1) with
        | None -> [c1]
        | Some c2 -> c1 :: (initHelper c2)


let initDeck () : card list =
    let startCard:card = (Two, Hearts)
    initHelper startCard


    

//7ø8
let sameRank (c1:card)  (c2:card) : bool =
   fst c1 = fst c2


//7ø9
let sameSuit (c1:card)  (c2:card) : bool =
   snd c1 = snd c2


//7ø10
let highCard (c1:card) (c2:card) : card =
    let (r1,s1) = c1
    let (r2,s2) = c2  
    printfn "%A & %A: %A" r1 r2 (r1 >= r2)
    match r1 with
        | r when (r >= r2) -> c1
        | _ -> c2
    

    
 //7ø11
let safeDivOption (a:int) (b:int) : int option = 
    match b with
        | 0 -> None
        | _ -> Some(a/b)

type ('a ,'b) result = Ok of 'a | Err of 'b
let safeDivResult (a:int) (b:int) : result<int,string>  =
    match b with
        | 0 -> Err "Divide by zero"
        | _ -> Ok (a/b)



    





//printfn "%A" (succCard (King, Spades))
//printfn "%A" (initDeck())
//printfn "%A" (succCard2 (Ace, Clubs ))
//printfn "%A" (sameRank (Ace, Clubs) (King, Clubs))
printfn "%A" (safeDivOption (2) (2))