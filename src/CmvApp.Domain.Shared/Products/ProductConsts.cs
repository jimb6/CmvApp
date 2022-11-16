namespace CmvApp.Products
{
    public static class ProductConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Product." : string.Empty);
        }

    }
}