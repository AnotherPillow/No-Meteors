using HarmonyLib;
using Netcode;
using StardewModdingAPI;
using StardewValley.Events;

namespace No_Meteors
{
    internal sealed class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            var harmony = new Harmony(this.ModManifest.UniqueID);
            harmony.Patch(
               original: AccessTools.Method(typeof(StardewValley.Events.SoundInTheNightEvent), nameof(StardewValley.Events.SoundInTheNightEvent.setUp)),
               prefix: new HarmonyMethod(typeof(ModEntry), nameof(ModEntry.SoundInTheNightEvent_setUp_Prefix))
            );
        }

        internal static bool SoundInTheNightEvent_setUp_Prefix(NetInt ___behavior)
        {
            if (___behavior.Value == 1) return false;
            return true;
        }

    }
}