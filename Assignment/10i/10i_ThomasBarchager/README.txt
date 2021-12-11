How to create simulate.dll
First locate src folder using terminal/cmd
Type:
fsharpc -a simulate.fs

How to compile and run testSimulate.fsx
First locate src folder using terminal/cmd
Type to compile:
fsharpc -r simulate.dll testSimulate.fsx
To run testSimulate type the following:
mono testSimulate.exe 


Example:

Blackbox test of class Drone
New drone1 = Drone((1,1),(55,55),1)
Test of properties get()                             Result:(1, 1), (55, 55), 1   Expected: (1,1), (55,55), 1      |passed: true 
fly() with speed 1                                   Result: (2, 1)               Expected: (2,1)                  |passed: true
AtDestination() position (2,1) destination(55,55)    Result: false                Expected: flase                  |passed: true

New drone2 = Drone((7,3),(74,86),6)
Test of properties get()                             Result:(7, 3), (74, 86), 6   Expected: (7,3), (74,86), 6     |passed: true
fly() with speed 6                                   Result: (13, 3)              Expected: (8,3)                 |passed: true 
AtDestination() position (8,3) destination(74,86)    Result: false                Expected: flase                 |passed: true

New drone3 = Drone((8,4),(28,4),20)
Test of properties get()                             Result:(8, 4), (28, 4), 20    Expected: (8,4), (28,4), 20       |passed: true
fly() with speed 20                                  Result: (28, 4)               Expected: (28,4)                  |passed: true
AtDestination() position (28,4) destination(28,4)    Result: true                  Expected: True                    |passed: true

Blackbox test of class Airspace
New airspace1 = Airspace([drone1;drone2;drone3])
Test DroneDist() on (2,1) and (13,3)                  Result:12                             Expected: 12                               |passed: true
Test FlyDrones() on (2,1), (13,3) (28,4)              Result:(3, 1), (19, 3), (28, 4)       Expected: (3,1), (19,3), (28,4)            |passed: true 
Test WillCollide(2)                                   Result:[]                             Expected: []                               |passed: true
Test WillCollide(5)                                   Result:[('A', 'D')]                   Expected: [('A', 'D')]                     |passed: true
Test if three drones Collide     Result:[('A', 'D'); ('E', 'F'); ('E', 'G'); ('F', 'G')]   Expected: [('A', 'D'); ('E', 'F'); ('E', 'G'); ('F', 'G')]      |passed: true