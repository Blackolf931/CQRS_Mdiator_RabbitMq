using CQRS_Mediator.Models;

namespace CQRS_Mediator.DataBase
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>
            {
                new Product{Id = 1, Name = "Test project1" },
                new Product{Id = 2, Name = "Test project2" },
                new Product{Id = 3, Name = "Test project3" },
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

    }
}
