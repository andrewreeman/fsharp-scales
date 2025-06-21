namespace scales.api.Controllers

open Microsoft.AspNetCore.Mvc
open ScalePicker

[<ApiController>]
[<Route("[controller]")>]
type ExerciseController() =
    inherit ControllerBase()

    [<HttpGet("scale")>]
    member _.GetRandomScale() = ScalePicker.getRandomScale ()

    [<HttpGet("arpeggio")>]
    member _.GetRandomArpeggio() = ArpeggioPicker.getRandomArpeggio ()

    [<HttpGet("")>]
    member _.GetRandomExercise() = ExercisePicker.getRandomExercise ()
