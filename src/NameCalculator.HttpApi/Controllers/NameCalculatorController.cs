using NameCalculator.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NameCalculator.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NameCalculatorController : AbpControllerBase
{
    protected NameCalculatorController()
    {
        LocalizationResource = typeof(NameCalculatorResource);
    }
}
