type Car (economy:float,year:int,make:string) =
    let mutable fuel = 0.0
    let mutable speed = 0
    member this.yearOfModel = year
    member this.Make = make
    member this.Economy = economy 
    member this.addGas gas = fuel <- fuel + gas
    member this.gasLeft = fuel
    member this.drive km =  fuel <- fuel - km*economy; if fuel < 0.0 then raise(new System.InvalidOperationException("Not enough gas"))
    member this.accelerate = speed <- speed + 5; fuel <- fuel - 1.0
    member this.brake = speed <- speed - 5; fuel <- fuel - 1.0
    member this.getSpeed = speed 



let car1 = Car(5.0,2026,"F")

car1.addGas 60.0
car1.accelerate
car1.accelerate
car1.accelerate
printfn "%A and %A" car1.gasLeft car1.getSpeed
car1.accelerate
car1.accelerate
printfn "%A and %A" car1.gasLeft car1.getSpeed
car1.brake
car1.brake
car1.brake
printfn "%A and %A" car1.gasLeft car1.getSpeed
car1.brake
car1.brake
printfn "%A and %A" car1.gasLeft car1.getSpeed