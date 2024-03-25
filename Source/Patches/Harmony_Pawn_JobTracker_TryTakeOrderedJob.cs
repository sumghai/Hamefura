using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace Hamefura
{
    // Forces pawns to flip down the hoods of their hooded apparel before they try wearing another hat
    // (The game otherwise throws an error when trying to discard an un-discardable hood)
    [HarmonyPatch(typeof(Pawn_JobTracker), nameof(Pawn_JobTracker.TryTakeOrderedJob))]
    public static class Harmony_Pawn_JobTracker_TryTakeOrderedJob_ForceHoodDownWhenWearingNewHat
    {
        static void Postfix(bool __result, Pawn_JobTracker __instance, Job job)
        {
            Pawn pawn = __instance.pawn;

            if (__result && job.def == JobDefOf.Wear && job.targetA.Thing.def.apparel.layers.Contains(ApparelLayerDefOf.Overhead)) // Only run on a successful Force wear apparel job for a hat
            {
                if (pawn.apparel.WornApparel.Find(x => x.HasComp<CompApparelWithAttachedHeadgear>()) is Apparel hoodedApparel && hoodedApparel.GetComp<CompApparelWithAttachedHeadgear>() is CompApparelWithAttachedHeadgear comp)
                {
                    comp.isHatOn = false;
                    pawn.drawer.renderer.SetAllGraphicsDirty(); // Pawn needs to be redrawn, or the hood def doesn't disappear from the pawn inventory
                }
            }
        }
    }
}