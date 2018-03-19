using ITI.PrimarySchool.WebApp.Models.StockViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.PrimarySchool.WebApp.Services
{
    public class StockService
    {
        private List<ProductViewModel> _products;

        public StockService()
        {
            _products = new List<ProductViewModel>();

            _products.Add(new ProductViewModel()
            {
                Id = Guid.NewGuid(),
                Name = "Produit 1",
                Price = 30,
                Quantity = 1,
                Weight = 120
            });

            _products.Add(new ProductViewModel()
            {
                Id = Guid.NewGuid(),
                Name = "Produit 2",
                Price = 50,
                Quantity = 5,
                Weight = 1000
            });
        }

        public IReadOnlyList<ProductViewModel> Products
        {
            get => _products;
        }

        public ProductViewModel Create(string name, int price, int quantity, int weight)
        {
            var product = new ProductViewModel
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Quantity = quantity,
                Weight = weight
            };

            _products.Add(product);

            return product;
        }

        public ProductViewModel Update(ProductViewModel model)
        {
            var existingProduct = _products.SingleOrDefault(x => x.Id == model.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = model.Name;
                existingProduct.Price = model.Price;
                existingProduct.Quantity = model.Quantity;
                existingProduct.Weight = model.Weight;

                return existingProduct;
            }

            return null;
        }

        public bool Delete(Guid id)
        {
            var deleted = _products.RemoveAll(x => x.Id == id);
            return deleted > 0;
        }
    }
}
