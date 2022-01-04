(* type BoardDisplay' =
    class
        new BoardDisplay() -> BoardDisplay
        member Set : row:int * col:int * cont:string -> unit //(row:int) (col:int) (cont:string) : unit
        member SetBottomWall : row:int * col:int -> unit //(row:int) (col:int) : unit
        member SetRightWall : row:int * col:int -> unit //(row:int) (col:int) : unit
        member Show : unit -> unit 
    end *)

(* type BoardDisplay(rows:int,columns:int) =
    member val Rows = rows with get, set
    member val Columns = columns with get, set
    member this.EmptyArray = Array2D.init this.Rows this.Columns (fun x y -> 
        match (x,y) with
            | (x,y) when x = (this.Rows - 1) && y = (this.Columns - 1) -> ("  |","--+") //bottom right corner
            | (_,y) when y = (this.Columns - 1) -> ("  |","  +") 
            | (x,_) when x = (this.Rows - 1) -> ("   ","--+")
            | _,_ -> ("   ","  +"))
    member this.SetBottomWall(row:int,column:int) =
        let (top,_) = this.EmptyArray.[row,column]
        let this.EmptyArray.[row,column] = (top,"--+")
        () *)
    



type BoardDisplay2(rows:int,columns:int) =
    let EmptyArray = Array2D.init rows columns (fun x y -> 
        match (x,y) with
            | (x,y) when x = rows && y = columns -> ("  |","--+") //bottom right corner
            | (_,y) when y = (columns - 1) -> ("  |","  +") 
            | (x,_) when x = (rows - 1) -> ("   ","--+")
            | _,_ -> ("   ","  +"))
    member val Rows = rows with get
    member val Columns = columns with get
    member this.SetBottomWall(row:int,column:int) =
        let (top,_) = EmptyArray.[row-1,column-1]
        EmptyArray.[row-1,column-1] <- (top,"--+")
    member this.SetRightWall(row:int,column:int) =
        let (top,bot) = EmptyArray.[row-1,column-1]
        EmptyArray.[row-1,column-1] <- (top.[..1] + "|","--+")
    member this.Print() = do printfn "%A" EmptyArray //for testing only


let b = BoardDisplay2(4,7)
b.SetBottomWall(1,1)
b.SetRightWall(2,2)
b.Print()
(* ("AA|","--+")

AA|
--+
for hvert felt
    main string "AA|"
    bottom string "--+" *)



//For senere
(*

type Direction = North | South | East | West

type Action =
    | Stop of Position
    | Continue of Direction * Position
    | Ignore


type BoardElement () =
    abstract member RenderOn : BoardDisplay -> unit
    abstract member Interact : Robot -> Direction -> Action
    default __.Interact _ _ = Ignore
    abstract member GameOver : Robot list -> bool
    default __.GameOver _ = false


and Robot(row:int , col:int , name:string) =
    //inherit BoardElement ()
    //member this.Position = ...
    //override this.Interact other dir = ...
    //override this.RenderOn display = ...
    //member val Name = ...
    //member robot.Step dir = ...
    





    
*)

//member Set (row:int) * (col:int) * (cont:string) : unit