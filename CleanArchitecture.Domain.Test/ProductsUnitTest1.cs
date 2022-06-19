using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Domain.Test
{
    public class ProductsUnitTest1
    {

        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {                               // Product(string name, string description, decimal price, int stock, string image)
            Action action = () => new Product(1,  "Name product",  "Description product",  777,  20,  "Nome da imagem ");
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptioImageName()
        {
            Action action = () => new Product(1, "", "Description product", 777, 20, "product image tooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong  ");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptioShortName()
        {
            Action action = () => new Product(1, "Ca", "Description product", 777, 20, "Nome da imagem ");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name too short, minimum 3 characteres is required");
        }

        [Fact]
        public void CreateProduct_WithNullImage_NotThrowException()
        {                              
            Action action = () => new Product(1, "Name product", "Description product", 777, 20, null);
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptioRequiredName()
        {
            Action action = () => new Product(1, "", "Description product", 777, 20, "Nome da imagem ");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptioInvalidName()
        {
            Action action = () => new Product(1, null, "Description product", 777, 20, "Nome da imagem ");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_NegativeIdValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(value, null, "Description product", 777, 20, "Nome da imagem ");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value");
        }

 
    }
}
