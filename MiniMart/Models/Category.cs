using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MiniMart.Models
{
    //- Malak Hussein Ahmed Mohamed- Fayoum University - Faculty of Computers and Artificial Intelligence -  Up to level 4
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }


        [ValidateNever]
        public List<Product> Products { get; set; }
    }
}
