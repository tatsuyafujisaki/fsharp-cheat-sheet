[![Build status](https://ci.appveyor.com/api/projects/status/awbxjohei2cpxnsp?svg=true)](https://ci.appveyor.com/project/tatsuya/fsharp-cheat-sheet)

###### fsharp.org
* [F# Language Specification](http://fsharp.org/specs/language-spec)
* [F# Component Design Guidelines](http://fsharp.org/specs/component-design-guidelines)
* [Learning F#](http://fsharp.org/learn.html)

###### Docs
* [Access Control](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/access-control)
* [Code Formatting Guidelines](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/code-formatting-guidelines)
* [Compiler Options](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/compiler-options)
* [Computation Expressions](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/computation-expressions)
* [Constraints](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/generics/constraints)
* [Statically Resolved Type Parameters](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/generics/statically-resolved-type-parameters)
* [Symbol and Operator Reference](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/symbol-and-operator-reference/index)

###### MSDN
* [Casting and Conversions](https://msdn.microsoft.com/visualfsharpdocs/conceptual/casting-and-conversions-%5bfsharp%5d)
* [Core.Operators Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.operators-module-%5bfsharp%5d)
* [Core.Printf Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.printf-module-%5bfsharp%5d)
* [Debugging F#](https://msdn.microsoft.com/library/ee843932.aspx)
* [Tail calls in F#](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/)
* [Visual F# Samples and Walkthroughs](https://msdn.microsoft.com/visualfsharpdocs/conceptual/visual-fsharp-samples-and-walkthroughs)

###### Collections
* [Collections.Array Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.array-module-%5bfsharp%5d)
* [Collections.List Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.list-module-%5bfsharp%5d)
* [Collections.List<'T> Union](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.list%5b't%5d-union-%5bfsharp%5d)
* [Collections.Map Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.map-module-%5bfsharp%5d)
* [Collections.Map<'Key,'Value> Class](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.map%5b'key,'value%5d-class-%5bfsharp%5d)
* [Collections.Seq Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.seq-module-%5bfsharp%5d)
* [Collections.Set Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.set-module-%5bfsharp%5d)
* [Collections.Set<'T> Class](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.set%5B't%5D-class-%5Bfsharp%5D)

###### Exceptions
* [failwith](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/exception-handling/the-failwith-function)
* [invalidArg](https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/exception-handling/the-invalidArg-function)
* [invalidOp](https://msdn.microsoft.com/visualfsharpdocs/conceptual/operators.invalidop%5b%27t%5d-function-%5bfsharp%5d)
* [nullArg](https://msdn.microsoft.com/visualfsharpdocs/conceptual/operators.nullarg%5b%27t%5d-function-%5bfsharp%5d)

###### Best practices in settings
* F# Power Tools > Configuration > Project Cache Size > 0
* Project Properties > Build
  * Other flags > "--warnon:1182"
  * Treat warnings as errors > All

###### Best practices in coding
* Use int[] rather than int array.
* Use A.toB rather than B.ofA as follows
  * But there is only way to convert from and to set
* Use "List.collect f xs" rather than "List.concat (List.map f xs)"
* Use "List.map (g >> f) xs" rather than "List.map f (List.map g xs)"

|Better|Worse|
|---|---|
|Array.toSeq|Seq.ofArray|
|Array.toList|List.ofArray|
|Seq.toArray|Array.ofSeq|
|Seq.toList|List.ofSeq|
|List.toArray|Array.ofList|
|List.toSeq|Seq.ofList|
|Set.ofArray|(none)|
|Set.ofSeq|(none)|
|Set.ofList|(none)|
|Set.toArray|(none)|
|Set.toSeq|(none)|
|Set.toList|(none)|

###### Pokemon exception handling
```fsharp
try
    // Do something
with
| _ -> // Do something
```

###### Array manipulation
```fsharp
let xs = [| 1 .. 5 |]

// Use properties rather than functions
printfn "%A" (xs.Length) // Simpler than (Array.length xs)
printfn "%A" (xs.[2]) // Simpler than (Array.get xs 2)
```

###### List manipulation
```fsharp
let xs = [ 1 .. 5 ]

// Use properties rather than functions
printfn "%A" (xs.IsEmpty) // Simpler than (List.isEmpty xs)
printfn "%A" (xs.Length) // Simpler than (List.length xs)
printfn "%A" (xs.Head) // Simpler than (List.head xs)
printfn "%A" (xs.Tail) // Simpler than (List.tail xs)
printfn "%A" (xs.[2]) // Simpler than (xs.Item 2) or (List.item 2 xs)
```

###### Set manipulation
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

###### Map manipulation
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

###### How to initialize a map
```fsharp
let m = Map.ofList [ 1, "one"; 2, "two" ]
```

###### How to initialize a seq
```fsharp
let xs = seq { 0 .. 5 }
```

###### How to initialize a dictionary of .NET Framework
```fsharp
let d = dict [ 1, "one"; 2, "two" ]
```

###### Discriminated union
can have static members such as:
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

###### Pattern matching on records
```fsharp
type Person = { First : string; Last : string }

let person = { First = "John"; Last = "Doe" }

match person with 
| { First = "John" } -> printfn "Hi John !" 
| _  -> printfn "Not John .."
```
