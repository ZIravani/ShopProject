using _0_Framework.Application;

namespace Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult  create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);

        EditProductCategory GetDetails(long id);

        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);


    }
}
