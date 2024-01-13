using UnityEngine;

namespace BeatSaberPlus_EnergyLaser.Utils;

public static class GameObjectFinder
{
    internal static GameObject? FindGameObject(string p_Query)
    {
        var l_Gms            = p_Query.Split('.');
        var l_LastGameObject = GameObject.Find(l_Gms[0]);
        var l_Index          = 0;

        while (l_LastGameObject is not null && ++l_Index < l_Gms.Length)
            l_LastGameObject = l_LastGameObject.transform.Find(l_Gms[l_Index]).gameObject;

        return l_LastGameObject;
    }
}
