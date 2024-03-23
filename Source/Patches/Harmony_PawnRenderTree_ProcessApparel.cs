using HarmonyLib;
using RimWorld;
using Verse;

namespace Hamefura.Patches
{
    // Draw/hide hood when gizmo is toggled
    [HarmonyPatch(typeof(PawnRenderTree), nameof(PawnRenderTree.ProcessApparel))]
    public static class Harmony_PawnRenderTree_ProcessApparel_RenderToggleableHood
    {
        static void Postfix(PawnRenderTree __instance, Apparel ap, PawnRenderNode headApparelNode, PawnRenderNode bodyApparelNode)
        {
            Pawn pawn = __instance.pawn;

            if (ap.TryGetComp<CompApparelWithAttachedHeadgear>() is CompApparelWithAttachedHeadgear comp)
            {
                Apparel hoodApparel = (Apparel)ThingMaker.MakeThing(comp.Props.attachedHeadgearDef);

                PawnRenderNodeProperties hood_pawnRenderNodeProperties = new PawnRenderNodeProperties
                {
                    debugLabel = hoodApparel.def.defName,
                    workerClass = typeof(PawnRenderNodeWorker_Apparel_Body),
                    baseLayer = headApparelNode.Props.baseLayer,
                    drawData = hoodApparel.def.apparel.drawData
                };

                if (comp.isHatOn)
                {
                    __instance.AddChild(new PawnRenderNode_Apparel(pawn, hood_pawnRenderNodeProperties, __instance, hoodApparel), headApparelNode);
                }
            }
        }
    }
}
