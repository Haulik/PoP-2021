printfn "White-box testing of cfrac2float (lst: int list)"
printfn "llst: []             branch: 1a       Result: %g           Expected: 0.0       |passed: %b " (continuedFraction.cfrac2float []) (continuedFraction.cfrac2float [] = 0.0)
printfn "llst: [1]            branch: 1b       Result: %g           Expected: 1.0       |passed: %b " (continuedFraction.cfrac2float [1] ) (continuedFraction.cfrac2float [1] = 1.0)
printfn "llst: [3;4;12;4]     branch: 1c       Result: %g       Expected: 3.245     |passed: %b " (continuedFraction.cfrac2float [3;4;12;4] ) (continuedFraction.cfrac2float [3;4;12;4] = 3.245)
printfn "llst: [3;0;12;4]     branch: 1c-2a    Result: %g           Expected: 0.0       |passed: %b " (continuedFraction.cfrac2float [3;0;12;4]  ) (continuedFraction.cfrac2float [3;0;12;4]  = 0.0)
printfn "llst: [3;1;12;0]     branch: 1c-2a    Result: %g           Expected: 0.0       |passed: %b " (continuedFraction.cfrac2float [3;1;12;0]  ) (continuedFraction.cfrac2float [3;1;12;0]  = 0.0)
printfn "llst: [3;1;-1;0]     branch: 1c-2a    Result: %g           Expected: 0.0       |passed: %b " (continuedFraction.cfrac2float [3;1;-1;0]  ) (continuedFraction.cfrac2float [3;1;-1;0]  = 0.0)
printfn "llst: [2;6;11;9]     branch: 1c-2b    Result: %g      Expected: 2.1642    |passed: %b " (continuedFraction.cfrac2float [2;6;11;9] ) (System.Math.Round(continuedFraction.cfrac2float [2;6;11;9], 5) = 2.1642)


printfn ""


printfn "White-box testing of float2cfrac (x:float)"
printfn "x: 0.0           branch: 1a          Result: %A                          Expected: [0]                          |passed: %b " (continuedFraction.float2cfrac 0.0) (continuedFraction.float2cfrac 0.0 = [0])
printfn "x: 3.245         branch: 1b          Result: %A                Expected: [3; 4; 12; 4]                |passed: %b " (continuedFraction.float2cfrac 3.245 ) (continuedFraction.float2cfrac 3.245  = [3;4;12;4])
printfn "x: -3.245        branch: 1b-2a       Result: %A                           Expected: []                           |passed: %b " (continuedFraction.float2cfrac -3.245  ) (continuedFraction.float2cfrac -3.245   = [])
printfn "x: 3.14165       branch: 1b-2b       Result: %A    Expected: [3; 7; 16; 1; 3; 4; 2; 4]    |passed: %b " (continuedFraction.float2cfrac 3.14165 ) (continuedFraction.float2cfrac 3.14165 = [3;7;16;1;3;4;2;4])



printfn ""


printfn "Black-box testing of cfrac2float (lst: int list)"
printfn "cfrac2float [3;4;12;4]         Result: %g         Expected: 3.245       |passed: %b: " (continuedFraction.cfrac2float [3;4;12;4]) (continuedFraction.cfrac2float [3;4;12;4] = 3.245)
printfn "cfrac2float [1;2;3;4]          Result: %g       Expected: 1.43333     |passed: %b: " (continuedFraction.cfrac2float [1;2;3;4]) (System.Math.Round(continuedFraction.cfrac2float [1;2;3;4], 5) = 1.43333)
printfn "cfrac2float [1;0;3;4]          Result: %g             Expected: 0           |passed: %b: " (continuedFraction.cfrac2float [1;0;3;4]) (continuedFraction.cfrac2float [1;0;3;4] = 0.0 )
printfn "cfrac2float [0;1;6;7]          Result: %g          Expected: 0.86        |passed: %b: " (continuedFraction.cfrac2float [0;1;6;7]) (continuedFraction.cfrac2float [0;1;6;7] = 0.86)
printfn "cfrac2float [0;0;6;7]          Result: %g             Expected: 0           |passed: %b: " (continuedFraction.cfrac2float [0;0;6;7]) (continuedFraction.cfrac2float [0;0;6;7] = 0.0 )
printfn "cfrac2float [-3;3;6;7]         Result: %g      Expected: -2.68382    |passed: %b: " (continuedFraction.cfrac2float [-3;3;6;7]) (System.Math.Round(continuedFraction.cfrac2float [-3;3;6;7], 5) = -2.68382)
printfn "cfrac2float [3;-3;6;7]         Result: %g             Expected: 0           |passed: %b: " (continuedFraction.cfrac2float [3;-3;6;7]) (System.Math.Round(continuedFraction.cfrac2float [3;-3;6;7], 5) = 0.0)

printfn ""

printfn "Black-box testing of vfloat2cfrac (x:float)"
printfn "vfloat2cfrac 3.245             Result: %A                     Expected: [3;4;12;4]                |passed: %b: " (continuedFraction.float2cfrac 3.245) (continuedFraction.float2cfrac 3.245 = [3;4;12;4])
printfn "vfloat2cfrac 1.43333           Result: %A                     Expected: [1;2;3;4]                 |passed: %b: " (continuedFraction.float2cfrac 3.245) (continuedFraction.float2cfrac 3.245 = [3;4;12;4])
printfn "vfloat2cfrac 0                 Result: %A                               Expected: [0]                       |passed: %b: " (continuedFraction.float2cfrac 0.0) (continuedFraction.float2cfrac 0.0 = [0])
printfn "vfloat2cfrac 3.14165           Result: %A         Expected: [3;7;16;1;3;4;2;4]        |passed: %b: " (continuedFraction.float2cfrac 3.14165 ) (continuedFraction.float2cfrac 3.14165  = [3;7;16;1;3;4;2;4])
printfn "vfloat2cfrac -3.245            Result: %A                                Expected: []                        |passed: %b: " (continuedFraction.float2cfrac -3.245  ) (continuedFraction.float2cfrac -3.245   = [])