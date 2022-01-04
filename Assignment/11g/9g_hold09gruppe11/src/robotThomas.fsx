type Direction = North | South | East | West 
type Position = int * int
type Action =
    | Stop of Position
    | Continue of Direction * Position
    | Ignore
type BoardDisplay(rows:int,columns:int) =
    let EmptyArrayBuilder x y =    
        match (x,y) with
            | (x,y) when x = (rows-1) && y = (columns-1) -> ("  |","--+") //bottom right corner
            | (_,y) when y = (columns - 1) -> ("  |","  +") 
            | (x,_) when x = (rows - 1) -> ("   ","--+")
            | _,_ -> ("   ","  +")
    let EmptyArray = Array2D.init rows columns (fun x y -> EmptyArrayBuilder x y)
    member val Rows = rows with get
    member val Columns = columns with get
    member this.ResetArray() = Array2D.iteri (fun x y _ -> Array2D.set EmptyArray x y (EmptyArrayBuilder x y)) EmptyArray //runs EmptyArrayBuilder on every field, effectively clearing the array
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

//11g1
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
    member this.Position with get() = position and set(p) = position <- p
    override this.Interact (other:Robot) (dir:Direction) = 
        let robotrow,robotcol = other.Position
        match dir with
            | North when robotrow = (fst position + 1) && robotcol = (snd position) -> Stop(other.Position) 
            | South when robotrow = (fst position - 1)  && robotcol = (snd position) -> Stop(other.Position) 
            | East when robotcol = (snd position - 1)  && robotrow = (fst position) -> Stop(other.Position) 
            | West when robotcol = (snd position + 1)  && robotrow = (fst position) -> Stop(other.Position) 
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


//11g3

and Backslashwall(row:int,col:int,board:int*int) =
    inherit BoardElement()
    member this.Position with get() = (row,col)
    override this.RenderOn (board:BoardDisplay) =
        board.Set((fst this.Position),(snd this.Position)," \\") 
    override this.Interact (other:Robot) (dir:Direction) =
        let robotrow,robotcol = other.Position
        match dir with
            | North when (robotrow,robotcol) = (row,col) && row <> 1 -> Continue (West, (robotrow,robotcol - 1)) 
            | South when (robotrow,robotcol) = (row,col) && row <> snd board -> Continue (East, (robotrow,robotcol + 1))
            | East when (robotrow,robotcol) = (row,col) && col <> fst board -> Continue (South, (robotrow + 1,robotcol))
            | West when (robotrow,robotcol) = (row,col) && col <> 1 -> Continue (North, (robotrow - 1,robotcol))
            | _ -> Ignore


and Telepoter(row:int,col:int,tp:Position,board:int*int) =
    inherit BoardElement()
    member this.Position with get() = (row,col)
    override this.RenderOn (board:BoardDisplay) =
        board.Set((fst this.Position),(snd this.Position),"TP") 
    override this.Interact (other:Robot) (dir:Direction) =
        let mutable robotrow,robotcol = other.Position
        match dir with
            | North when (robotrow,robotcol) = (row,col) && fst tp <> 1 -> robotrow <- fst tp; robotcol <- snd tp; Continue (North, (robotrow - 1,robotcol))
            | South when (robotrow,robotcol) = (row,col) && fst tp <> snd board -> robotrow <- fst tp; robotcol <- snd tp; Continue (South, (robotrow + 1,robotcol))
            | East when (robotrow,robotcol) = (row,col) && snd tp <> fst board -> robotrow <- fst tp; robotcol <- snd tp; Continue (East, (robotrow,robotcol + 1)) 
            | West when (robotrow,robotcol) = (row,col) && snd tp <> 1 -> robotrow <- fst tp; robotcol <- snd tp; Continue (West, (robotrow,robotcol - 1)) 
            | _ -> Ignore


