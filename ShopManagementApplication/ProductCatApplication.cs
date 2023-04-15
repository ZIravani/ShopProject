

using _0_Framework.Application;
using Contracts.ProductCategory;
using ShopManagmentDomain.ProductCategory;

namespace ShopManagementApplication
{
    public class ProductCatApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCatApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult create(CreateProductCategory command)
        {
           var operation=new OperationResult();
            if (_productCategoryRepository.Exists(command.Name))
                return operation.Failed("رکورد تکراری است.");

            var productcategory = new ProductCategory(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
                command.Keywords, command.MetaDescription, command.Slug);

            _productCategoryRepository.Create(productcategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succeed();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productcategory=_productCategoryRepository.Get(command.Id);
            if (productcategory != null)
                operation.Failed("رکورد وجود ندارد");

            productcategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
                command.Keywords, command.MetaDescription, command.Slug);
            _productCategoryRepository.SaveChanges();

          return  operation.Succeed();

        }

        public EditProductCategory GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}