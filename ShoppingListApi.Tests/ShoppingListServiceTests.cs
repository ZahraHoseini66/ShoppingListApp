using Moq;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Enums;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services;

namespace ShoppingListApi.Tests
{
    public class ShoppingListServiceTests
    {
        [Fact]
        public async Task CreateShoppingListAsync_WhenRequestIsValid_CreatesShoppingList()
        {
            CreateShoppingListRequest shoppingList = new CreateShoppingListRequest() { StoreId = 1, Title = "Monday List" };
            string userId = "1";
            var repositoryMock = new Mock<IShoppingListRepository>();
            repositoryMock.Setup(repository => repository.CreateShoppingListAsync(It.IsAny<ShoppingList>()))
            .ReturnsAsync((ShoppingList shoppingList) => shoppingList);

            ShoppingListService shoppingListService = new ShoppingListService(repositoryMock.Object);
            var result = await shoppingListService.CreateShoppingListAsync(userId, shoppingList);

            Assert.NotNull(result);
            Assert.Equal(result.UserId , userId);
            Assert.Equal(result.Title, shoppingList.Title);
            Assert.Equal(result.StoreId , shoppingList.StoreId);

            repositoryMock.Verify(repository => repository.CreateShoppingListAsync(It.Is<ShoppingList>(
                sh => sh.Title == result.Title && sh.UserId == result.UserId && sh.StoreId == result.StoreId)), Times.Once);
                
        }

        [Fact]
        public async Task GetShoppingListsByShoppingListIdAsync_WhenShoppingListExists_ReturnsShoppingList()
        {
            const string userId = "1";
            const int shoppingListId = 15;
            var expectedShoppingList = new ShoppingListDetailsResponse
            {
                Title = "Monday List",
                ShoppingListId = 15,
                StoreId = 1
            };
            var repositoryMock = new Mock<IShoppingListRepository>();
            repositoryMock.Setup(repository => repository.GetByShoppingListIdAsync(userId, shoppingListId)).ReturnsAsync(expectedShoppingList);

            var shoppingListService = new ShoppingListService(repositoryMock.Object);
            var result = await shoppingListService.GetShoppingListsByShoppingListIdAsync(userId, shoppingListId);

            Assert.Same(expectedShoppingList, result);

            repositoryMock.Verify( repository => repository.GetByShoppingListIdAsync(userId,shoppingListId),Times.Once);
        }

        [Fact]
        public async Task GetShoppingListsByShoppingListIdAsync_WhenShoppingListDoesNotExist_ReturnsNull()
        {
            const string userId = "1";
            const int shoppingListId = 999;
          
            var repositoryMock = new Mock<IShoppingListRepository>();
            repositoryMock.Setup(repository => repository.GetByShoppingListIdAsync(userId, shoppingListId)).ReturnsAsync((ShoppingListDetailsResponse?)null);

            var shoppingListService = new ShoppingListService(repositoryMock.Object);
            var result = await shoppingListService.GetShoppingListsByShoppingListIdAsync(userId, shoppingListId);

            Assert.Null(result);
            repositoryMock.Verify(repository => repository.GetByShoppingListIdAsync(userId, shoppingListId), Times.Once);
        }

        [Fact]
        public async Task GetShoppingListsByUserIdAsync_WhenShoppingListsExist_ReturnsShoppingLists()
        {
            const string userId = "1";

            var shoppingLists = new List<ShoppingListSummaryResponse>(){
                new ShoppingListSummaryResponse{ Title = "Monday List",
                CreatedAt = new DateTime(2026,7,7), 
                StoreId = 15 ,
                ShoppingListId = 14,
                Status = ShoppingListStatus.Active},
                 new ShoppingListSummaryResponse{ Title = "Wendsday List",
                CreatedAt = new DateTime(2026,7,8),
                StoreId = 16 ,
                ShoppingListId = 15,
                Status = ShoppingListStatus.Active}
            };

            var repositoryMock = new Mock<IShoppingListRepository>();
            repositoryMock.Setup(repository => repository.GetByUserIdAsync(userId)).ReturnsAsync(shoppingLists);

            var shoppingListService = new ShoppingListService(repositoryMock.Object);
            var result = await shoppingListService.GetShoppingListsByUserIdAsync(userId);

            Assert.Same(shoppingLists, result);

            repositoryMock.Verify(repository => repository.GetByUserIdAsync(userId),Times.Once);
            
        
        }

        [Fact]
        public async Task GetShoppingListsByUserIdAsync_WhenShoppingListsDoNotExist_ReturnsEmptyList()
        {
            const string userId = "1";

            List<ShoppingListSummaryResponse> shoppingLists = new List<ShoppingListSummaryResponse>();

            var repositoryMock = new Mock<IShoppingListRepository>();
            repositoryMock.Setup(repository => repository.GetByUserIdAsync(userId)).ReturnsAsync(shoppingLists);

            var shoppingListService = new ShoppingListService(repositoryMock.Object);
            var result = await shoppingListService.GetShoppingListsByUserIdAsync(userId);

            Assert.Empty(result);

            repositoryMock.Verify(repository => repository.GetByUserIdAsync(userId), Times.Once);


        }
    }
}
