using BeatSaberPlus_EnergyLaser.Utils;
using HarmonyLib;
using System;

namespace BeatSaberPlus_EnergyLaser.Patches;

[HarmonyPatch(typeof(EnvironmentSceneSetup), nameof(EnvironmentSceneSetup.InstallBindings))]
internal class OnSceneLoadedPatch
{
    private const string LASER_TRANSFORM_NAME = "EnergyPanel.Laser";

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    public static void Postfix()
    {
        try
        {
            /// Get laser object
            var l_Laser = GameObjectFinder.FindGameObject(LASER_TRANSFORM_NAME);
            if (l_Laser == null) throw new Exception("Laser not found");

            /// Set laser object to active
            l_Laser.gameObject.SetActive(true);

            /// Get TubeBloomPrePassLight
            var l_TubeLight = l_Laser.GetComponentInChildren<TubeBloomPrePassLight>();
            if (l_TubeLight == null) throw new Exception("TubeBloomPrePassLight in EnergyPanel.Laser not found");

            /// Set laser (right length, right color)
            SetEnergyLaser(ref l_TubeLight);
        }
        catch (Exception l_Exception)
        {
            /// Logs the exception for easy debugging if something changes/breaks
            Logger.Instance.Error("EnergyLaser: " + l_Exception);
        }
    }

    private static void SetEnergyLaser(ref TubeBloomPrePassLight p_TubeLight)
    {
        p_TubeLight.length = MTConfig.Instance.Length;
        p_TubeLight.color  = MTConfig.Instance.Color;
    }
}
