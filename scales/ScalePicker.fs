namespace ScalePicker

module ScalePicker =

    let pick (randNext) (a: string[]) = a.[randNext (a.Length)]

    let allArrs =
        [| ScaleComponents.scales
           ScaleComponents.tonality
           ScaleComponents.structures |]

    let scaleReducer s a = s + " " + a

    let getRandomScale () =
        allArrs |> Array.map (pick Utils.next) |> Array.reduce scaleReducer
