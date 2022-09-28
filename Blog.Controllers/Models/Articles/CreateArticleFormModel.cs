using System.ComponentModel.DataAnnotations;
using static Blog.DAL.DataValidation.Article;

namespace Blog.Contollers.Models.Articles;

public class CreateArticleFormModel
{
   
   [Required] [MaxLength(MaxTitleLength)] public string Title { get; set; }
   [MaxLength(MaxDescriptionLength)] public string Description { get; set; }
}