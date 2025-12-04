using ElevenLabsExample.ApiService.Application;
using ElevenLabsExample.Common;
using Microsoft.AspNetCore.Mvc;

namespace ElevenLabsExample.ApiService.Presentation;

public static class PhoneCallEndpoints
{
    public static void MapPhoneCallEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/phonecalls/");

        group.MapPost("create", CreatePhoneCall);
    }

    public static async Task<IResult> CreatePhoneCall(
        [FromBody] CreatePhoneCallDto createPhoneCallDto,
        ICreatePhoneCallHandler createPhoneCallHandler,
        CancellationToken cancellationToken)
    {
        await createPhoneCallHandler.CreatePhoneCall(createPhoneCallDto, cancellationToken);
        return TypedResults.Created("");
    }
}
