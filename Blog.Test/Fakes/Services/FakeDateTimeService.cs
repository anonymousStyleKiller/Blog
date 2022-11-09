using Blog.Services.Interfaces;

namespace Blog.Test.Fakes.Services;

public class FakeDateTimeService : IDateTimeService
{
    public DateTime Now() => new(2022, 11, 9);
}