using Volo.Abp.Settings;

namespace NameCalculator.Settings;

public class NameCalculatorSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NameCalculatorSettings.MySetting1));
    }
}
