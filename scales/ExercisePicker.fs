namespace ScalePicker

module ExercisePicker =
    open ScalePicker
    open ArpeggioPicker

    let private pick = ScalePicker.pick Utils.next

    let getRandomExercise () =
        let scale = getRandomScale ()
        let arpeggio = getRandomArpeggio ()

        pick [| "Scale: " + scale; "Arpeggio: " + arpeggio |]
