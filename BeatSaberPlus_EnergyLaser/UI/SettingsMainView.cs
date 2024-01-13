using CP_SDK.UI;
using CP_SDK.XUI;

namespace BeatSaberPlus_EnergyLaser.UI;

/// <summary>
///     EnergyLaser settings view controller
/// </summary>
internal sealed class SettingsMainView : ViewController<SettingsMainView>
{
    private XUIColorInput? m_Color;
    private XUISlider?     m_Length;

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     Construct the UI and bind the events
    /// </summary>
    protected override void OnViewCreation()
    {
        Templates.FullRectLayoutMainView(
                Templates.TitleBar("Module EnergyLaser | Settings"),
                XUIText.Make("Length"),
                XUISlider.Make("Length")
                    .SetMinValue(5)
                    .SetMaxValue(200)
                    .SetInteger(true)
                    .SetValue(MTConfig.Instance.Length)
                    .OnValueChanged(_ => OnSettingChanged())
                    .Bind(ref m_Length),
                XUIText.Make("Color"),
                XUIColorInput.Make()
                    .SetValue(MTConfig.Instance.Color)
                    .OnValueChanged(_ => OnSettingChanged())
                    .Bind(ref m_Color)
            )
            .SetBackground(true)
            .BuildUI(transform);
    }

    /// <summary>
    ///     On view deactivation
    /// </summary>
    protected override void OnViewDeactivation() => MTConfig.Instance.Save();


    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     Apply the new settings to the config instance
    /// </summary>
    private void OnSettingChanged()
    {
        /// Check if we have all the required components
        if (m_Length == null || m_Color == null) return;

        /// Update config
        MTConfig.Instance.Length = (int)m_Length.Element.GetValue();
        MTConfig.Instance.Color  = m_Color.Element.GetValue();
    }
}
