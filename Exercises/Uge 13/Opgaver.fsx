

type Person(name:string, address:string, telephone: string) =
    let test = ""
    member this.Name with get() = name
    member this.Address with get() = address
    member this.Telephone with get() = telephone



type Customer(name:string, address:string, telephone: string, mailing:bool) =
    inherit Person(name,address,telephone)
    static let mutable total = 0
    let myID = Customer.NextID()
    member obj.ID = myID
    static member NextID () = total <- total + 1; total
    static member Total = total
    member this.Mailing with get() = mailing


type Account(name:string, account:int, transaction: (string * int) list) =
    let mutable transaction = transaction
    let balance = snd(transaction.Head) + snd((transaction |> List.last))
    member this.Name with get() = name
    member this.Account with get() = account
    member this.Transaction with get() = transaction

    




let customer1 = Customer("Anonymous", "Konges nytorv", "+4579586121", true)
let customer2 = Customer("Asbjorn", "Ved siden af Konges nytorv", "+4568479631", false)
let account1 = 

//printfn "ID: %d, Name: %s, Mailing?: %b" (customer1.ID) (customer1.Name) (customer1.Mailing)
//printfn "ID: %d, Name: %s, Mailing?: %b" (customer2.ID) (customer2.Name) (customer2.Mailing)