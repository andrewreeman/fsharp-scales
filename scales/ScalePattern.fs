namespace ScalePicker

module ScalePattern =
    type DyadInterval =
        | Third
        | Octave

        override this.ToString() =
            match this with
            | Third -> "third"
            | Octave -> "octave"

    type HandsInterval =
        | Third
        | Fourth
        | Sixth

        override this.ToString() =
            match this with
            | Third -> "third"
            | Fourth -> "fourth"
            | Sixth -> "sixth"

    type ScalePattern =
        | Single
        | Dyads of DyadInterval
        | HandsApart of HandsInterval

        override this.ToString() =
            match this with
            | Single -> ""
            | Dyads interval -> sprintf "In %ss dyads" (interval.ToString())
            | HandsApart interval -> sprintf "Hands %s apart" (interval.ToString())

    let allPatterns =
        [| Single
           Dyads DyadInterval.Third
           Dyads Octave
           HandsApart Third
           HandsApart Fourth
           HandsApart Sixth |]
        |> Array.map (fun p -> p.ToString())
