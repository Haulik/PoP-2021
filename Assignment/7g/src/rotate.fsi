module Rotate

type Board = char list
type Position = int 

///<summary>Creates a board, as a char list.</summary>
///<param name="n">The side-length of the board.</param>
///<returns>A list of chars with n*n length. If n is less than 2, it returns a 2*2 board. If n is larger than 5, it returns a 5*5 board.</returns>
val create : n:uint -> Board

///<summary>Converts the board, a char list, into a string</summary>
///<param name="b">The board, a char list</param>
///<returns>The string, formatted as a n*n table with the same sidelength as the board.</returns>
val board2Str : b:Board -> string

///<summary>A recursive helper function to the board2Str function. Adds one list element to the string at a time.</summary>
///<param name="b">The board, a char list. The first list element gets removed from the variable in every recursive step, until the list is empty.</param>
///<param name="pos">The position on the board. When the position reaches the end of a row in the table, a newline gets added to the string.</param>
///<param name="n">The sidelength of the board</param>
///<returns>A string that represents the board.</returns>
val board2Strhelper : b:Board -> pos:int -> n:int -> string

///<summary>Determines whether a rotation position is valid. Checks if the position is less than 0 or larger than the length of the list, and if the position is on the bottom row or the right-most column.</summary>
///<param name="b">The board, a char list.</param>
///<param name="p">The position which is checked for a valid rotation.</param>
///<returns>True if the position is valid, false otherwise.</returns>
val validRotate : b:Board -> p:Position -> bool

///<summary>Performs a rotation on the board, shifting four elements in a 2*2 subsquare clockwise.</summary>
///<param name="b">The board, a char list.</param>
///<param name="p">The position of the top-left corner of the rotating square. If the position is not valid for rotation, the old board is returned.</param>
///<remarks>The function initializes a new list, which is the result of the rotation. All fields outside of the rotating square are copied from the old board, and the fields inside the square are moved to their new position, which is determined by the rotateHelper function.</remarks>
///<returns>A new board, where the fields at the position p have been rotated clockwise. If the position is invalid, it returns the old board</returns>
val rotate : b:Board -> p:Position -> Board

///<summary>Performs a series of rotations at random positions in the board.</summary>
///<param name="b">The board, a char list.</param>
///<param name="m">The amount of random rotations that are performed on the board.</param>
///<remarks>Uses a recursive helper function which carries out random, valid rotations until the desired total amount of rotations have been performed.</remarks>
///<returns>The scrambled board.</returns>
val scramble : b:Board -> m:uint -> Board

///<summary>Checks if the board is in a solved state by comparing the current state of the char list to the sorted char list</summary>
///<param name="b">The board, a char list.</param>
///<returns>True if the board is solved, false otherwise.</returns>
val solved : b:Board -> bool