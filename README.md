[![Build status](https://ci.appveyor.com/api/projects/status/s4jjgea8khrku115?svg=true)](https://ci.appveyor.com/project/tatsuya/fsharp-utility-library)

###### fsharp.org
- [F# Language Specification](http://fsharp.org/specs/language-spec)
- [F# Community Projects](http://fsharp.org/community/projects)
- [F# Component Design Guidelines](http://fsharp.org/specs/component-design-guidelines)

###### MSDN for F# #
- [Debugging F#](https://msdn.microsoft.com/en-us/library/vstudio/ee843932.aspx)
- [Code Formatting Guidelines (F#)](https://msdn.microsoft.com/en-us/library/dd233191.aspx)
- [Symbol and Operator Reference (F#)](https://msdn.microsoft.com/en-us/library/dd233228.aspx)
- [Constraints (F#)](https://msdn.microsoft.com/en-us/library/dd233203.aspx)
- [Casting and Conversions (F#)](https://msdn.microsoft.com/en-us/library/dd233220.aspx)
- [Core.Operators Module (F#)](https://msdn.microsoft.com/en-us/library/ee353754.aspx)
- [Core.Printf Module (F#)](https://msdn.microsoft.com/en-us/library/ee370560.aspx)
- [Computation Expressions (F#)](https://msdn.microsoft.com/en-us/library/dd233182.aspx)
- [Statically Resolved Type Parameters (F#)](https://msdn.microsoft.com/en-us/library/dd548046.aspx)
- [Tail calls in F#](http://blogs.msdn.com/b/fsharpteam/archive/2011/07/08/tail-calls-in-fsharp.aspx)

###### Tutorials in Visual Studio Gallery
- [F# Introduction Tutorial - Visual Studio 2010](https://code.msdn.microsoft.com/windowsdesktop/F-Introduction-Tutorial-1707e309)
- [F# Samples 101 - Visual Studio 2010](https://code.msdn.microsoft.com/windowsdesktop/F-Samples-101-0576cb9f)
- [F# 3.0 Sample Pack](https://code.msdn.microsoft.com/windowsdesktop/F-30-Sample-Pack-d06ea11f)

###### Tutorials NOT in Visual Studio Gallery
- New Project > Templates > Visual F# > Tutorial
- [Introductory Micro Samples](https://fsharp3sample.codeplex.com/wikipage?Title=MicroSamples)
- [F# 3.0 Micro Samples](https://fsharp3sample.codeplex.com/wikipage?Title=FSharp3Samples)

###### F# Interactive
https://msdn.microsoft.com/en-us/library/dd233175.aspx
```batch
"%ProgramFiles(x86)%\Microsoft SDKs\F#\4.0\Framework\v4.0\Fsi.exe"
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

###### Type parameter
* ^T: Type parameter resolved at compile time
* 'T: Type parameter resolved at run time

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
