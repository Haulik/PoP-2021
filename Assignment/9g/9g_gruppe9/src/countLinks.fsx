open System.Net
open System

let countLinks (url:string) : int =
    try
        let fetchUrl (url:string) : string =
            let req = WebRequest.Create(Uri(url)) // make request
            use resp = req.GetResponse()
            use stream = resp.GetResponseStream()
            use reader = new IO.StreamReader(stream)
            in reader.ReadToEnd()
        let countSubstring (str:string) (substring:string) : int =
            match substring with
                | "" -> 0
                | _ -> (str.Length - str.Replace(substring, "").Length) / substring.Length

        countSubstring (fetchUrl url) "</a>"
    with 
        | _ -> 1