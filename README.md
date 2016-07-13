[![Build status](https://ci.appveyor.com/api/projects/status/s4jjgea8khrku115?svg=true)](https://ci.appveyor.com/project/tatsuya/fsharp-utility-library)

###### fsharp.org
- [F# Language Specification](http://fsharp.org/specs/language-spec)
- [F# Component Design Guidelines](http://fsharp.org/specs/component-design-guidelines)

###### MSDN for F# #
- [Casting and Conversions](https://msdn.microsoft.com/visualfsharpdocs/conceptual/casting-and-conversions-%5bfsharp%5d)
- [Code Formatting Guidelines](https://msdn.microsoft.com/visualfsharpdocs/conceptual/code-formatting-guidelines-%5bfsharp%5d)
- [Computation Expressions](https://msdn.microsoft.com/visualfsharpdocs/conceptual/computation-expressions-%5bfsharp%5d)
- [Constraints](https://msdn.microsoft.com/visualfsharpdocs/conceptual/constraints-%5bfsharp%5d)
- [Core.Operators Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.operators-module-%5bfsharp%5d)
- [Core.Printf Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.printf-module-%5bfsharp%5d)
- [Debugging F#](https://msdn.microsoft.com/en-us/library/ee843932.aspx)
- [Statically Resolved Type Parameters](https://msdn.microsoft.com/visualfsharpdocs/conceptual/statically-resolved-type-parameters-%5bfsharp%5d)
- [Symbol and Operator Reference](https://msdn.microsoft.com/visualfsharpdocs/conceptual/symbol-and-operator-reference-%5bfsharp%5d)
- [Tail calls in F#](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/)

###### Tutorials in Visual Studio Gallery
- [F# Introduction Tutorial - Visual Studio 2010](https://code.msdn.microsoft.com/windowsdesktop/F-Introduction-Tutorial-1707e309)
- [F# Samples 101 - Visual Studio 2010](https://code.msdn.microsoft.com/windowsdesktop/F-Samples-101-0576cb9f)
- [F# 3.0 Sample Pack](https://code.msdn.microsoft.com/windowsdesktop/F-30-Sample-Pack-d06ea11f)

###### Tutorials NOT in Visual Studio Gallery
- New Project > Templates > Visual F# > Tutorial
- [Introductory Micro Samples](https://fsharp3sample.codeplex.com/wikipage?Title=MicroSamples)
- [F# 3.0 Micro Samples](https://fsharp3sample.codeplex.com/wikipage?Title=FSharp3Samples)

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
###### Convert IEnumerable to IEnumerable\<T>
```fsharp
Seq.cast<'T> ie
```

###### How to iterate through DataRowCollection
```fsharp
dt.Rows |> Seq.cast<DataRow> |> Seq.iter (fun dr -> /* Do something */)
```

###### List manipulation
```fsharp
let xs = [ 1 .. 10 ]

printfn "%A" (xs.IsEmpty) // Better than (List.isEmpty xs)
printfn "%A" (xs.Length) // Better than (List.length xs)
printfn "%A" (xs.Head) // Better than (List.head xs)
printfn "%A" (xs.Tail) // Better than (List.tail xs)
printfn "%A" (xs.[2]) // Better than xs.Item(2) or (List.item 2 xs)
```

###### Array manipulation
```fsharp
let ys = [| 1 .. 10 |]
 
printfn "%A" (Array.isEmpty ys)
printfn "%A" (ys.Length) // Better than (Array.length ys)
printfn "%A" (ys.[2]) // Better than (Array.get ys 2)
```
