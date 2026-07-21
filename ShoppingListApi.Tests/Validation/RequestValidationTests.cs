using System.ComponentModel.DataAnnotations;
using ShoppingListApi.Domain.Enums;
using ShoppingListApi.DTOs.Product;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.DTOs.ShoppingListItem;
using ShoppingListApi.DTOs.Store;

namespace ShoppingListApi.Tests.Validation
{
    public class RequestValidationTests
    {
        [Fact]
        public void CreateStoreRequest_WhenStoreNameIsValid_HasNoValidationErrors()
        {
            var request = new CreateStoreRequest
            {
                StoreName = "Aldi"
            };

            var validationResults = Validate(request);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void CreateStoreRequest_WhenStoreNameIsEmpty_HasValidationError()
        {
            var request = new CreateStoreRequest
            {
                StoreName = string.Empty
            };

            var validationResults = Validate(request);

            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void CreateProductRequest_WhenTitleIsValid_HasNoValidationErrors()
        {
            var request = new CreateProductRequest
            {
                Title = "Milk",
                CategoryId = 1
            };

            var validationResults = Validate(request);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void CreateProductRequest_WhenTitleIsEmpty_HasValidationError()
        {
            var request = new CreateProductRequest
            {
                Title = string.Empty,
                CategoryId = 1
            };

            var validationResults = Validate(request);

            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void CreateShoppingListRequest_WhenRequestIsValid_HasNoValidationErrors()
        {
            var request = new CreateShoppingListRequest
            {
                Title = "Weekly groceries",
                StoreId = 1
            };

            var validationResults = Validate(request);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void CreateShoppingListRequest_WhenStoreIdIsZero_HasValidationError()
        {
            var request = new CreateShoppingListRequest
            {
                Title = "Weekly groceries",
                StoreId = 0
            };

            var validationResults = Validate(request);

            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void CreateShoppingListItemRequest_WhenRequestIsValid_HasNoValidationErrors()
        {
            var request = new CreateShoppingListItemRequest
            {
                ShoppingListId = 1,
                ProductId = 1,
                Quantity = 2,
                Unit = UnitType.Package,
                IsChecked = false
            };

            var validationResults = Validate(request);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void CreateShoppingListItemRequest_WhenQuantityIsZero_HasValidationError()
        {
            var request = new CreateShoppingListItemRequest
            {
                ShoppingListId = 1,
                ProductId = 1,
                Quantity = 0,
                Unit = UnitType.Package,
                IsChecked = false
            };

            var validationResults = Validate(request);

            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void CreateShoppingListItemRequest_WhenProductIdIsZero_HasValidationError()
        {
            var request = new CreateShoppingListItemRequest
            {
                ShoppingListId = 1,
                ProductId = 0,
                Quantity = 2,
                Unit = UnitType.Package,
                IsChecked = false
            };

            var validationResults = Validate(request);

            Assert.NotEmpty(validationResults);
        }

        private static List<ValidationResult> Validate(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            Validator.TryValidateObject(
                model,
                validationContext,
                validationResults,
                validateAllProperties: true);

            return validationResults;
        }
    }
}
