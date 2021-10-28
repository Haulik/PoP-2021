type suit = Hearts | Diamonds | Clubs | Spades

type rank = Two | Three | Four | Five | Six
          | Seven | Eight | Nine | Ten
          | Jack | Queen | King | Ace

type card = rank * suit

let succSuit (suit:suit) : suit option =
    match suit with
        | Hearts -> Some Diamonds
        | Diamonds -> Some Clubs
        | Clubs -> Some Spades
        | Spades -> None

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

let succCard (card:card) : card option =
    match card with
        | (Ace,Spades) -> None
        | _ -> match (succRank (fst card), succSuit (snd card)) with
                | (None, None) -> None
                | (Some rank, None) -> Some (rank, Hearts)
                | (None, Some suit) -> Some (Two,suit)
                | (Some rank, Some suit) -> Some (rank, suit)


let initDeck (x:unit) : card list =





printfn "%A" (succCard (King, Spades))