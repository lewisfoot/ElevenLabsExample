namespace ElevenLabsExample.Common;

public record CreatePhoneCallDto(
    string CarerFirstName,
    int PhoneNumber,
    DateTime VisitDate,
    int VisitDurationMinutes,
    string ClientPostcode);