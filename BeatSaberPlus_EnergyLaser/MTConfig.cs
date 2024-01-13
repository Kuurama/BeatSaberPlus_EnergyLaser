using CP_SDK;
using CP_SDK.Config;
using Newtonsoft.Json;
using UnityEngine;

namespace BeatSaberPlus_EnergyLaser;

/// <summary>
///     Config class helper
/// </summary>
internal class MTConfig : JsonConfig<MTConfig>
{
    [JsonProperty] internal Color Color;
    [JsonProperty] internal bool  Enabled = true;
    [JsonProperty] internal int   Length;

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     Get relative config path
    /// </summary>
    /// <returns></returns>
    public override string GetRelativePath() => $"{ChatPlexSDK.ProductName}/EnergyLaser/Config";

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    /// <summary>
    ///     On config init
    /// </summary>
    /// <param name="p_OnCreation">On creation</param>
    protected override void OnInit(bool p_OnCreation)
    {
        if (p_OnCreation)
        {
            /// Default config values
            Enabled = true;
            Length  = 100;
            Color   = new Color(0.2322f, 0.4457f, 0.86f, 1.0f);
        }

        /// Make sure to save the config (create the file if it doesn't exist)
        Save();
    }
}
