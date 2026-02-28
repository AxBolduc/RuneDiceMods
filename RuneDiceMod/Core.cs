using Il2CppRogue2048;
using MelonLoader;
using System.Reflection;
using UnityEngine;

[assembly: MelonInfo(typeof(RuneDiceMod.Core), "RuneDiceMod", "1.0.0", "Alex", null)]
[assembly: MelonGame("Smart Raven Studio", "Rune Dice Demo")]

namespace RuneDiceMod
{
    public class Core : MelonMod
    {

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
    }
}