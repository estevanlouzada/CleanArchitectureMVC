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
    public class CategoryUnitTest
    {

        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {                               // Product(string name, string description, decimal price, int stock, string image)
            Action action = () => new Category(1, "Name category");
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_WithValidParameters_DomainExecptionnameToShort()
        {                               // Product(string name, string description, decimal price, int stock, string image)
            Action action = () => new Category(1, "Na");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name too short, minimum 3 characteres is required");
        }
        [Fact]
        public void CreateProduct_WithValidParameters_DomainExcptionInvalidName()
        {                               // Product(string name, string description, decimal price, int stock, string image)
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }
        [Fact]
        public void CreateProduct_WithValidParameters_DomainExceptionNameNull()
        {                               // Product(string name, string description, decimal price, int stock, string image)
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateProduct_WithValidParameters_DomainExceptionId()
        {                               // Product(string name, string description, decimal price, int stock, string image)
            Action action = () => new Category(-1, "Na");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value");
        }



    }
}
