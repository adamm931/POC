
using System.Web.Mvc;

namespace POC.Web.Validation.Extensions
{
    public static class ModelValidatorProviderExtensions
    {
        public static void AddPocModelValidatorProvider(this ModelValidatorProviderCollection collection)
        {
            collection.Add(new PocModelValidatorProvider());
        }
    }
}
