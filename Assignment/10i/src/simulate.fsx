let ToInt (float:float)  = 
    int(System.Math.Ceiling float)

// The length of a vector
let len (x: float, y: float) =
    sqrt(x**2.0 + y**2.0)
    //ToInt (sqrt(x**2.0 + y**2.0))

// The angle of a vector
let ang (x: float, y: float) =
    ToInt(System.Math.Atan2(y, x))

// Addition of two vectors
let add (x1:float, y1:float) (x2:float, y2:float)  = 
    x1+x2, y1+y2

// Sub of two vectors
let sub (x1:float, y1:float) (x2:float, y2:float)  = 
    x1-x2, y1-y2

let getCharForNumber(i:int) =
    if i > 0 && i < 27 then
        char(i)
    else
        'a'





(*printfn "%A" (len(1.0,1.0))
printfn "%A test" (len(4.0,4.0))
printfn "%A test" ((len(4.0,4.0)) - (len(1.0,1.0)))
printfn "%A test" (len( sub (4.0,4.0) (1.0,1.0)))
printfn "%A" (len(1.0,2.0))
//printfn "%A" (len(2.0,2.0))
//printfn "%A" (len(add (1.0,1.0) (4.0,4.0)))
*)



type Drone (position:int*int,destination:int*int,speed:int) =
    let mutable speed = speed
    let mutable (x,y) = destination
    let mutable (x1,y1) = position
    let mutable distance = ToInt(len(sub(float x1, float y1)(float x,float y)))
    

    //properties
    member this.Position with get () = (x1,y1)
    member this.Speed with get () = speed
    member this.Destination with get () = (x,y)
    //method
    member this.Fly() =
        //if ((x1+y1) - (x+y)) < speed && ((x1+y1) - (x+y)) > -speed then
        if (x1 - x) > speed || (y1 - y) > speed && (x1 - x) < -speed || (y1 - y) < -speed then
            speed <- 1
        for i=speed-1 downto 0 do
            if (x1 - x) <> 0 then
                if ((x1 - x) < 0) then
                    x1 <- speed + x1
                else 
                    x1 <- x1 - speed
            else
                if ((y1 - y) < 0) then
                    y1 <- speed + y1
                else 
                    y1 <- y1 - speed
    member this.AtDestination() = 
        ((x,y) = (x1,y1))

type Airspace (drone:Drone list) =
    let mutable Drones = drone
    
    member this.DroneDist(i:Drone, j:Drone) = 
        ToInt(len(sub(float(fst(i.Position)), float(snd(i.Position))) (float(fst(j.Position)), float(snd(j.Position)))))
    member this.FlyDrones() = for dro in Drones do dro.Fly()
    member this.AddDrone(pos, des, spe) = Drones <- new Drone(pos,des,spe) :: Drones
    member this.WillCollide(time) = 
        let mutable list = []
        for i=0 to time do
            this.FlyDrones()
        for i = 0 to drone.Length - 2 do
            printfn "%A" (i)
            if this.DroneDist(drone.Item(i), drone.Item(i+1)) <= 5 then
                list <- list @ [i;i+1] //[drone.Item(i);drone.Item(i+1)] 
        list
                        





let drone1 = Drone((1,1),(4,4),2)
let drone2 = Drone((1,1),(1,1),2)
let drone3 = Drone((43,23),(1,1),2)
let drone4 = Drone((43,23),(1,1),2)
let airspace1 = Airspace([drone1;drone2;drone3;drone4])
printfn "%A how many: " (airspace1.WillCollide(3))






