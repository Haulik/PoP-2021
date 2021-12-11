///<summary>Converts an float to the math.ceiling as an int</summary>
///<param name="float">An float to be converted to a Int</param>
///<returns>Returns and Int</returns>
let ToInt (float:float)  = 
    int(System.Math.Ceiling float)

///<summary>Calculates the length of a vector</summary>
///<param name="x,y">A tuble of floats</param>
///<returns>The calculated lenght of a vector</returns>
let len (x: float, y: float) =
    sqrt(x**2.0 + y**2.0)

///<summary>Calculates the Subtraction of two vectors</summary>
///<param name="x1,y)">A tuble of floats</param>
///<param name="x2,y2">A tuble of floats</param>
///<returns>Returns the Subtraction of two vectors</returns>
let sub (x1:float, y1:float) (x2:float, y2:float)  = 
    x1-x2, y1-y2

///<summary>Converts a int to char, from a list of char [a..z]</summary>
///<param name="i">An integer</param>
///<returns>Returns the char of index[i]</returns>
let getCharForNumber i =
    let list = ['A'..'Z']
    list.[i]



type Drone (position:int*int,destination:int*int,speed:int) =
    let mutable speed = speed
    let mutable (x,y) = destination
    let mutable (x1,y1) = position
    let mutable distance = ToInt(len(sub(float x1, float y1)(float x,float y)))

    member this.Position with get () = (x1,y1)
    member this.Speed with get () = speed
    member this.Destination with get () = (x,y)

    ///<summary></summary>
    member this.Fly() =
        //if ((x1+y1) - (x+y)) < speed && ((x1+y1) - (x+y)) > -speed then
        if (x1 - x) > speed || (y1 - y) > speed && (x1 - x) < -speed || (y1 - y) < -speed then
            speed <- speed
        for i=speed-1 downto 0 do
            if (x1 - x) <> 0 then
                if ((x1 - x) < 0) then
                    x1 <- 1 + x1
                else 
                    x1 <- x1 - 1
            else
                if ((y1 - y) < 0) then
                    y1 <- 1 + y1
                else 
                    y1 <- y1 - 1

    ///<summary>Checks if the drone have reached is destination</summary>>
    ///<returns>Return a bool</returns>
    member this.AtDestination() = 
        ((x,y) = (x1,y1))

type Airspace (drone:Drone list) =
    let mutable Drones = drone
    
    ///<summary>Calculates the distance between two drones</summary>
    ///<param name="i">An as a drone</param>
    ///<param name="j">An as a drone</param>
    ///<returns>Returns the calculated distance between two drones as an Integer</returns>
    member this.DroneDist(i:Drone, j:Drone) = 
        ToInt(len(sub(float(fst(i.Position)), float(snd(i.Position))) (float(fst(j.Position)), float(snd(j.Position)))))
    
    ///<summary>Makes all drones in the list of drones fly one time</summary>
    member this.FlyDrones() = for dro in Drones do dro.Fly()
    
    ///<summary>Adds a new drone to list of drones</summary>
    ///<param name="pos">The position of the drone as a Integer</param>
    ///<param name="des">The destination of a drone as a Integer</param>
    ///<param name="spe">The speed of a drone as a Integer</param>
    member this.AddDrone(pos, des, spe) = Drones <- Drones @ [new Drone(pos,des,spe)]
    
    ///<summary>determine which drones will collide after a given time</summary>
    ///<param name="time">Time number of minutes as a Integer</param>
    ///<returns>return a list of pairs of drones</returns>
    member this.WillCollide(time) = 
        let mutable list = []
        for i=0 to time do
            this.FlyDrones()
        for i = 0 to Drones.Length - 1 do
            for j = i+1 to Drones.Length - 1 do
                if this.DroneDist(Drones.Item(i), Drones.Item(j)) <= 5 then
                    list <- list @ [(getCharForNumber i, getCharForNumber j)]
        list
                        





(*let drone1 = Drone((1,1),(55,55),2)
let drone2 = Drone((1,1),(55,55),2)
let drone3 = Drone((1,1),(5,5),1)
let drone4 = Drone((3,3),(1,1),1)
let airspace1 = Airspace([drone1;drone2;drone3;drone4])
printfn "%A how many: " (airspace1.WillCollide(3))
airspace1.AddDrone((43,23),(1,1),2)

printfn "%A how many: " (airspace1.WillCollide(3))
*)




