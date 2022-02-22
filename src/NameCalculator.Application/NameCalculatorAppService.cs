using System;
using System.Collections.Generic;
using System.Text;
using NameCalculator.Localization;
using Volo.Abp.Application.Services;

namespace NameCalculator;

/* Inherit your application services from this class.
 */
public abstract class NameCalculatorAppService : ApplicationService
{
    protected NameCalculatorAppService()
    {
        LocalizationResource = typeof(NameCalculatorResource);
    }
}
