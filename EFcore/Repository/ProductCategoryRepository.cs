using _0_Framework.Infrastructure;
using Contracts.ProductCategory;
using ShopManagmentDomain.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        //public void Create(ProductCategory entity)
        //{
        //    _shopContext.productCategories.Add(entity);
        //}

        public bool Exists(string name)
        {
            return _shopContext.productCategories.Any(x => x.Name == name);
        }

        //public List<ProductCategory> GetAll()
        //{
        //    return _shopContext.productCategories.ToList();
        //}

        //public ProductCategory GetById(long id)
        //{
        //    return _shopContext.productCategories.Find(id);    
        //}

        public EditProductCategory GetDetails(long id)
        {
           return _shopContext.productCategories.Select(x=> new EditProductCategory()
           {
               Id = x.Id,
               Description=x.Description,
               Name = x.Name,
               Keywords = x.Keywords,
               MetaDescription = x.MetaDescription,
               Picture=x.Picture, 
               PictureAlt=x.PictureAlt,
               PictureTitle=x.PictureTitle,
               Slug=x.Slug
           }).FirstOrDefault(x=>x.Id == id); 
        }

        //public void SaveChanges()
        //{
        //    _shopContext.SaveChanges();
        //}

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchmodel)
        {
            var query = _shopContext.productCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate.ToString(),
                Name = x.Name,
                Picture = x.Picture
            });
            
            if(!string.IsNullOrWhiteSpace(searchmodel.Name))
                query=query.Where(x=>x.Name.Contains(searchmodel.Name));

            return query.ToList();

        }

        public void Update(ProductCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
