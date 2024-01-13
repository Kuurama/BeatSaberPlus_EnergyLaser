using BeatSaberPlus_EnergyLaser.UI;
using CP_SDK;
using CP_SDK.UI;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BeatSaberPlus_EnergyLaser;

/// <summary>
///     Online instance
/// </summary>
[SuppressMessage("ReSharper", "UnusedType.Global")]
internal class EnergyLaserModule : ModuleBase<EnergyLaserModule>
{
    private SettingsMainView? m_SettingsMainView;

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    public override EIModuleBaseType           Type           { get => EIModuleBaseType.Integrated; }
    public override EIModuleBaseActivationType ActivationType { get => EIModuleBaseActivationType.OnStart; }

    public override string Name            { get => "EnergyLaser"; }
    public override string Description     { get => "Allows you to add and customize the length and color around the energy laser bar (the health bar)"; }
    public override bool   UseChatFeatures { get => false; }

    public override bool IsEnabled
    {
        get => MTConfig.Instance.Enabled;
        set
        {
            MTConfig.Instance.Enabled = value;
            MTConfig.Instance.Save();
        }
    }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     Enable the Module
    /// </summary>
    protected override void OnEnable() => Plugin.s_Harmony.PatchAll(Assembly.GetExecutingAssembly());

    /// <summary>
    ///     Disable the Module
    /// </summary>
    protected override void OnDisable() => Plugin.s_Harmony.UnpatchSelf();

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     Get Module settings UI
    /// </summary>
    protected override (IViewController, IViewController, IViewController) GetSettingsViewControllersImplementation()
    {
        m_SettingsMainView ??= UISystem.CreateViewController<SettingsMainView>();

        return (m_SettingsMainView, null, null)!;
    }
}
