open System.Net
open System

///<summary>Counts the amount of links on a website</summary>
///<param name="url">The URL of the website which is searched for links</param>
///<returns>An int, the amount of links found on the site.</returns>
let countLinks (url:string) : int =
    try
        let fetchUrl (url:string) : string =
            let req = WebRequest.Create(Uri(url)) // make request
            use resp = req.GetResponse()
            use stream = resp.GetResponseStream()
            use reader = new IO.StreamReader(stream)
            in reader.ReadToEnd()
        printfn "%A" (fetchUrl url)
        let countSubstring (str:string) (substring:string) : int =
            printfn "%A" (str.Length - str.Replace(substring, "").Length)
            printfn "%A" substring.Length
            match substring with
                | "" -> 0
                | _ -> (str.Length - str.Replace(substring, "").Length) / substring.Length

        countSubstring (fetchUrl url) "</a>"
    with 
        | _ -> 1

printfn "%d" (countLinks  "https://www.erdetfredag.dk/")
