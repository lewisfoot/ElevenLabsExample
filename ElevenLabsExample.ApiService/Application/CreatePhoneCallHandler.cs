using ElevenLabsExample.ApiService.Infrastructure;
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
        await _phoneCallRepository.AddPhoneCall(cancellationToken);
        await _elevenLabsService.CreateElevenLabsPhoneCall(cancellationToken);
    }
}
