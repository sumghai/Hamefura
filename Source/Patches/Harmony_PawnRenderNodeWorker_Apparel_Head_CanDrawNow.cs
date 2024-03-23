using HarmonyLib;
using RimWorld;
using Verse;

namespace Hamefura
{
    // Hide all other headgear when hood is worn
    [HarmonyPatch(typeof(PawnRenderNodeWorker_Apparel_Head), nameof(PawnRenderNodeWorker_Apparel_Head.CanDrawNow))]
    public static class Harmony_PawnRenderNodeWorker_Apparel_Head_CanDrawNow
    {
        static void Postfix(ref bool __result, PawnDrawParms parms)
        {
            Apparel hoodedApparel = parms.pawn.apparel.WornApparel.Find(x => x.TryGetComp<CompApparelWithAttachedHeadgear>() != null);

            if (hoodedApparel?.TryGetComp<CompApparelWithAttachedHeadgear>() is CompApparelWithAttachedHeadgear comp && comp.isHatOn)
            {
                __result = false;
            }
        }
    }
}