//11g2
type Board(rows:int,cols:int) = 
    let SetupBoard () = 
        let frame = BoardFrame(rows,cols)
        let goal = Goal(System.Random().Next(2,rows),System.Random().Next(1,cols))
        let hwall = HorizontalWall(System.Random().Next(1,rows),System.Random().Next(1,cols),System.Random().Next(-4,4))
        let vwall = VerticalWall(System.Random().Next(1,rows),System.Random().Next(1,cols),System.Random().Next(-4,4))
        let hwall2 = HorizontalWall(System.Random().Next(1,rows),System.Random().Next(1,cols),System.Random().Next(-4,4))
        let vwall2 = VerticalWall(System.Random().Next(1,rows),System.Random().Next(1,cols),System.Random().Next(-4,4))
        let backslash = Backslashwall(System.Random().Next(2,rows),System.Random().Next(1,cols),(rows,cols))
        
        let tp1 = (System.Random().Next(2,rows), System.Random().Next(1,cols))
        let tp2 = (System.Random().Next(2,rows), System.Random().Next(1,cols))
        let Telepoter1 = Telepoter(fst tp1,snd tp1, tp2, (rows,cols))
        let Telepoter2 = Telepoter(fst tp2,snd tp2, tp1, (rows,cols))

        let startelements : list<BoardElement> = [(frame :> BoardElement); (goal :> BoardElement); (hwall :> BoardElement); (vwall :> BoardElement); (hwall2 :> BoardElement); (vwall2 :> BoardElement); (backslash :> BoardElement); (Telepoter1 :> BoardElement); (Telepoter2 :> BoardElement)]
        startelements
    let mutable elements = SetupBoard()
    let mutable robots = []
    let display = BoardDisplay(rows,cols)
    member this.Robots with get() = robots and set(r) = robots <- robots @ r
    member this.Elements with get() = elements and set(e) = elements <- elements @ e
    member this.Display with get() = display
    member this.AddRobot(robot:Robot) = 
        this.Robots <- [robot]
        this.Elements <- [robot]
    member this.AddElement(element:BoardElement) = this.Elements <- [element]
    member this.GameOver =
        let mutable res = false
        for el in this.Elements do
            if (el.GameOver robots = true) then res <- true
        res
    member this.Move(r:Robot,dir:Direction) = 
        let rec mover (r:Robot) (dir:Direction) (index:int) = 
            match ((this.Elements.[index]).Interact r dir) with 
            | Stop (pos) -> r.Position <- (pos)
            | Continue (d,pos) -> 
                r.Position <- pos
                mover r d 0
            | Ignore when index = (List.length this.Elements) - 1 -> //when all elements have been checked
                r.Step dir
                mover r dir 0
            | Ignore -> mover r dir (index+1)
        mover r dir 0
    member this.RenderElements() =
        this.Display.ResetArray() //resets so previous positions aren't still shown
        for e in this.Elements do e.RenderOn (this.Display)
        this.Display.Show()

type Game(rows:int,cols:int,n:string list) = //the string list contains robot names, their length must be exactly two characters
    let b = Board(rows,cols)
    let rec setup =
        let mutable counter = 1
        for name in n do
            let name = Robot(1,counter,name) //amount of robots must be less than amount of columns, otherwise it will overflow
            counter <- counter + 1
            b.AddRobot name
    do setup
    member this.PrintRobots() =
        List.iteri (fun x _ -> printfn "%A: %A" (x+1) (b.Robots.[x].Name)) b.Robots //prints the list of robots and their index
    member this.PrintGameOver() =
        System.Console.Clear()
        do printfn "----------------------\nCongratulations, you won!\n----------------------"
        exit 0
    member this.Play() =
        let mutable selectedrobot = b.Robots.[0] //selects robot 0 as default
        b.RenderElements()
        let rec chooserobot () =
            do this.PrintRobots()
            printfn "Select a robot number:"
            let robotnr = System.Console.ReadKey(true)
            try
                selectedrobot <- b.Robots.[((robotnr.KeyChar.ToString()) |> int)-1]
            with _ -> 
                do printfn "Please enter a valid robot number"
                chooserobot ()
        let rec moveloop () =
            let input = System.Console.ReadKey(true)
            match input with
                | key when key.Key = System.ConsoleKey.UpArrow -> b.Move(selectedrobot,North)
                | key when key.Key = System.ConsoleKey.DownArrow -> b.Move(selectedrobot,South)
                | key when key.Key = System.ConsoleKey.RightArrow -> b.Move(selectedrobot,East)
                | key when key.Key = System.ConsoleKey.LeftArrow -> b.Move(selectedrobot,West)
                | key when key.Key = System.ConsoleKey.Enter -> 
                    chooserobot ()
                    moveloop ()
                | _ -> ()
            System.Console.Clear()
            b.RenderElements()
            if b.GameOver then this.PrintGameOver()
            else moveloop ()
        printfn "%A" (this.PrintRobots())
        moveloop ()

//To start the game:
let g = Game(7,7,["AA";"BB";"CC";"DD"])
g.Play() 


