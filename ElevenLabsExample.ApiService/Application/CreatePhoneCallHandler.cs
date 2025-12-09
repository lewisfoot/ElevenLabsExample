using ElevenLabsExample.ApiService.Infrastructure;
using ElevenLabsExample.ApiService.Models;
using ElevenLabsExample.Common;

namespace ElevenLabsExample.ApiService.Application;

public class CreatePhoneCallHandler : ICreatePhoneCallHandler
{
    private readonly IElevenLabsService _elevenLabsService;
    private readonly IPhoneCallRepository _phoneCallRepository;

    public CreatePhoneCallHandler(IElevenLabsService elevenLabsService,
        IPhoneCallRepository phoneCallRepository)
    {
        _elevenLabsService = elevenLabsService;
        _phoneCallRepository = phoneCallRepository;
    }

    public async Task CreatePhoneCall(CreatePhoneCallDto createPhoneCallDto, CancellationToken cancellationToken)
    {
        try
        {
            //Map dto to domain model. 
            PhoneCall phoneCall = new();
            await _phoneCallRepository.AddPhoneCallAsync(phoneCall, cancellationToken);
            await _elevenLabsService.CreateElevenLabsPhoneCall(cancellationToken);
            await _phoneCallRepository.UpdatePhoneCallStatusAsync(phoneCall.Id, "In-Progress", cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
