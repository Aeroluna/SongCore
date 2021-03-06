﻿using HarmonyLib;

namespace SongCore.HarmonyPatches
{
    [HarmonyPatch(typeof(Harmony))]
    [HarmonyPatch(nameof(Harmony.UnpatchAll), MethodType.Normal)]
    internal class StopModsFromBreakingOtherModsAccidentallyPatch
    {
        private static void Prefix(Harmony __instance, ref string harmonyID)
        {
            if (string.IsNullOrWhiteSpace(harmonyID))
            {
                harmonyID = __instance.Id;
                Utilities.Logging.Logger.Error($"HEY {__instance.Id} YOU'RE TRYING TO UNPATCH EVERY SINGLE MOD, PLEASE PROVIDE YOUR HARMONY ID WHEN USING UNPATCHALL");
            }
        }
    }
}