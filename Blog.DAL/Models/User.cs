using Microsoft.AspNetCore.Identity;

namespace Blog.DAL.Models;

public class User : IdentityUser
{
    public ICollection<Article> Articles { get; set; } = new List<Article>();
}