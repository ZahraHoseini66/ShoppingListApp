using Moq;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Product;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services;

namespace ShoppingListApi.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProductByIdAsync_WhenProductExists_ReturnProduct()
        {
            const int productId = 2;
            var expectedProduct = new Product
            {
                ProductId = productId,
                Title = "Milk"
            };
            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repository => repository.GetProductByIdAsync(productId)).ReturnsAsync(expectedProduct);
            
            var productservice = new ProductService(repositoryMock.Object);

            var actualProduct = await productservice.GetProductByIdAsync(productId);

            Assert.Same(expectedProduct, actualProduct);

            repositoryMock.Verify(
                repository => repository.GetProductByIdAsync(productId),
                Times.Once);

        }

        [Fact]
        public async Task GetProductByIdAsync_WhenProductDoesNotExist_ReturnNull()
        {
            const int productId = 999;
            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(repository => repository.GetProductByIdAsync(productId)).ReturnsAsync((Product?)null);

            var productService = new ProductService(repositoryMock.Object);

            var actualProduct = await productService.GetProductByIdAsync(productId);

            Assert.Null(actualProduct);

            repositoryMock.Verify(
              repository => repository.GetProductByIdAsync(productId),
              Times.Once);


        }
        [Fact]
        public async Task GetProductsByTitleAsync_WhenProductsExist_ReturnProducts()
        {
            const string title = "Milk";

            List<Product> expectedProducts = new() { 
               new Product(){ ProductId=1, Title= "Milk" ,CategoryId = 1  } ,
             new Product() { ProductId = 2, Title = "Milk Chochlate", CategoryId = 1 }};

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(repository => repository.GetProductsByTitleAsync(title)).ReturnsAsync(expectedProducts);

            var productService = new ProductService(repositoryMock.Object);
            var actualProducts = await productService.GetProductsByTitleAsync(title);

            Assert.Same(expectedProducts , actualProducts);

            repositoryMock.Verify(
              repository => repository.GetProductsByTitleAsync(title),
              Times.Once);


        }
        [Fact]
        public async Task GetProductsByTitleAsync_WhenProductsDoNotExist_ReturnEmptyList()
        {
            const string title = "Milk";
            List<Product> expectedProducts = new();
            
            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repository => repository.GetProductsByTitleAsync(title)).ReturnsAsync(expectedProducts);

            var productService = new ProductService(repositoryMock.Object);

            var actualProducts = await productService.GetProductsByTitleAsync(title);

            Assert.Same(expectedProducts, actualProducts);

            repositoryMock.Verify(
                repository => repository.GetProductsByTitleAsync(title),
                Times.Once);

        }

        [Fact]
        public async Task CreateProductAsync_WhenRequestIsValid_CreatesProduct()
        {
            var request = new CreateProductRequest() { CategoryId = 1, Title = "Milk" };

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repository => repository.CreateProductAsync(It.IsAny<Product>()))
                .ReturnsAsync((Product product) => product);

            ProductService productService = new ProductService(repositoryMock.Object);

            var result =  await productService.CreateProductAsync(request);

            Assert.NotNull(result);
            Assert.Equal(request.Title, result.Title);
            Assert.Equal(request.CategoryId, result.CategoryId);

            repositoryMock.Verify(repository =>
        repository.CreateProductAsync(It.Is<Product>(product =>
            product.Title == request.Title &&
            product.CategoryId == request.CategoryId)),
        Times.Once);


        }






    }
}
