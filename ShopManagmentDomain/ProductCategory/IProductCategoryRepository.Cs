using _0_Framework.Domain;
using Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentDomain.ProductCategory
{
    public interface IProductCategoryRepository: IRepository<long, ProductCategory> 
    {
       // void Create(ProductCategory entity);
        
       // ProductCategory GetById(long id);
       // List<ProductCategory> GetAll();
       // bool Exists(string name);
       // void SaveChanges();
        EditProductCategory GetDetails(long id);
        void Update(ProductCategory entity);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchmodel);
        bool Exists(string name);
    }
}
