using CP_SDK.Logging;
using HarmonyLib;
using IPA;

namespace BeatSaberPlus_EnergyLaser;

/// <summary>
///     Main plugin class
/// </summary>
[Plugin(RuntimeOptions.SingleStartInit)]
public class Plugin
{
    /// <summary>
    ///     Harmony ID for patches
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    internal const string HARMONY_ID = "com.github.kuurama.energylaser";

    /// <summary>
    ///     Harmony patch holder
    /// </summary>
    internal static Harmony s_Harmony = null!;

    /// <summary>
    ///     Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it
    ///     starts disabled).
    /// </summary>
    /// <param name="p_Logger">Logger instance</param>
    [Init]
    public Plugin(IPA.Logging.Logger p_Logger)
    {
        s_Harmony = new Harmony(HARMONY_ID);

        /// Setup logger
        Logger.Instance = new IPALogger(p_Logger);
    }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     On BeatSaberPlus enable
    /// </summary>
    [OnEnable]
    public void OnEnable() { }

    /// <summary>
    ///     On BeatSaberPlus disable
    /// </summary>
    [OnDisable]
    public void OnDisable() => s_Harmony.UnpatchSelf();
}
