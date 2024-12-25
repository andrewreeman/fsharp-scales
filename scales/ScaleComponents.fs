namespace ScalePickerProg

module ScaleComponents =
    let scales = [| "A"; "Bb"; "B"; "C"; "C#"; "D"; "Eb"; "E"; "F"; "F#"; "G"; "Ab" |]
    let smoothness = [| "stacatto", "legato" |]

    let makeOctave i =
        if i = 1 then
            sprintf "%d Octave" i
        else
            sprintf "%d Octaves" i

    let makeOctaveHand (o, h) = sprintf "%s %s" o h

    let tonality =
        [| "Ionian/Major"
           "Harmonic minor"
           "Melodic minor"
           "Dorian"
           "Phrygian"
           "Mixolydian"
           "Lydian"
           "Aeolian/Natural minor"
           "Locrian"
           "Blues"
           "Pentatonic" |]

    let octaves = [| 1; 2; 3; 4 |] |> Array.map makeOctave
    let hands = [| "Left hand"; "Right hand"; "Both hands" |]
    let octavesAndHands = Utils.cartesian octaves hands |> Array.map makeOctaveHand
    let structures = Array.concat [ [| "Russian"; "Contramotion" |]; octavesAndHands ]
