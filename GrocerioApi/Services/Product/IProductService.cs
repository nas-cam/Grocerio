using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioModels.Product;
using GrocerioModels.Requests.Product;
using GrocerioModels.Response.Product;

namespace GrocerioApi.Services.Product
{
    public interface IProductService
    {
        List<ProructTypeItem> GetProductTypes();
        public InsertProductResponse Insert(InsertProductRequest request);
        GrocerioModels.Product.Product GetProductById(int productId);
        List<GrocerioModels.Product.Product> GetAllProducts(string searchTerm, int categoryId, GrocerioModels.Enums.Product.Type productType);
        InsertProductResponse EditProduct(EditProductRequest request);
    }
}
