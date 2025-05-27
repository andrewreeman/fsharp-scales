namespace ScalePicker

module ArpeggioPicker =
    let private pick = ScalePicker.pick Utils.next

    let private allArrs =
        [| ArpeggioComponents.keys
           ArpeggioComponents.chords
           ArpeggioComponents.styles
           ArpeggioComponents.hands
           ArpeggioComponents.octaves |]

    let getRandomArpeggio () =
        allArrs |> Array.map pick |> Array.reduce (fun s a -> s + " " + a)
