﻿using System.ComponentModel.DataAnnotations;
using static Blog.DAL.DataValidation.Article;

namespace Blog.DAL.Models;

public class Article
{
    public int Id { get; set; }
    [Required] [MaxLength(MaxTitleLength)] public string Title { get; set; }
    [MaxLength(MaxTitleLength)] public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    [Required] public string AuthorId { get; set; }
    public User Author { get; set; }
}