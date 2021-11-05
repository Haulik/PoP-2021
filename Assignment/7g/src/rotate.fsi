module Rotate

///<summary></summary>
///<param></param>
///<returns>A list of chars with n*n length</returns>
val create : n:uint -> Board
///<summary></summary>
///<param></param>
///<returns></returns>
val board2Str : b:Board -> string
///<summary></summary>
///<param></param>
///<returns></returns>
val validRotation : b:Board -> p:Position -> bool
///<summary></summary>
///<param></param>
///<returns></returns>
val rotate : b:Board -> p:Position -> Board
///<summary></summary>
///<param></param>
///<returns></returns>
val scramble : b:Board -> m:uint -> Board
///<summary></summary>
///<param></param>
///<returns></returns>
val solved : b:Board -> bool