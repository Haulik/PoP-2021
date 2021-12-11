module DroneSim

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

    ///<summary>Make the drone fly with its speed: if speed is 1, the drone move one coordinate - so (1,1) to (10,10) with speed of 1 would be (2,1)</summary>
    member this.Fly() =
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