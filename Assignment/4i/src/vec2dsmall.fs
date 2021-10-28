module vec2d
open System

// The length of a vector
let len (x: float, y: float) =
    sqrt(x**2.0 + y**2.0)

// The angle of a vector
let ang (x: float, y: float) =
    Math.Atan2(y, x)

// Addition of two vectors
let add (x1:float, y1:float) (x2:float, y2:float)  = 
    x1+x2, y1+y2
