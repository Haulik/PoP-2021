let string = "Hello world"
let stringcut = string.IndexOf(" ")

printfn "%A" string
printfn "%A" string.[0..stringcut-1]
printfn "%A" string.[stringcut+1..]