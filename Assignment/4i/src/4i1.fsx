open System

printfn "Black-box testing of vec2d.len(x,y)"
printfn "len (2.0, 2.0)       Result: %f     Expected: 2.8284...     |passed: %b: " (vec2d.len(2.0, 2.0)) (Math.Round(vec2d.len(2.0, 2.0),4) = 2.8284)
printfn "len (-2.0, -2.0)     Result: %f     Expected: 2.8284...     |passed: %b: " (vec2d.len(-2.0, -2.0)) (Math.Round(vec2d.len(-2.0, -2.0),4) = 2.8284)
printfn "len (-2.0, 2.0)      Result: %f     Expected: 2.8284...     |passed: %b: " (vec2d.len(-2.0, 2.0)) (Math.Round(vec2d.len(-2.0, 2.0),4) = 2.8284)
printfn "len (150.0, 370.0)   Result: %f   Expected: 399.2493...   |passed: %b: " (vec2d.len(150.0, 370.0)) (Math.Round(vec2d.len(150.0, 370.0),4) = 399.2493)
printfn "len (0, 0)           Result: %f     Expected: 0.0           |passed: %b: " (vec2d.len(0.0, 0.0)) (vec2d.len(0.0, 0.0) = 0.0)

printfn " "

printfn "Black-box testing of vec2d.ang(x,y)"
printfn "ang (2.0, 2.0)       Result: %f     Expected: 0.7854...     |passed: %b: " (vec2d.ang(2.0, 2.0)) (Math.Round(vec2d.ang(2.0, 2.0),4) = 0.7854)
printfn "ang (-2.0, -2.0)     Result: %f    Expected: -2.3562...    |passed: %b: " (vec2d.ang(-2.0, -2.0)) (Math.Round(vec2d.ang(-2.0, -2.0),4) = -2.3562)
printfn "ang (-2.0, 2.0)      Result: %f     Expected: 2.3562...     |passed: %b: " (vec2d.ang(-2.0, 2.0)) (Math.Round(vec2d.ang(-2.0, 2.0),4) = 2.3562)
printfn "ang (222.0, 360.0)   Result: %f     Expected: 1.0182...     |passed: %b: " (vec2d.ang(222.0, 360.0)) (Math.Round(vec2d.ang(222.0, 360.0),4) = 1.0182)
printfn "ang (0, 0)           Result: %f     Expected: 0.0...        |passed: %b: " (vec2d.ang(0.0, 0.0)) (vec2d.ang(0.0, 0.0) = 0.0)

printfn ""

printfn "Black-box testing of vec2d.add(x1,y1) (x2,y2)"
printfn "add (6.0, 5.0) (4.0, 9.0)           Result: %A      Expected: (10.0, 14.0)      |passed: %b: " (vec2d.add(6.0, 5.0) (4.0, 9.0)) (vec2d.add(6.0, 5.0) (4.0, 9.0) = (10.0, 14.0))
printfn "add (-9.0, -2.0) (-7.0, -3.0)       Result: %A     Expected: (-16.0, -5.0)     |passed: %b: " (vec2d.add(-9.0, -2.0) (-7.0, -3.0)) (vec2d.add(-9.0, -2.0) (-7.0, -3.0) = (-16.0, -5.0))
printfn "add (-9.0, 2.0) (7.0, -3.0)         Result: %A      Expected: (-2.0, -1.0)      |passed: %b: " (vec2d.add(-9.0, 2.0) (7.0, -3.0)) (vec2d.add(-9.0, 2.0) (7.0, -3.0) = (-2.0, -1.0))
printfn "add (0.0, 0.0) (0.0, 0.0)           Result: %A        Expected: (0.0, 0.0)        |passed: %b: " (vec2d.add(0.0, 0.0) (0.0, 0.0)) (vec2d.add(0.0, 0.0) (0.0, 0.0) = (0.0, 0.0))