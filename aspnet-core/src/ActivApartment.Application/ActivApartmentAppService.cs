using System;
using System.Collections.Generic;
using System.Text;
using ActivApartment.Localization;
using Volo.Abp.Application.Services;

namespace ActivApartment;

/* Inherit your application services from this class.
 */
public abstract class ActivApartmentAppService : ApplicationService
{
    protected ActivApartmentAppService()
    {
        LocalizationResource = typeof(ActivApartmentResource);
    }
}
