using ActivApartment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ActivApartment.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ActivApartmentController : AbpControllerBase
{
    protected ActivApartmentController()
    {
        LocalizationResource = typeof(ActivApartmentResource);
    }
}
