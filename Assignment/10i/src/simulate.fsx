// The length of a vector
let len (x: float, y: float) =
    sqrt(x**2.0 + y**2.0)

// The angle of a vector
let ang (x: float, y: float) =
    System.Math.Atan2(y, x)

// Addition of two vectors
let add (x1:float, y1:float) (x2:float, y2:float)  = 
    x1+x2, y1+y2





type Drone (position:int*int,destination:int*int,speed:int) =
    let mutable speed = speed
    let mutable (x,y) = destination
    let mutable (x1,y1) = position

    member this.Position = (x1,y1)
    member this.Speed = speed
    member this.Destination = (x,y)
    //method
    member this.Fly() = x1 <- x1 + speed; y1 <- y1 + speed
    member this.AtDestination() = ((x,y) = (x1,y1))

type Airspace (drone:Drone list) =
    let mutable Drones = drone
    member this.DroneDist i j = printfn "%A" (Drones.[i].Position)
    member this.FlyDrones = for dro in Drones do printfn "%A" dro.Position 
    member this.AddDrone pos des spe = Drones <- new Drone(pos,des,spe) :: Drones
    member this.WillCollide time = 2



let drone1 = Drone((1,1),(3,3),1)
let drone2 = Drone((1,1),(5,5),1)
let airspace1 = Airspace([drone1;drone2])


printfn "%A and %b" drone1.Position drone1.AtDestination
drone1.Fly
drone1.Fly
printfn "%A and %b" drone1.Position drone1.AtDestination
airspace1.FlyDrones 
airspace1.DroneDist 0
airspace1.AddDrone (2,2) (6,6) 1
printfn " "
airspace1.FlyDrones 
printfn " "
printfn "%A" (int(System.Math.Ceiling(len ((float 6), (float 6)))))




