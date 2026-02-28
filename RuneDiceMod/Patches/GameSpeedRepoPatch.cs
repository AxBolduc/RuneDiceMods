using System.Reflection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppRogue2048;
using MelonLoader;

namespace RuneDiceMod.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(GameSpeedService), "Apply")]
    internal class GameSpeedRepoPatch
    {

        static float[] GameSpeeds = new float[] { 1.0f, 1.5f, 2.0f, 2.5f, 3.0f, 3.5f, 4.0f, 4.5f, 5.0f, };
        static float[] DiceSpeeds = new float[] { 1.0f, 1.5f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, };

        private static void Postfix(ref GameSpeedService __instance)
        {
            Type GameSpeedServicetype = typeof(GameSpeedService);
            PropertyInfo repositoryField = GameSpeedServicetype.GetProperty("_repository");

            GameSpeedsRepository repo = (GameSpeedsRepository)repositoryField.GetValue(__instance);

            GameSpeedConfig config = repo._configs.ElementAt(0);

            if (!config.CombatSpeedMultipliers.Length.Equals(GameSpeeds.Length))
            {
                Melon<Core>.Logger.Msg("Updaing default game speeds");
                config.DiceThrowingSpeedMultipliers = new Il2CppStructArray<float>(DiceSpeeds);
                config.UnitsSpeedMultipliers = new Il2CppStructArray<float>(GameSpeeds);
                config.DisplaySpeedMultipliers = new Il2CppStructArray<float>(GameSpeeds);
                config.CombatSpeedMultipliers = new Il2CppStructArray<float>(GameSpeeds);
            }
        }
    }
}
