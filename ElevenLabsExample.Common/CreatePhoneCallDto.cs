namespace ElevenLabsExample.Common;

public record CreatePhoneCallDto(
    string CarerFirstName,
    int PhoneNumber,
    DateOnly VisitDate,
    int VisitDurationMinutes,
    string ClientPostcode);