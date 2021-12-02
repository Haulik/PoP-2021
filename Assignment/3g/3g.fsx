let sum (n:int) : int = 
    if 1 > n then
        0
    else 
        let mutable sum = 0
        let mutable counter = 0
        while counter < n do   
            let mutable s = 1 + counter
            sum <- sum + s
            counter <- counter + 1
        sum
            
    //while counter < n do    
    //    n+(n+1)


(*
let sum2 (n:int) : int = 
    if 1 > n then
        0
    else 
        //let mutable x = 0
        let mutable counter = 0
        while counter < n do   
            if counter = 0 then
             //   let mutable s = 1 + counter
            s <- s + counter
            if counter = n-1 then
                counter <- s             
        counter
            
    //while counter < n do    
    //    n+(n+1)

    *)


let sum3 (n:int) : int = 
    if 0 > n then
        0
    else 
        (n*(n+1))/2



let sum4 (n:int64) : int64 = 
    if (1L) > n then
        0L
    else 
        let mutable sum = 0L
        let mutable counter = 0L
        while sum >= 0L do   
            let mutable s = 1L + counter
            sum <- sum + s
            counter <- counter + 1L
        //sum
        counter


let sum5 (n:int) : int = 
    if (1) > n then
        0
    else 
        let mutable sum = 0
        let mutable counter = 0
        while sum >= 0 do   
            let mutable s = 1 + counter
            sum <- sum + s
            counter <- counter + 1
        //sum
        counter


let i = sum4 10L
let j = sum5 10
printfn "%A" j
printfn "%A" i