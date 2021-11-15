printfn "Black-box testing of create (n:uint) : Board"
printfn "create 0u         Result: %A                                  Expected: ['a'..'d']       |passed: %b: " (Rotate.create 0u) (Rotate.create 0u = ['a';'b';'c';'d'])
printfn "create 3u         Result: %A         Expected: ['a'..'d']       |passed: %b: " (Rotate.create 3u) (Rotate.create 3u = ['a'..'i'])
printfn "create 50u        Result: %A                                   Expected: ['a'..'d']       |passed: %b: " (Rotate.create 50u) (Rotate.create 50u = ['a'..'y'])

printfn ""
//-------------------------------------------------------------
printfn "Black-box testing of board2Str (b:Board) : string"
printfn "board2Str []                 Result: %A         Expected: ''       |passed: %b: " (Rotate.board2Str []) (Rotate.board2Str [] = "")
printfn "board2Str ['a'..'d']         Result: %A         Expected: \nab\ncd\n\n       |passed: %b: " (Rotate.board2Str ['a'..'d']) (Rotate.board2Str ['a'..'d'] = "\nab\ncd\n\n")
printfn "board2Str ['a'..'i']         Result: %A         Expected: \nabc\ndef\nghi\n\n       |passed: %b: " (Rotate.board2Str ['a'..'i']) (Rotate.board2Str ['a'..'i'] = "\nabc\ndef\nghi\n\n")
printfn "board2Str ['a'..'y']         Result: %A         Expected: \nabcde\nfghij\nklmno\npqrst\nuvwxy\n\n       |passed: %b: " (Rotate.board2Str ['a'..'y'] ) (Rotate.board2Str ['a'..'y']  = "\nabcde\nfghij\nklmno\npqrst\nuvwxy\n\n")

printfn ""

//-------------------------------------------------------------
printfn "Black-box testing of validRotate (b:Board) (p:Position) : bool"
printfn "validRotate [] -1                Result: %A         Expected: false       |passed: %b: " (Rotate.validRotate [] -1) (Rotate.validRotate [] -1 = false)
printfn "validRotate [] 0                 Result: %A         Expected: false       |passed: %b: " (Rotate.validRotate [] 0) (Rotate.validRotate [] 0 = false)
printfn "validRotate [] 1                 Result: %A         Expected: false       |passed: %b: " (Rotate.validRotate [] 1) (Rotate.validRotate [] 1 = false)
printfn "validRotate ['a'..'i'] 0         Result: %A          Expected: true        |passed: %b: " (Rotate.validRotate ['a'..'i'] 0) (Rotate.validRotate ['a'..'i'] 0 = true)
printfn "validRotate ['a'..'i'] 1         Result: %A          Expected: true        |passed: %b: " (Rotate.validRotate ['a'..'i'] 1) (Rotate.validRotate ['a'..'i'] 1 = true)
printfn "validRotate ['a'..'i'] -1        Result: %A         Expected: false       |passed: %b: " (Rotate.validRotate ['a'..'i'] -1) (Rotate.validRotate ['a'..'i'] -1 = false)
printfn "validRotate ['a'..'i'] 2         Result: %A         Expected: false       |passed: %b: " (Rotate.validRotate ['a'..'i'] 2) (Rotate.validRotate ['a'..'i'] 2 = false)
printfn "validRotate ['a'..'i'] 3         Result: %A          Expected: true        |passed: %b: " (Rotate.validRotate ['a'..'i'] 3) (Rotate.validRotate ['a'..'i'] 3 = true)
printfn "validRotate ['a'..'i'] 55        Result: %A         Expected: false       |passed: %b: " (Rotate.validRotate ['a'..'i'] 55) (Rotate.validRotate ['a'..'i'] 55 = false)

printfn ""
//-------------------------------------------------------------

