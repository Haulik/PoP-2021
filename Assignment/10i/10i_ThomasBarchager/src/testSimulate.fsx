let drone1 = DroneSim.Drone((1,1),(55,55),1)
let drone2 = DroneSim.Drone((7,3),(74,86),6)
let drone3 = DroneSim.Drone((8,4),(28,4),20)

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


let airspace1 = DroneSim.Airspace([drone1;drone2;drone3])
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