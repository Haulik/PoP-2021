type Direction = North | South | East | West 
type Position = int * int
type Action =
    | Stop of Position
    | Continue of Direction * Position
    | Ignore
type BoardDisplay(rows:int,columns:int) =
    let EmptyArray = Array2D.init rows columns (fun x y -> 
        match (x,y) with
            | (x,y) when x = (rows-1) && y = (columns-1) -> ("  |","--+") //bottom right corner
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
        EmptyArray.[row-1,column-1] <- (top.[..1] + "|",bot)
    member this.Set(row:int,column:int,cont:string) = //cont must have length of 2 chars
        let (top,bot) = EmptyArray.[row-1,column-1]
        EmptyArray.[row-1,column-1] <- (cont + (string top.[2]),bot)
    member this.Print() = do printfn "%A" EmptyArray //for testing only
    member this.BuildString() =
        let mutable board = "\n+" + (String.replicate columns "--+") + "\n"
        for r=0 to (rows-1) do
            board <- board + "|"
            for c=0 to (columns-1) do
                board <- board + fst EmptyArray.[r,c]
            board <- board + "\n+"
            for c=0 to (columns-1) do
                board <- board + snd EmptyArray.[r,c]
            board <- board + "\n"
        board
    member this.Show() = do printfn "%A" (this.BuildString())

[<AbstractClass>] 
type BoardElement () =
    abstract member RenderOn : BoardDisplay -> unit
    abstract member Interact : Robot -> Direction -> Action 
    default __.Interact _ _ = Ignore
    abstract member GameOver : Robot list -> bool
    default __.GameOver _ = false

and Robot(row:int, col:int, name:string) = 
    inherit BoardElement()
    let mutable position = (row, col)
    member this.Position with get() = position
    override this.Interact (other:Robot) (dir:Direction) = 
        let robotrow,robotcol = other.Position
        match dir with
            | North when robotrow = (fst position - 1) && robotrow = (snd position) -> Stop(other.Position) 
            | South when robotrow = (fst position + 1)  && robotrow = (snd position) -> Stop(other.Position) 
            | East when robotcol = (snd position + 1)  && robotcol = (fst position) -> Stop(other.Position) 
            | West when robotcol = (snd position - 1)  && robotcol = (fst position) -> Stop(other.Position) 
            | _ -> Ignore

    override this.RenderOn (board:BoardDisplay) = board.Set((fst this.Position),(snd this.Position),name)
    member val Name = name
    member robot.Step (dir:Direction) = 
        match dir with
            | North -> position <- ((fst position) - 1,snd position)
            | South -> position <- ((fst position) + 1,snd position)
            | East -> position <- (fst position,(snd position) + 1)
            | West -> position <- (fst position,(snd position) - 1)

and Goal(row:int, col:int) =
    inherit BoardElement()
    member this.Position with get() = (row,col)
    override this.GameOver (r:Robot list) : bool =
        let mutable gameover = false
        for robot in r do
            if robot.Position = this.Position then gameover <- true
        gameover
    override this.RenderOn (board:BoardDisplay) =
        board.Set((fst this.Position),(snd this.Position),"GO") 

and BoardFrame(row:int,col:int) =
    inherit BoardElement()
    override this.RenderOn (board:BoardDisplay) = () //boardframes are rendered by default
    override this.Interact (other:Robot) (dir:Direction) =
        let robotrow,robotcol = other.Position
        match dir with
            | North when robotrow = 1 -> Stop (robotrow,robotcol)
            | South when robotrow = row -> Stop (robotrow,robotcol)
            | East when robotcol = col -> Stop (robotrow,robotcol)
            | West when robotcol = 1 -> Stop (robotrow,robotcol)
            | _ -> Ignore

and VerticalWall(row:int,col:int,n:int) =
    inherit BoardElement()
    member this.Length = n
    member this.Position with get() = (row,col)
    override this.RenderOn (board:BoardDisplay) = 
        let (+) a k =  //helper function to calculate location on wall depending on whether n is positive or negative
            if this.Length >= 0 then a+k else a-k
        for k=0 to (abs this.Length) do
            if 0 < ((+) row k) && ((+) row k) <= board.Rows then board.SetRightWall(((+) row k),col)
    override this.Interact (other:Robot) (dir:Direction) =
        let robotrow,robotcol = other.Position
        match dir with
            | East when robotcol = col && (min row (row+this.Length)) <= robotrow && robotrow <= (max row (row+this.Length)) -> Stop (robotrow,robotcol)
            | West when robotcol = col+1 && (min row (row+this.Length)) <= robotrow && robotrow <= (max row (row+this.Length)) -> Stop (robotrow,robotcol)
            | _ -> Ignore

and HorizontalWall(row:int,col:int,n:int) =
    inherit BoardElement()
    member this.Length = n
    member this.Position with get() = (row,col)
    override this.RenderOn (board:BoardDisplay) = 
        let (+) a k = 
            if this.Length >= 0 then a+k else a-k
        for k=0 to (abs this.Length) do
            if 0 < ((+) col k) && ((+) col k) <= board.Columns then board.SetBottomWall(row,((+) col k))
    override this.Interact (other:Robot) (dir:Direction) =
        let robotrow,robotcol = other.Position
        match dir with
            | South when robotrow = row && (min col (col+this.Length)) <= robotcol && robotcol <= (max col (col+this.Length)) -> Stop (robotrow,robotcol)
            | North when robotrow = row+1 && (min col (col+this.Length)) <= robotcol && robotcol <= (max col (col+this.Length)) -> Stop (robotrow,robotcol)
            | _ -> Ignore
    
        
//Tests:
let b = BoardDisplay(4,7)
//b.SetBottomWall(1,1)
b.SetRightWall(1,1)
b.SetRightWall(2,2)
b.Set(1,1,"T ")
b.Set(3,3,"AA")
b.Set(3,4,"BB")
b.Print()
let g = Goal(4,4)
g.RenderOn b
let w = VerticalWall(3,3,5)
w.RenderOn b
let h = HorizontalWall(1,2,6)
h.RenderOn b
let robert = Robot(3,3,"RO")
robert.RenderOn b
printfn "%A" (w.Interact robert East)
b.Show()


(* 
("TT|", "--+") ("   ", "  +")

+--+--+--+--+--+--+--+
|TT|                 |
+--+  +  +  +  +  +  +
|     |              |
+  +  +  +  +  +  +  +
|      AA BB         |
+  +  +  +  +  +  +  +
|                    |
+--+--+--+--+--+--+--+
 *)

AA|
--+
for hvert felt
    top string "AA|"
    bottom string "--+" *)

(* Inden hvert skridt løbes gennem alle spilelementer (undta- gen robotten selv), og metoden Interact kaldes for hvert element. 
Hvis alle spilelementer returnere Ignore kan robotten flyttes eet felt i den givne retning, og robotten forsøges at fly- 
ttes endnu et felt. Hvis et spilelement returnerer Stop pos, stoppes robottens flytning i felt pos (som ikke nødvendigvis er robottens nuværende position). Hvis et spilelement returnerer Continue dir pos fortsætter robotten fra felt pos med retning dir (bemærk at ingen af de obligatoriske spilelementer bruger Continue). *)