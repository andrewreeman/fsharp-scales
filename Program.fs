open System

let rand = new Random()

let cartesian xs ys =
    xs |> Array.collect (fun x -> ys |> Array.map (fun y -> x, y))

let makeOctave i =
    if i = 1 then
        sprintf "%d Octave" i
    else
        sprintf "%d Octaves" i

let makeOctaveHand (o, h) = sprintf "%s %s" o h
let pick (a: string[]) = a.[rand.Next(a.Length)]

let scales = [| "A"; "Bb"; "B"; "C"; "C#"; "D"; "Eb"; "E"; "F"; "F#"; "G"; "Ab" |]
let smoothness = [| "stacatto", "legato" |]

let tonality =
    [| "Ionian"
       "Harmonic minor"
       "Melodic minor"
       "Dorian"
       "Phrygian"
       "Mixolydian"
       "Lydian"
       "Aeolian"
       "Locrian"
       "Blues"
       "Pentatonic" |]

let octaves = [| 1; 2; 3; 4 |] |> Array.map makeOctave
let hands = [| "Left hand"; "Right hand"; "Both hands" |]
let octavesAndHands = cartesian octaves hands |> Array.map makeOctaveHand
let structures = Array.concat [ [| "Russian"; "Contramotion" |]; octavesAndHands ]

let allArrs = [| scales; tonality; structures |]
let scaleReducer s a = s + " " + a

let pickedComponents = allArrs |> Array.map pick |> Array.reduce scaleReducer

printfn "Scale: %s" pickedComponents