printfn "Black-box testing of rotate (b:Board) (p:Position) : Board"
printfn "rotate [] -1                 Result: %A                                                    Expected: []                                                  |passed: %b: " (Rotate.rotate [] -1) (Rotate.rotate [] -1 = [])
printfn "rotate [] 0                  Result: %A                                                    Expected: []                                                  |passed: %b: " (Rotate.rotate [] 0) (Rotate.rotate [] 0 = [])
printfn "rotate [] 1                  Result: %A                                                    Expected: []                                                  |passed: %b: " (Rotate.rotate [] 1) (Rotate.rotate [] 1 = [])
printfn "rotate ['a'..'i'] -1         Result: %A         Expected: ['a';'b';'c';'d';'e';'f';'g';'h';'i']               |passed: %b: " (Rotate.rotate ['a'..'i'] -1) (Rotate.rotate ['a'..'i'] -1 = ['a'..'i'])
printfn "rotate ['a'..'i'] 0          Result: %A         Expected: ['d'; 'a'; 'c'; 'e'; 'b'; 'f'; 'g'; 'h'; 'i']       |passed: %b: " (Rotate.rotate ['a'..'i'] 0) (Rotate.rotate ['a'..'i'] 0 = ['d'; 'a'; 'c'; 'e'; 'b'; 'f'; 'g'; 'h'; 'i'])
printfn "rotate ['a'..'i'] 1          Result: %A         Expected: ['a'; 'e'; 'b'; 'd'; 'f'; 'c'; 'g'; 'h'; 'i']       |passed: %b: " (Rotate.rotate ['a'..'i'] 1) (Rotate.rotate ['a'..'i'] 1 = ['a'; 'e'; 'b'; 'd'; 'f'; 'c'; 'g'; 'h'; 'i'])
printfn "rotate ['a'..'i'] 4          Result: %A         Expected: ['a'; 'b'; 'c'; 'd'; 'h'; 'e'; 'g'; 'i'; 'f']       |passed: %b: " (Rotate.rotate ['a'..'i'] 4) (Rotate.rotate ['a'..'i'] 4 = ['a'; 'b'; 'c'; 'd'; 'h'; 'e'; 'g'; 'i'; 'f'])
printfn "rotate ['a'..'i'] 25         Result: %A         Expected: ['a';'b';'c';'d';'e';'f';'g';'h';'i']               |passed: %b: " (Rotate.rotate ['a'..'i'] 25) (Rotate.rotate ['a'..'i'] 25 = ['a'..'i'])
printfn "rotate ['a'..'y'] 15         Result: %A         Expected: ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'; 'j'; 'k'; 'l'; 'm'; 'n'; 'o'; 'u';'p'; 'r'; 's'; 't'; 'v'; 'q'; 'w'; 'x'; 'y']              |passed: %b: " (Rotate.rotate ['a'..'y'] 15) (Rotate.rotate ['a'..'y'] 15 = ['a'; 'b'; 'c'; 'd'; 'e'; 'f'; 'g'; 'h'; 'i'; 'j'; 'k'; 'l'; 'm'; 'n'; 'o'; 'u';'p'; 'r'; 's'; 't'; 'v'; 'q'; 'w'; 'x'; 'y'])


printfn ""
//-------------------------------------------------------------

printfn "Black-box testing of scramble (b:Board) (m:uint) : Board"
let test = (Rotate.scramble [] 0u)
printfn "scramble [] 0u                  Result: %A                                                    Expected: []                        |passed: %b: " test (test = [])

let test2 = (Rotate.scramble [] 1u)
printfn "scramble [] 1u                  Result: %A                                                    Expected: []                        |passed: %b: " test2 (test2 = [])

let test3 = (Rotate.scramble ['a'..'i'] 0u)
printfn "scramble ['a'..'i'] 0u          Result: %A         Expected: ['a'..'i']                |passed: %b: " test3 (test3 = ['a'..'i'])

let test4 = (Rotate.scramble ['a'..'i'] 1u)
printfn "scramble ['a'..'i'] 1u          Result: %A         Expected: ['a'..'i'] <> Result      |passed: %b: " test4 (test4 <> ['a'..'i'])

let test5 = (Rotate.scramble ['a'..'i'] 26u)
printfn "scramble ['a'..'i'] 26u         Result: %A         Expected: ['a'..'i'] <> Result      |passed: %b: " test5 (test5 <> ['a'..'i'])


printfn ""
//-------------------------------------------------------------

printfn "Black-box testing of solved (b:Board) : bool"
printfn "solved ['a';'b';'c';'d';'e';'f';'g';'h';'i']          Result: %A         Expected: true       |passed: %b: " (Rotate.solved ['a'..'i']) (Rotate.solved ['a'..'i']  = true)
printfn "solved ['a';'c';'b';'d';'f';'g';'e';'h';'i']          Result: %A        Expected: false      |passed: %b: " (Rotate.solved ['a';'c';'b';'d';'f';'g';'e';'h';'i'] ) (Rotate.solved ['a';'c';'b';'d';'f';'g';'e';'h';'i'] = false)
printfn "solved []                                             Result: %A         Expected: true       |passed: %b: " (Rotate.solved []) (Rotate.solved [] = true)

printfn ""

//-------------------------------------------------------------