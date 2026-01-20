using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace MiniMart.Models
{
    public class Product
    {
        //- Malak Hussein Ahmed Mohamed- Fayoum University - Faculty of Computers and Artificial Intelligence -  Up to level 4
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to provide a valid name.")]
        [MinLength(3, ErrorMessage = "Name musn't be less than 3 characters.")]
        [MaxLength(30, ErrorMessage = "Name musn't exceed 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You have to provide a valid Description.")]
        [MinLength(3, ErrorMessage = "Description musn't be less than 3 characters.")]
        [MaxLength(150, ErrorMessage = "Description musn't exceed 150 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You have to provide a valid Price")]
        [Range(0.01, 200_000, ErrorMessage = "Price must be between 0.01 EGP and 200_000 EGP.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "You have to provide a valid Image Url.")]
        [MinLength(5, ErrorMessage = "Image Url musn't be less than 5 characters.")]
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }

        [DisplayName("Category")]
        [Range(1, int.MaxValue, ErrorMessage = "Choose a valid Category.")]
        public int CategoryId { get; set; }


        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Category Category { get; set; }
    }
}
