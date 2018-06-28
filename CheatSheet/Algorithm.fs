module Algorithm

let sum n = 
    let rec sum' acc = function 
        | 0 -> acc
        | n -> sum' (acc + n) (n - 1)
    sum' 0 n

let rec fibonacci = function
    | 0 -> 0
    | 1 -> 1
    | n -> fibonacci (n - 1) + fibonacci (n - 2)

let rec factorial = function
    | 0 | 1 -> 1
    | n -> n * factorial (n - 1)

let rec gcd a b = 
    match b with
    | 0 -> a
    | _ -> match b < a with
           | true -> gcd b (a - b)
           | false -> gcd (b - a) a

let fizzBuzz n =
    match n % 3, n % 5 with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> string n