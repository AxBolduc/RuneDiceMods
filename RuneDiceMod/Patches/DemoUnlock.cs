using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Il2CppRogue2048;
using MelonLoader;

namespace RuneDiceMod.Patches
{
    [HarmonyPatch(typeof(NewGameLaunchService), nameof(NewGameLaunchService.SetupCharactersData))]
    internal class DemoUnlock
    {
        /// <summary>
        /// Unlocks the two locations that are locked in the demo.
        /// </summary>
        /// <param name="__instance"></param>
        static void Prefix(ref NewGameLaunchService __instance)
        {
            foreach (LocationConfig item in __instance._locationsCollection.Locations)
            {
                item.Locker = null;
            }
        }
    }
}
