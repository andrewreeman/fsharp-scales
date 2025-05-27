namespace ScalePicker

module ArpeggioComponents =
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

    let styles = [| "Block"; "Broken"; "Rolling"; "Cross-hands" |]

    let hands = [| "Left hand"; "Right hand"; "Both hands" |]

    let makeOctave i =
        if i = 1 then
            sprintf "%d Octave" i
        else
            sprintf "%d Octaves" i

    let octaves = [| 1; 2; 3; 4 |] |> Array.map makeOctave
