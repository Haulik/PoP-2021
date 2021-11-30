type point = int * int // a point (x, y) in the plane
type color = ImgUtil.color

type figure =
    | Circle of point * int * color
    // defined by center , radius , and color
    | Rectangle of point * point * color
    // defined by corners top -left , bottom -right , and color
    | Mix of figure * figure
    // combine figures with mixed color at overlap'


    // finds color of figure at point
let rec colorAt (x,y) figure =
    match figure with
    | Circle ((cx,cy), r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r
            // uses Pythagoras 'equation to determine
            // distance to center
        then Some col else None
    | Rectangle ((x0,y0), (x1,y1), col) ->
        if x0 <= x && x <= x1 && y0 <= y && y <= y1
            // within corners
        then Some col else None
    | Mix (f1, f2) ->
        match (colorAt (x,y) f1, colorAt (x,y) f2) with
        | (None , c) -> c // no overlap
        | (c, None) -> c // no overlap
        | (Some c1, Some c2) ->
        let (a1 ,r1 ,g1 ,b1) = ImgUtil.fromColor c1
        let (a2 ,r2 ,g2 ,b2) = ImgUtil.fromColor c2
        in Some(ImgUtil.fromArgb ((a1+a2)/2, (r1+r2)/2, // calculate
                                 (g1+g2)/2, (b1+b2)/2)) // average color


//let C = ImgUtil.mk 265 265
let cir = Circle ((50,50), 45, (ImgUtil.fromRgb (255 ,0 ,0)))
let rect = Rectangle ((50,50), (90,110), (ImgUtil.fromRgb (0 ,0 ,255)))
let figTest = Mix (cir,rect)



let makePicture (filnavn:string) (figur:figure) (b:int) (h:int) : unit =
    let grey = (ImgUtil.fromRgb (128 ,128 ,128))
    let canvas = ImgUtil.mk b h
    for x in [0..b-1] do
        for y in [0..h-1] do         
            let farve = colorAt (x,y) figur
            match colorAt (x,y) figur with
                | Some c ->  ImgUtil.setPixel c (x,y) canvas
                | None -> ImgUtil.setPixel grey (x,y) canvas
    do ImgUtil.toPngFile filnavn canvas

let rec checkFigure (fig: figure) : bool =
    match fig with
        | Circle ((cx,cy), r, col) -> r >= 0
        | Rectangle ((x0,y0), (x1,y1), col) -> x1 >= x0 && y1 >= y0
        | Mix (f1, f2) -> checkFigure f1 && checkFigure f2

let rec move (fig: figure) (x,y: int) : figure =
    match fig with 
        | Circle ((cx,cy), r, col) -> Circle ((cx+x,cy+y), r, col)
        | Rectangle ((x0,y0), (x1,y1), col) -> Rectangle ((x0+x,y0+y), (x1+x,y1+y), col)
        | Mix (f1, f2) -> Mix ((move f1 (x,y)), move f2 (x,y))


let rec boundingBox (fig:figure) : point * point =
    match fig with 
        | Circle ((x,y), r, col) -> (x-r, y-r), (x+r, y+r)
        | Rectangle ((x0,y0), (x1,y1), col) -> ((x0,y0), (x1,y1))
        | Mix (f1, f2) -> 
            let (f1x0, f1y0), (f1x1, f1y1) = (boundingBox f1) 
            let (f2x0, f2y0), (f2x1, f2y1) = (boundingBox f2)
            let p1 = ((min f1x0 f2x0), (min f1y0 f2y0))
            let p2 = ((max f1x1 f2x1), (max f1y1 f2y1))
            (p1,p2)
            
            


//do makePicture "test.png" figTest 100 150
printfn "%b" (checkFigure figTest)
do makePicture "moveTest.png" (move figTest (-20,20)) 100 150
printfn "%A" (boundingBox figTest)

//let q = ImgUtil.init 265 265 mix 
//do ImgUtil.setPixel (ImgUtil.fromRgb (255 ,0 ,0)) (10 ,10) C
//do ImgUtil.toPngFile "test2.png" q
    