type BoardDisplay =
    class
        //new //: rows:int * cols:int -> BoardDisplay
        member Set //: row:int * col:int * cont:string -> unit
        member SetBottomWall //: row:int * col:int -> unit
        member SetRightWall //: row:int * col:int -> unit
        member Show //: unit -> unit
    end




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
    inherit BoardElement ()
    member this.Position = ...
    override this.Interact other dir = ...
    override this.RenderOn display = ...
    member val Name = ...
    member robot.Step dir = ...