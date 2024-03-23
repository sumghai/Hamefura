using HarmonyLib;
using RimWorld;
using Verse;

namespace Hamefura
{
    // Draw/hide hair when hooded apparel is toggled
    [HarmonyPatch(typeof(PawnRenderNode_Hair), nameof(PawnRenderNode_Hair.GraphicFor))]
    public static class Harmony_PawnRenderNode_Hair_GraphicFor_HideHairUnderHood
    {
        static void Postfix(ref Graphic __result, Pawn pawn)
        {
            Apparel hoodedApparel = pawn.apparel.WornApparel.Find(x => x.TryGetComp<CompApparelWithAttachedHeadgear>() != null);

            // Hoods are always hidden in bed, so don't hide hair
            if (hoodedApparel?.TryGetComp<CompApparelWithAttachedHeadgear>() is CompApparelWithAttachedHeadgear comp && comp.isHatOn && !pawn.InBed())
            {
                __result = null;
            }
        }
    }
}
