using CleanArchitecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Category: Entity
    {
        public string Name { get; private set; }

       

        public Category(int id, string name)
        {
            ValidationId(id);
            ValidateDomain(name);

        }

        public Category( string name)
        {
            ValidateDomain(name);
        }

        // propertir of navigation don´t have  a property from type to represent 
        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name too short, minimum 3 characteres is required");

            Name = name;
        }

        private void ValidationId(int id )
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
    }
}
