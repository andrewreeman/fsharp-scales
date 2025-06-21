namespace ScalePicker

module ArpeggioComponents =
    type Hand =
        | LeftHand
        | RightHand
        | BothHands
        | CrossHands

    type Style =
        | Block
        | Broken
        | Rolling

        override this.ToString() =
            match this with
            | Block -> "Block"
            | Broken -> "Broken"
            | Rolling -> "Rolling"

    let keys = [| "A"; "Bb"; "B"; "C"; "C#"; "D"; "Eb"; "E"; "F"; "F#"; "G"; "Ab" |]

    let chords =
        [| "Major"
           "Minor"
           "Diminished"
           "Augmented"
           "Major 7th"
           "Minor 7th"
           "Dominant 7th"
           "Half Diminished"
           "Fully Diminished 7th" |]

    let handToString =
        function
        | LeftHand -> "Left hand"
        | RightHand -> "Right hand"
        | BothHands -> "Both hands"
        | CrossHands -> "Cross hands"

    let styleFromString str =
        match str with
        | "Block" -> Block
        | "Broken" -> Broken
        | "Rolling" -> Rolling
        | _ -> failwithf "Unknown style: %s" str

    let makeOctave i =
        if i = 1 then
            sprintf "%d Octave" i
        else
            sprintf "%d Octaves" i

    let octaves = [| 1; 2; 3; 4 |] |> Array.map makeOctave
