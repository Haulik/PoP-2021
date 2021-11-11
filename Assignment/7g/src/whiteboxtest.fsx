printfn "Whitebox test of create (n:uint) : Board"
printfn "uint : 0u      branch : 1a      Expected: ['a'..'d']"
printfn "Result %A" (Rotate.create 0u)
printfn "passed: %b" (Rotate.create 0u = ['a';'b';'c';'d'])
printfn ""
printfn "uint : 6u      branch : 1b      Expected: ['a'..'y']"
printfn "Result %A" (Rotate.create 6u)
printfn "passed: %b" (Rotate.create 6u = ['a';'b';'c';'d';'e';'f';'g';'h';'i';'j';'k';'l';'m';'n';'o';'p';'q';'r';'s';'t';'u';'v';'w';'x';'y'])
printfn ""
printfn "uint : 3u      branch : 1c      Expected: ['a'..'i']"
printfn "Result %A" (Rotate.create 3u)
printfn "passed: %b" (Rotate.create 3u = ['a';'b';'c';'d';'e';'f';'g';'h';'i'])
printfn ""
printfn "uint : 5u      branch : 1c      Expected: ['a'..'y']"
printfn "Result %A" (Rotate.create 5u)
printfn "passed: %b" (Rotate.create 5u = ['a';'b';'c';'d';'e';'f';'g';'h';'i';'j';'k';'l';'m';'n';'o';'p';'q';'r';'s';'t';'u';'v';'w';'x';'y'])
printfn ""

printfn "Whitebox test of board2Str (b:Board) : string"
printfn "b: []      branch : 1-1a        Expected: \"\""
printfn "Result %A" (Rotate.board2Str [])
printfn "passed: %b" (Rotate.board2Str [] = "")
printfn ""
printfn "b: ['a']      branch : 1-1b        Expected: \"a\n\n\""
printfn "Result %A" (Rotate.board2Str ['a'])
printfn "passed: %b" (Rotate.board2Str ['a'] = "a\n\n")
printfn ""
printfn "b: ['a'..'i']      branch : 1-2c/d        Expected: \"\nabc\ndef\nghi\n\n\""
printfn "Result %A" (Rotate.board2Str ['a'..'i'])
printfn "passed: %b" (Rotate.board2Str ['a'..'i'] = "\nabc\ndef\nghi\n\n")
printfn ""
printfn "b: ['a'..'y']      branch : 1-2c/d        Expected: \"\nabcde\nfghij\nklmno\npqrst\nuvwxy\n\n\""
printfn "Result %A" (Rotate.board2Str ['a'..'y'])
printfn "passed: %b" (Rotate.board2Str ['a'..'y'] = "\nabcde\nfghij\nklmno\npqrst\nuvwxy\n\n")
printfn ""

printfn "Whitebox test of validRotate (b:Board) (p:Position) : bool"
printfn "b: ['a'..'i']      p: -1       branch : 1a       Expected: false"
printfn "Result %b" (Rotate.validRotate (Rotate.create 3u) -1)
printfn "passed: %b" (Rotate.validRotate (Rotate.create 3u) -1 = false)
printfn ""
printfn "b: ['a'..'i']      p: 0       branch : 1a       Expected: true"
printfn "Result %b" (Rotate.validRotate (Rotate.create 3u) 0)
printfn "passed: %b" (Rotate.validRotate (Rotate.create 3u) 0 = true)
printfn ""
printfn "b: ['a'..'i']      p: 2       branch : 1b       Expected: false"
printfn "Result %b" (Rotate.validRotate (Rotate.create 3u) 2)
printfn "passed: %b" (Rotate.validRotate (Rotate.create 3u) 2 = false)
printfn ""
printfn "b: ['a'..'i']      p: -1       branch : 1a       Expected: false"
printfn "Result %b" (Rotate.validRotate (Rotate.create 3u) -1)
printfn "passed: %b" (Rotate.validRotate (Rotate.create 3u) -1 = false)
printfn ""

printfn "Whitebox test of rotate (b:Board) (p:Position) : Board"
printfn "b: ['a'..'i']      p: -1        branch : 1a      Expected: ['a';'b';'c';'d';'e';'f';'g';'h';'i']"
printfn "Result %A" (Rotate.rotate (Rotate.create 3u) -1)
printfn "passed: %b" (Rotate.rotate (Rotate.create 3u) -1 = ['a'..'i'])

printfn "Whitebox test of scramble (b:Board) (m:uint) : Board"

printfn "Whitebox test of solved (b:Board) : bool"
printfn "b: ['a'..'i']      branch : 1a         Expected: true"
printfn "Result %A" (Rotate.solved (Rotate.create 3u))
printfn "passed %b" (Rotate.solved (Rotate.create 3u) = true)
printfn ""
printfn "b: ['a';'c';'b';'d';'f';'g';'e';'h';'i']      branch : 1b         Expected: false"
printfn "Result %A" (Rotate.solved (Rotate.create 3u))
printfn "passed %b" (Rotate.solved (['a';'c';'b';'d';'f';'g';'e';'h';'i']) = false)
printfn ""