[![Build status](https://ci.appveyor.com/api/projects/status/awbxjohei2cpxnsp?svg=true)](https://ci.appveyor.com/project/tatsuya/fsharp-cheat-sheet)

# Best practices in settings
* `F# Power Tools` > `Configuration` > `Project Cache Size` > `0`
* Project > `Properties` > `Build`
  * `Other flags` > `--warnon:1182`
  * `Treat warnings as errors` > `All`

# Best practices in coding
* A rather than B.
  * Use `int[]` rather than `int array`.
  * Use `A.toB` rather than `B.ofA` as follows
  * Use `List.collect f xs` rather than `List.concat (List.map f xs)`
  * Use `List.map (g >> f) xs` rather than `List.map f (List.map g xs)`
  * Use %A rather than %s to double-quote a string if the string can be empty.

Recommended|Not recommended
---|---
Array.toSeq|Seq.ofArray
Array.toList|List.ofArray
Seq.toArray|Array.ofSeq
Seq.toList|List.ofSeq
List.toArray|Array.ofList
List.toSeq|Seq.ofList
Set.ofArray|(none)
Set.ofSeq|(none)
Set.ofList|(none)
Set.toArray|(none)
Set.toSeq|(none)
Set.toList|(none)

# Pokemon exception handling
```fsharp
try
    // Do something
with
| _ -> // Do something
```

# Array manipulation
```fsharp
let xs = [| 1 .. 5 |]

// Use properties rather than functions
printfn "%A" (xs.Length) // Simpler than (Array.length xs)
printfn "%A" (xs.[2]) // Simpler than (Array.get xs 2)
```

# List manipulation
```fsharp
let xs = [ 1 .. 5 ]

// Use properties rather than functions
printfn "%A" (xs.IsEmpty) // Simpler than (List.isEmpty xs)
printfn "%A" (xs.Length) // Simpler than (List.length xs)
printfn "%A" (xs.Head) // Simpler than (List.head xs) or (xs.Item 0) or (List.item 0 xs)
printfn "%A" (xs.Tail) // Simpler than (List.tail xs)
printfn "%A" (xs.[2]) // Simpler than (xs.Item 2) or (List.item 2 xs)
```

# Set manipulation
```fsharp
let xs = set [ 1 .. 5 ]
let ys = set [ 1 .. 5 ]

// Use properties rather than functions
printfn "%A" (xs.IsEmpty) // Simpler than (Set.isEmpty xs)
printfn "%A" (xs.Count) // Simpler than (Set.count xs)
printfn "%A" (xs.MaximumElement) // Simpler than (Set.maxElement xs)
printfn "%A" (xs.MinimumElement) // Simpler than (Set.minElement xs)
printfn "%A" (xs.Contains 2) // Simpler than (Set.contains 2 xs)
printfn "%A" (xs.Add 6) // Simpler than (Set.add 6 xs)
printfn "%A" (xs.Remove 2) // Simpler than (Set.remove 2 xs)
printfn "%A" (xs.IsProperSubsetOf ys) // Simpler than (Set.isProperSubset xs ys)
printfn "%A" (xs.IsSubsetOf ys) // Simpler than (Set.isSubset xs ys)
printfn "%A" (xs.IsProperSupersetOf ys) // Simpler than (Set.isProperSuperset xs ys)
printfn "%A" (xs.IsSupersetOf ys) // Simpler than (Set.isSuperset xs ys)
```

# Map manipulation
```fsharp
let m = Map.ofArray [| "bacon", 100; "lettuce", 200 |]

// Use properties rather than functions
printfn "%A" (m.IsEmpty) // Simpler than (Map.isEmpty m)
printfn "%A" (m.ContainsKey "lettuce") // Simpler than (Map.containsKey "lettuce" m)
printfn "%A" (m.Count) // "Map.count" does not exist.
printfn "%A" m.["lettuce"] // Simpler than (m.Item "lettuce") or (Map.find "lettuce" m)
printfn "%A" (m.TryFind "bacon") // Simpler than (Map.tryFind "bacon" m)
printfn "%A" (m.Add ("tomato", 300)) // Simpler than (Map.add "tomato" 300 m)
printfn "%A" (m.Remove "lettuce") // Simpler than (Map.remove "lettuce" m)
```

# How to initialize a map
```fsharp
let m = Map.ofList [ 1, "one"; 2, "two" ]
```

# How to initialize a seq
```fsharp
let xs = seq { 0 .. 5 }
```

# How to initialize a dictionary of .NET Framework
```fsharp
let d = dict [ 1, "one"; 2, "two" ]
```

# Discriminated union
Can have static members as follows.
```fsharp
type Rank = 
    /// Represents the rank of cards 2 .. 10
    | Value of int
    | Ace
    | King
    | Queen
    | Jack
    static member GetAllRanks() = 
        [ yield Ace
          for i in 2 .. 10 do yield Value i
          yield Jack
          yield Queen
          yield King ]
```

# Pattern matching on records
```fsharp
type Person = { First : string; Last : string }

let person = { First = "John"; Last = "Doe" }

match person with 
| { First = "John" } -> printfn "Hi John !" 
| _  -> printfn "Not John .."
```

# References
## fsharp.org
* [F# Language Specification](https://fsharp.org/specs/language-spec/)
* [Learning F#](https://fsharp.org/learn/)

## Docs
### Guidelines
* [F# code formatting guidelines](https://docs.microsoft.com/en-us/dotnet/fsharp/style-guide/formatting)
* [F# coding conventions](https://docs.microsoft.com/en-us/dotnet/fsharp/style-guide/conventions)
* [F# component design guidelines](https://docs.microsoft.com/en-us/dotnet/fsharp/style-guide/component-design-guidelines)
* [F# style guide](https://docs.microsoft.com/en-us/dotnet/fsharp/style-guide/)

### Language references
* [F# Language Reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/)
* [Access Control](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/access-control)
* [Casting and Conversions](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/casting-and-conversions)
* [Compiler Options](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/compiler-options)
* [Computation Expressions](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/computation-expressions)
* [Constraints](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/constraints)
* [Keyword reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/keyword-reference)
* [Statically Resolved Type Parameters](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/statically-resolved-type-parameters)
* [Symbol and operator reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/)

### Others
* [Debugging F#](https://docs.microsoft.com/en-us/visualstudio/debugger/debugging-f-hash)
* [Tail calls in F#](https://docs.microsoft.com/en-us/archive/blogs/fsharpteam/tail-calls-in-f)
* [Tour of F#](https://docs.microsoft.com/en-us/dotnet/fsharp/tour)

## Exceptions
* [failwith](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/exception-handling/the-failwith-function)
```fsharp
sprintf "Something went wrong with %A." var1 |> failwith
```
* [invalidArg](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/exception-handling/the-invalidarg-function)
```fsharp
invalidArg "var1" (sprintf "Must be foo, but was %A." var1)
invalidArg "var1" (sprintf "Must be %A, but was %A." (toUnionCase UnionCase1) (toUnionCase var1))
```
* invalidOp
* nullArg
