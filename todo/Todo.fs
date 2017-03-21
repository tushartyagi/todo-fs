namespace Todo

module Core = 

    open System

    type State =
        | Done
        | InProgress
        | Waiting
        | Todo


    type Priority =
        | High
        | Medium
        | Low


    type Task = {
        description: string
        state: State
        deadline: Option<DateTime>
        priority: Option<Priority>
        }

    // Testing
    let tasks = [
        {description = "Wake Up"; state = Done; deadline = None; priority = Some High}
        {description = "Bath"; state = Todo; deadline = None; priority = Some Low}
        {description = "Breakfast"; state = Todo; deadline = Some DateTime.Today; priority = Some Medium}
        ]

    let createNewTask description = 
        {description = description; state = Todo; deadline = None; priority = None}

    let changeState newState task =
        {task with state = newState}
    
    let changeDescription newDescription task =
        {task with description = newDescription}

    let changePriority newPriority task = 
        { task with priority = Some newPriority }

    let changeDeadline newDeadline task = 
        { task with deadline = Some newDeadline }

    let removePriority task = 
        { task with priority = None }

    let removeDeadline task = 
        { task with deadline = None }

    let resetTask = changeState Todo >> removePriority >> removeDeadline 

    let printTask task = 
        printf "%-10s | %-10A |" (task.description.PadRight(10)) task.state
    
        match task.deadline with
        | Some date -> printf "%-15s |" (date.ToString("dd.MM.yy"))
        | None -> printf "%-15s |" ""

        match task.priority with
        | Some priority -> printf "%10A" priority
        | None -> printf "%10s" ""

        printfn ""

    let printAllTasks tasks = 
        let printWithIndex i t = printfn
        tasks |> Seq.iteri (fun i task->                         
                                printf "%i. " (i + 1)
                                printTask task )
    
