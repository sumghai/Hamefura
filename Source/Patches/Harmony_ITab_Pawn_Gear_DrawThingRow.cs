using HarmonyLib;
using RimWorld;
using Verse;

namespace Hamefura
{
    // Skip listing dynamically-generated hood headgear in the pawn's inventory tab
    [HarmonyPatch(typeof(ITab_Pawn_Gear), nameof(ITab_Pawn_Gear.DrawThingRow))]
    public static class Harmony_ITab_Pawn_Gear_DrawThingRow_SkipListingAttachedHoods
    {
        static bool Prefix(Thing thing)
        {
            if (thing is Apparel && HamefuraDefOf.Hamefura_HoodDefs.Contains(thing.def))
            {
                return false; // Skip
            }
            return true;
        }
    }
}
