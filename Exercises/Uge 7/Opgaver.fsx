type  weekday = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

//7ø1
let dayToNumber (weekday:weekday) : int =
    match weekday with 
        | Monday-> 1
        | Tuesday -> 2
        | Wednesday -> 3
        | Thursday-> 4
        | Friday -> 5
        | Saturday -> 6
        | Sunday-> 7

//7ø2
let nextDay (day:weekday) : weekday =
    match day with 
        | Monday-> Tuesday
        | Tuesday -> Wednesday
        | Wednesday -> Thursday
        | Thursday-> Friday
        | Friday -> Saturday
        | Saturday -> Sunday
        | Sunday-> Monday


//7ø3
let numberToDay  (n:int) : weekday option =
    match n with 
        | 1 -> Some Monday
        | 2 -> Some Tuesday 
        | 3 -> Some Wednesday
        | 4 -> Some Thursday
        | 5 -> Some Friday 
        | 6 -> Some Saturday 
        | 7 -> Some Sunday
        | _ -> None




printfn "%A" (dayToNumber Tuesday)
printfn "%A" (nextDay Monday)
printfn "%A" (numberToDay 1)