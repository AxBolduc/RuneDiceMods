using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace RuneDiceMod.Patches
{
    [HarmonyPatch(typeof(Debug), nameof(Debug.Log), new Type[] { typeof(Il2CppSystem.Object)})]
    internal class DebugLogging
    {

        static void Prefix(Il2CppSystem.Object message)
        {
            Melon<Core>.Logger.Msg(message.ToString());
        }

    }
}
