type student(name:string) =
    let mutable name = name
    member this.Name = name
    member this.getValue = name
    member this.setValue navn = name <- navn 

let student1 = student("Claus")
let student2 = student("Mark")

//printfn "First: %A Now we change with setvalue %A %A" student1.Name (student1.setValue "Tim") student1.getValue


type Counter() =
    let mutable counter = 0
    member this.get = counter
    member this.incr = counter <- counter + 1


let number = Counter()
(*
printfn "%A" number.get 
number.incr
printfn "%A" number.get *)


(*type Car =
| KmLiter of float
| Liters of int*)


type Car(economy:float) =
    //let mutable km = 0
    let mutable fuel = 0.0
    member this.Economy = economy 
    //member this.Amountfuel = fuel
    member this.addGas gas = fuel <- fuel + gas
    member this.gasLeft = fuel
    member this.drive km =  fuel <- fuel - km*economy; if fuel < 0.0 then raise(new System.InvalidOperationException("Not enough gas")) 


let car1 = Car(5.0)

(*
printfn "%A" car1.gasLeft
car1.addGas 9.0
printfn "%A" car1.gasLeft
car1.drive 3.0
printfn "%A" car1.gasLeft
car1.drive 3.0*)


type Moth(location:float*float) =
    let mutable (x,y) = location
    member this.Light = (0.0,0.0) 
    member this.getPosition = (x,y)
    member this.moveToLight = x <- x/2.0; y <- y/2.0


let moth1 = Moth(6.0,6.0)

printfn "%A" moth1.getPosition
moth1.moveToLight
printfn "%A" moth1.getPosition
moth1.moveToLight
moth1.moveToLight
moth1.moveToLight
moth1.moveToLight
moth1.moveToLight
moth1.moveToLight
moth1.moveToLight
moth1.moveToLight
printfn "%A" moth1.getPosition