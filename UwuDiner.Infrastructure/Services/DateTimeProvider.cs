using UwuDiner.Application.Interfaces.Services;

namespace UwuDiner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
  public DateTime UtcNow => DateTime.UtcNow;
}
