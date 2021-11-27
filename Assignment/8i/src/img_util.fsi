module ImgUtil

/// colors
type color
///<summary>Calculates a real number continued fraction</summary>
///<returns>returns a list integers as a continued fraction of a real number</returns>
///<param name="x">value : float</param>
val red       : color
val blue      : color
val green     : color
val fromRgb   : int * int * int -> color
val fromArgb  : int * int * int * int -> color
val fromColor : color -> int * int * int * int

/// canvas
type canvas
val mk        : int -> int -> canvas
val init      : int -> int -> (int*int -> color) -> canvas
val setPixel  : color -> int * int -> canvas -> unit
val getPixel  : canvas -> int * int -> color
val setLine   : color -> int * int -> int * int -> canvas -> unit
val setBox    : color -> int * int -> int * int -> canvas -> unit
val width     : canvas -> int
val height    : canvas -> int

/// read canvas from a file
val fromFile : string -> canvas

/// save a bitmap as a png file
val toPngFile : string -> canvas -> unit