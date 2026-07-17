using Moq;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Store;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services;

namespace ShoppingListApi.Tests
{
    public class StoreServiceTests
    {
        [Fact]
        public async Task CreateStoreAsync_WhenStoreIsValid_CreateStore()
        {
            const string userId = "user1";
            var storeRequest = new CreateStoreRequest() { StoreName = "Aldi" };

            var repositoryMock = new Mock<IStoreRepository>();
            repositoryMock.Setup(repository => repository.CreateStoreAsync(It.IsAny<Store>()))
                .ReturnsAsync((Store store) => store);

            var storeService = new StoreService(repositoryMock.Object);
            var result = await storeService.CreateStoreAsync(userId , storeRequest);
            Assert.NotNull(result);
            Assert.Equal(storeRequest.StoreName, result.StoreName);
            Assert.Equal(userId, result.UserId);

            repositoryMock.Verify(repository =>
            repository.CreateStoreAsync(It.Is<Store>(store =>
            store.StoreName == storeRequest.StoreName &&
            store.UserId == userId)),
            Times.Once);

        }

        [Fact]
        public async Task GetStoreByIdAsync_WhenStoreExists_ReturnsStore()
        {
            var store = new Store() { StoreId = 1 , StoreName = "Aldi" , UserId = "1" };

            var repositoryMock = new Mock<IStoreRepository>();
            repositoryMock.Setup(repository => repository.GetStoreByIdAsync(store.StoreId))
                .ReturnsAsync(store);

            var storeService = new StoreService(repositoryMock.Object);
            var result = await storeService.GetStoreByIdAsync(store.StoreId);

            Assert.Same(store, result);

            repositoryMock.Verify(repository =>
            repository.GetStoreByIdAsync(store.StoreId),
            Times.Once);
        }
        [Fact]
        public async Task GetStoresByStoreNameAsync_WhenStoresExist_ReturnsStores()
        {
            var title = "Aldi";
            List<Store> stores = new()
            {
                new Store{ StoreId = 1 , StoreName = "Aldi 1" },
                new Store{ StoreId = 2 , StoreName = "Aldi 2" },
            };

            var repositoryMock = new Mock<IStoreRepository>();
            repositoryMock.Setup(repository => repository.GetStoreByStoreName(title))
                .ReturnsAsync(stores);

            var storeService = new StoreService(repositoryMock.Object);
            var result = await storeService.GetStoresByStoreNameAsync(title);

            Assert.Same(stores, result);

            repositoryMock.Verify(repository => repository.GetStoreByStoreName(title), Times.Once);
            
        }

        [Fact]
        public async Task DeleteStoreByIdAsync_WhenStoreExist_ReturnsTrue()
        {
            var storeId = 1;

            var repositoryMock = new Mock<IStoreRepository>();
            repositoryMock.Setup(repository => repository.DeleteStoreByIdAsync(storeId))
                .ReturnsAsync(true);
            var storeService = new StoreService(repositoryMock.Object);
            var result = await storeService.DeleteStoreByIdAsync(storeId);

            Assert.True(result);

            repositoryMock.Verify(repository => repository.DeleteStoreByIdAsync(storeId),Times.Once);

            
        }


        [Fact]
        public async Task DeleteStoreByIdAsync_WhenStoreDoesNotExist_ReturnsFalse()
        {
            var storeId = 1;

            var repositoryMock = new Mock<IStoreRepository>();
            repositoryMock.Setup(repository => repository.DeleteStoreByIdAsync(storeId))
                .ReturnsAsync(false);
            var storeService = new StoreService(repositoryMock.Object);
            var result = await storeService.DeleteStoreByIdAsync(storeId);

            Assert.False(result);

            repositoryMock.Verify(repository => repository.DeleteStoreByIdAsync(storeId), Times.Once);


        }
    }
}
