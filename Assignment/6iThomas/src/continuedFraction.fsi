module continuedFraction

///<summary>Calculates a list of integers as a continued fraction to the corresponding real number.</summary>
///<returns>returns the corresponding real number of a list of integers</returns>
///<param name="lst">value : int list</param>
val cfrac2float : lst:int list -> float

///<summary>Calculates a real number continued fraction</summary>
///<returns>returns a list integers as a continued fraction of a real number</returns>
///<param name="x">value : float</param>
val float2cfrac : x:float -> int list