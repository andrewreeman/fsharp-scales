namespace ScalePicker

module ArpeggioPicker =
    open ArpeggioComponents
    let private pick = ScalePicker.pick Utils.next

    let getRandomArpeggio () =
        let key = pick keys
        let chord = pick chords

        let style =
            pick
                [| Block.ToString()
                   Broken.ToString()
                   Rolling.ToString()
                |]
        // Get valid hands based on selected style
        let styleType = styleFromString style

        let validHands =
            [| LeftHand; RightHand; BothHands; CrossHands |] |> Array.map handToString

        let hand = pick validHands
        let octave = pick octaves

        sprintf "%s %s %s %s %s" key chord style hand octave
