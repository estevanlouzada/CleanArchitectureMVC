using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Domain.Test
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptioInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptioShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name too short, minimum 3 characteres is required");
        }


        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptioRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptioInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
