module JsonParser

open FParsec

let private stringReturnCI s result = pstringCI s >>% result

let private stringLiteral =
    let escape =  anyOf "\\nrt\""
                  |>> function
                      | 'n' -> "\n"
                      | 'r' -> "\r"
                      | 't' -> "\t"
                      | c   -> string c

    let unicodeEscape =
        let hex2int c = (int c &&& 15) + (int c >>> 6)*9

        pstring "u" >>. pipe4 hex hex hex hex (fun h3 h2 h1 h0 ->
            (hex2int h3) * 4096 +
            (hex2int h2) * 256 +
            (hex2int h1) * 16 + 
            hex2int h0
            |> char
            |> string
        )

    let escapedCharSnippet = pstring "\\" >>. (escape <|> unicodeEscape)
    let normalCharSnippet  = manySatisfy (fun c -> c <> '"' && c <> '\\')

    between (pstring "\"") (pstring "\"")
            (stringsSepBy normalCharSnippet escapedCharSnippet)

let private listBetweenStrings sOpen sClose pElement f =
    between (pstring sOpen) (pstring sClose)
            (spaces >>. sepBy (pElement .>> spaces) (pstring "," >>. spaces) |>> f)

type Json = JNull
          | JBool   of bool
          | JNumber of float
          | JString of string
          | JList   of Json list
          | JObject of Map<string, Json>

// Use handmade stringReturnCI instead of built-in stringReturn to support case-insensitive null.
let private jnull = stringReturnCI "null" JNull
let private jbool = (stringReturnCI "true"  (JBool true)) <|>
                    (stringReturnCI "false" (JBool false))
let private jnumber = pfloat |>> JNumber
let private jstring = stringLiteral |>> JString

let private jvalue, jvalueRef = createParserForwardedToRef<Json, unit>()

let private jlist = listBetweenStrings "[" "]" jvalue JList
let private jobject =
    let keyValue = stringLiteral .>>. (spaces >>. pstring ":" >>. spaces >>. jvalue)
    listBetweenStrings "{" "}" keyValue (Map.ofList >> JObject)

do jvalueRef := choice [ jnull
                         jbool
                         jnumber
                         jstring
                         jobject
                         jlist ]

let private json = spaces >>. jvalue .>> spaces .>> eof

let printJson s = printfn "%A" (run json s)