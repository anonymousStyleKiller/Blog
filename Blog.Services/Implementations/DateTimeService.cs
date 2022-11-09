using Blog.Services.Interfaces;

namespace Blog.Services.Implementations;

public class DateTimeService : IDateTimeService
{
    public DateTime Now()=>DateTime.UtcNow;
    
}