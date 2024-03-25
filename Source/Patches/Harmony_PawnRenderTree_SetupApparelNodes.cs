using HarmonyLib;
using RimWorld;
using Verse;

namespace Hamefura
{
    // Add or remove a dynamically-generated hood headgear, based on the state of the gizmo in the hooded apparel
    [HarmonyPatch(typeof(PawnRenderTree), nameof(PawnRenderTree.SetupApparelNodes))]
    public static class Harmony_PawnRenderTree_SetupApparelNodes_ToggleAttachedHood
    {
        static void Prefix(PawnRenderTree __instance)
        {
            Pawn pawn = __instance.pawn;
            if (pawn.apparel != null && pawn.apparel.WornApparelCount > 0)
            {
                if (pawn.apparel?.WornApparel?.Find(ap => ap.TryGetComp<CompApparelWithAttachedHeadgear>() is not null) is Apparel apparelWithAttachedHeadgear)
                {
                    CompApparelWithAttachedHeadgear comp = apparelWithAttachedHeadgear.GetComp<CompApparelWithAttachedHeadgear>();

                    Apparel hoodApparel = (Apparel)ThingMaker.MakeThing(comp.Props.attachedHeadgearDef, apparelWithAttachedHeadgear.Stuff);
                    hoodApparel.DrawColor = apparelWithAttachedHeadgear.DrawColor;

                    if (comp.isHatOn)
                    {
                        pawn.apparel.WornApparel.Add(hoodApparel);
                    }
                    else
                    {
                        pawn.apparel.WornApparel.RemoveAll(ap => HamefuraDefOf.Hamefura_HoodDefs.Contains(ap.def));
                    }
                }
                else
                {
                    // Remove any worn hoods if the base hooded apparel is removed or destroyed
                    pawn.apparel.WornApparel.RemoveAll(ap => HamefuraDefOf.Hamefura_HoodDefs.Contains(ap.def));
                }
            }
        }
    }
}