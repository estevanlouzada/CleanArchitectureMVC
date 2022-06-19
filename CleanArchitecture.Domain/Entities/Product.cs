using CleanArchitecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Product : Entity
    {        
        public string Name { get; private  set; }
        
        public string Description  { get; private  set; }
        
        public decimal Price { get; private set; }
        
        public int Stock { get; private set; }

        public string Image { get; private set; }

        public int CategoryId { get;  set; }
        public Category Category { get;  set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidationId(id);
            ValidateDomain(name, description, price, stock, image);
            
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            
            ValidateDomain(name, description, price, stock, image);
            
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId, Category category)
        {

            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
            Category = category;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name too short, minimum 3 characteres is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid name.Name is required");

            DomainExceptionValidation.When(description?.Length < 5 , "Invalid name too short, minimum 5 characteres is required");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid price value");

            DomainExceptionValidation.When(image.Length > 255, 
                "Invalid name image, too long , maximun 250 characteres");


            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        private void ValidationId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
        }
    }
}
