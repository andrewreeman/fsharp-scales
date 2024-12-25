namespace ScalePickerProg

open System

module Utils =
    let rand = new Random()
    let next = rand.Next

    let cartesian xs ys =
        xs |> Array.collect (fun x -> ys |> Array.map (fun y -> x, y))
