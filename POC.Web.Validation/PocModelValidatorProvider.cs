using System.Collections.Generic;
using System.Web.Mvc;

namespace POC.Web.Validation
{
    public class PocModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        public new IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            var retVal = base.GetValidators(metadata, context);

            return retVal;
        }
    }
}
