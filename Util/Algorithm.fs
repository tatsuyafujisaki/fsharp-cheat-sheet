module Algorithm

let sum n = 
    let rec f n acc = 
        if n <= 0 then acc
        else f (n - 1) (acc + n)
    f n 0

let rec fibonacci n = 
    if n < 2 then 1
    else fibonacci (n - 1) + fibonacci (n - 2)

let rec factorial n = 
    if n = 0 then 1
    else n * factorial (n - 1)

let rec gcd a b = 
    if b = 0 then a
    elif b < a then gcd b (a - b)
    else gcd (b - a) a