let drone1 = Drone((1,1),(55,55),1)
let drone2 = Drone((7,3),(74,86),6)
let drone3 = Drone((8,4),(28,4),20)

printfn "Blackbox test of class Drone"
printfn "New drone1 = Drone((1,1),(55,55),1)" 
printfn "Test of properties get()                             Result:%A, %A, %d   Expected: (1,1), (55,55), 1      |passed: %b " (drone1.Position) (drone1.Destination) (drone1.Speed) (drone1.Position = (1,1) && drone1.Destination = (55, 55) && drone1.Speed = 1)
drone1.Fly()
printfn "fly() with speed 1                                   Result: %A               Expected: (2,1)                  |passed: %b " (drone1.Position) (drone1.Position = (2,1))
printfn "AtDestination() position (2,1) destination(55,55)    Result: %b                Expected: flase                  |passed: %b " (drone1.AtDestination()) (drone1.AtDestination() = false)
printfn ""

printfn "New drone2 = Drone((7,3),(74,86),6)" 
printfn "Test of properties get()                             Result:%A, %A, %d   Expected: (7,3), (74,86), 6     |passed: %b " (drone2.Position) (drone2.Destination) (drone2.Speed) (drone2.Position = (7,3) && drone2.Destination =(74,86) && drone2.Speed = 6)
drone2.Fly()
printfn "fly() with speed 6                                   Result: %A              Expected: (8,3)                 |passed: %b " (drone2.Position) (drone2.Position = (13,3))
printfn "AtDestination() position (8,3) destination(74,86)    Result: %b                Expected: flase                 |passed: %b " (drone2.AtDestination()) (drone2.AtDestination() = false)
printfn ""

printfn "New drone3 = Drone((8,4),(28,4),20)" 
printfn "Test of properties get()                             Result:%A, %A, %d    Expected: (8,4), (28,4), 20       |passed: %b " (drone3.Position) (drone3.Destination) (drone3.Speed) (drone3.Position = (8,4) && drone3.Destination = (28,4) && drone3.Speed = 20)
drone3.Fly()
printfn "fly() with speed 20                                  Result: %A               Expected: (28,4)                  |passed: %b " (drone3.Position) (drone3.Position = (28,4))
printfn "AtDestination() position (28,4) destination(28,4)    Result: %b                  Expected: True                    |passed: %b " (drone3.AtDestination()) (drone3.AtDestination() = true)
printfn ""


let airspace1 = Airspace([drone1;drone2;drone3])
printfn "Blackbox test of class Airspace"
printfn "New airspace1 = Airspace([drone1;drone2;drone3])"

printfn "Test DroneDist() on (2,1) and (13,3)                  Result:%d                             Expected: 12                               |passed: %b " (airspace1.DroneDist(drone1,drone2))  (airspace1.DroneDist(drone1,drone2) = 12)
airspace1.FlyDrones()
printfn "Test FlyDrones() on (2,1), (13,3) (28,4)              Result:%A, %A, %A       Expected: (3,1), (19,3), (28,4)            |passed: %b " (drone1.Position) (drone2.Position) (drone3.Position)  (drone1.Position = (3,1) && drone2.Position = (19,3) && drone3.Position = (28,4))
printfn "Test WillCollide(2)                                   Result:%A                             Expected: []                               |passed: %b" (airspace1.WillCollide(2)) (airspace1.WillCollide(2) = [])
airspace1.AddDrone((5,1),(55,55),1)
printfn "Test WillCollide(5)                                   Result:%A                   Expected: [('A', 'D')]                     |passed: %b" (airspace1.WillCollide(5)) (airspace1.WillCollide(2) = [('A', 'D')])
airspace1.AddDrone((1000,20),(37,96),4)
airspace1.AddDrone((1000,20),(85,56),4)
airspace1.AddDrone((1000,20),(32,64),4)
let ext = [('A', 'D'); ('E', 'F'); ('E', 'G'); ('F', 'G')]
printfn "Test if three drones Collide     Result:%A   Expected: %A      |passed: %b" (airspace1.WillCollide(1)) (ext) (airspace1.WillCollide(2) = [('A', 'D'); ('E', 'F'); ('E', 'G'); ('F', 'G')])
airspace1.AddDrone








