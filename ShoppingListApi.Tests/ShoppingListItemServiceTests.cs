
using Moq;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Enums;
using ShoppingListApi.DTOs.ShoppingListItem;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Tests
{
    public class ShoppingListItemServiceTests
    {
        [Fact]
        public async Task CreateShoppingListItemAsync_WhenRequestIsValid_CreatesShoppingListItem()
        {
            var createShoppingListItemRequest = new CreateShoppingListItemRequest { 
             ShoppingListId = 12 , ProductId = 44 , Unit = UnitType.Package , IsChecked = true , Quantity = 2 };

            var repositoryMock = new Mock<IShoppingListItemRepository>();
            repositoryMock.Setup( repository => repository.CreateShippingListItemAsync(It.IsAny<ShoppingListItem>()))
                .ReturnsAsync((ShoppingListItem shoppingList) => shoppingList);

            ShoppingListItemService shoppingListItemService = new ShoppingListItemService(repositoryMock.Object);
            var reuslt = await shoppingListItemService.CreateShoppingListItemAsync(createShoppingListItemRequest);

            Assert.Equal(createShoppingListItemRequest.ShoppingListId, reuslt.ShoppingListId);
            Assert.Equal(createShoppingListItemRequest.ProductId, reuslt.ProductId);
            Assert.Equal(createShoppingListItemRequest.Unit, reuslt.Unit);
            Assert.Equal(createShoppingListItemRequest.IsChecked, reuslt.IsChecked);
            Assert.Equal(createShoppingListItemRequest.Quantity, reuslt.Quantity);

            repositoryMock.Verify(repository => repository.CreateShippingListItemAsync
           (It.Is<ShoppingListItem>(shItem => shItem.ShoppingListId == createShoppingListItemRequest.ShoppingListId &&
           shItem.ProductId == createShoppingListItemRequest.ProductId && shItem.Unit == createShoppingListItemRequest.Unit
           && shItem.IsChecked == createShoppingListItemRequest.IsChecked && shItem.Quantity == createShoppingListItemRequest.Quantity))
           ,Times.Once);

        }

        [Fact]
        public async Task CreateShoppingListItemsAsync_WhenRequestsAreValid_CreatesShoppingListItems()
        {
            List<CreateShoppingListItemRequest> shoppingListItems = new List<CreateShoppingListItemRequest> {
             new CreateShoppingListItemRequest {
             ShoppingListId = 12 , ProductId = 44 , Unit = UnitType.Package , IsChecked = true , Quantity = 2 },
              new CreateShoppingListItemRequest {
             ShoppingListId = 13 , ProductId = 45 , Unit = UnitType.Liter , IsChecked = true , Quantity = 4 }
             };

            var repositoryMock = new Mock<IShoppingListItemRepository>();
            repositoryMock.Setup(repository => repository.CreateShoppingListItemsAsync(It.IsAny<List<ShoppingListItem>>())).ReturnsAsync((List<ShoppingListItem> shoppingListItems) => shoppingListItems);

            var shoppingListItemService = new ShoppingListItemService(repositoryMock.Object);
            var result = await shoppingListItemService.CreateShoppingListItemsAsync(shoppingListItems);

            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(shoppingListItems[0].ShoppingListId, item.ShoppingListId);
                    Assert.Equal(shoppingListItems[0].ProductId, item.ProductId);
                    Assert.Equal(shoppingListItems[0].Unit, item.Unit);
                    Assert.Equal(shoppingListItems[0].Quantity, item.Quantity);
                    Assert.Equal(shoppingListItems[0].IsChecked, item.IsChecked);
                },
                  item =>
                  {
                      Assert.Equal(shoppingListItems[1].ShoppingListId, item.ShoppingListId);
                      Assert.Equal(shoppingListItems[1].ProductId, item.ProductId);
                      Assert.Equal(shoppingListItems[1].Unit, item.Unit);
                      Assert.Equal(shoppingListItems[1].Quantity, item.Quantity);
                      Assert.Equal(shoppingListItems[1].IsChecked, item.IsChecked);
                  }
                );

            repositoryMock.Verify(repository => repository.CreateShoppingListItemsAsync(It.IsAny<List<ShoppingListItem>>()), Times.Once);
          
        }
        [Fact]
        public async Task UpdateCheckedStatusAsync_WhenShoppingListItemExists_ReturnsTrue()
        {
            const int shoppingListItemId = 14;
            const string userId = "1";
            const bool isChecked = true;
            var repositoryMock = new Mock<IShoppingListItemRepository>();
            repositoryMock.Setup(repository => repository.UpdateCheckedStatusAsync(userId, shoppingListItemId, isChecked)).ReturnsAsync(true);

            var shoppingListItemService = new ShoppingListItemService(repositoryMock.Object);
            var result = await shoppingListItemService.UpdateCheckedStatusAsync(userId, shoppingListItemId, isChecked);
            Assert.True(result);
            repositoryMock.Verify(repository => repository.UpdateCheckedStatusAsync(userId, shoppingListItemId, isChecked), Times.Once);
        }

        [Fact]
        public async Task UpdateCheckedStatusAsync_WhenShoppingListItemDoesNotExist_ReturnsFalse()
        {
            const int shoppingListItemId = 14;
            const string userId = "1";
            const bool isChecked = true;
            var repositoryMock = new Mock<IShoppingListItemRepository>();
            repositoryMock.Setup(repository => repository.UpdateCheckedStatusAsync(userId, shoppingListItemId, isChecked)).ReturnsAsync(false);

            var shoppingListItemService = new ShoppingListItemService(repositoryMock.Object);
            var result = await shoppingListItemService.UpdateCheckedStatusAsync(userId, shoppingListItemId, isChecked);

            Assert.False(result);
            repositoryMock.Verify(repository => repository.UpdateCheckedStatusAsync(userId, shoppingListItemId, isChecked), Times.Once);
        }
        [Fact]
        public async Task DeleteShoppingListItemAsync_WhenShoppingListItemExists_ReturnsTrue()
        {
            const string userId = "1";
            const int shoppingListItemId = 14;
            var repositoryMock = new Mock<IShoppingListItemRepository>();
            repositoryMock.Setup(repository => repository.DeleteShoppingListItemAsync(userId, shoppingListItemId)).ReturnsAsync(true);

            var shoppingListItemService = new ShoppingListItemService(repositoryMock.Object);
            var result = await shoppingListItemService.DeleteShoppingListItemAsync(userId, shoppingListItemId);

            Assert.True(result );

            repositoryMock.Verify(repository => repository.DeleteShoppingListItemAsync(userId, shoppingListItemId), Times.Once);
        }
        [Fact]
        public async Task DeleteShoppingListItemAsync_WhenShoppingListItemDoesNotExist_ReturnsFalse()
        {
            const string userId = "1";
            const int shoppingListItemId = 14;
            var repositoryMock = new Mock<IShoppingListItemRepository>();
            repositoryMock.Setup(repository => repository.DeleteShoppingListItemAsync(userId, shoppingListItemId)).ReturnsAsync(false);

            var shoppingListItemService = new ShoppingListItemService(repositoryMock.Object);
            var result = await shoppingListItemService.DeleteShoppingListItemAsync(userId, shoppingListItemId);

            Assert.False(result);

            repositoryMock.Verify(repository => repository.DeleteShoppingListItemAsync(userId, shoppingListItemId), Times.Once);
        }
    }
}
