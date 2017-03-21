// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

module main

open Todo

[<EntryPoint>]
let main argv =

    let rec parseOptions args = 


        (* The following options will be used:
        c desc [state] [priority]-- create new todo
        l           -- list all 
        s <number>  -- change state of the task at number
        p <number>  -- change priority of the given task
        d <number>  -- change deadline of the given task
        r <number>  -- reset the task, i.e. set to todo; remove priority and deadline
        f <t|p|s|d> -- filter by date/priority/state
        q <t|p|s>   -- (quick)sort by date/priority/state
        h           -- show help
        *)

        match args with 
        | [] -> ""
        | "c"::desc::xs -> 
            "Ask for description and run Todo.createNewTask" 
        | "l"::xs -> 
            "List all tasks" 
        | "s"::num::state::xs -> 
            "Change state task at number num" 
        | "p"::num::priority::xs -> 
            "Change priority" 
        | "d"::deadline::priority::xs -> 
            "Change deadline" 
        | "f"::byWhat::criteria::xs -> 
            "Filter" 
        | "q"::byWhat::criteria::xs -> 
            "Sort"
        | "h"::xs -> 
            "Show help"  
        | x::xs -> 
            "Option %s is unrecognised" 
    
    let argList = argv |> Seq.toList
    printfn "%A" argList
    printfn "%s" (parseOptions argList)
    0 // return an integer exit code
