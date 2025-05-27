namespace scales.api.Controllers

open Microsoft.AspNetCore.Mvc
open ScalePicker

[<ApiController>]
[<Route("[controller]")>]
type ScaleController() =
    inherit ControllerBase()

    [<HttpGet("")>]
    member _.GetRandomScale() = ScalePicker.getRandomScale ()

    [<HttpGet("arpeggio")>]
    member _.GetRandomArpeggio() = ArpeggioPicker.getRandomArpeggio ()
