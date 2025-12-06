using ElevenLabsExample.Common;

namespace ElevenLabsExample.Web;

public class PhoneCallApiClient(HttpClient httpClient)
{
    public async Task<bool> MakePhoneCallAsync(CreatePhoneCallDto dto, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/phonecalls/create", dto, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}