/// A 2 dimensional vector library .
/// Vectors are represented as pairs of floats
module vec2d

///<summary>Calculates the length of a vector with any float value</summary>
///<returns>returns a float of the calculated length of a vector</returns>
///<param name="(x,y)">value : float</param>
val len : float * float -> float

///<summary>Calculates the angle of a vector</summary>
///<returns>returns a float of the calculated angle of a vector</returns>
///<param name="(x,y)">value : float</param>
val ang : float * float -> float

///<summary>Calculates the Addition of two vectors</summary>
///<returns>returns a vector of the calculated Addition of two vectors</returns>
///<param name="(x1,y1)">First vector - value : float</param>
///<param name="(x2,y2)">second vector - value : float </param>
val add : float * float -> float * float -> float * float
