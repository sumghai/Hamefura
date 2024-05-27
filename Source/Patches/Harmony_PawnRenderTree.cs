using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Hamefura
{
    // Add a pawn render node for the toggleable hood, and hide all other headgear if the hood is enabled
    [HarmonyPatch(typeof(PawnRenderTree), nameof(PawnRenderTree.ProcessApparel))]
    public static class Harmony_PawnRenderTree_ProcessApparel_AddHoodNodeAndHideOtherHeadgear
    {
        // Hide all other headgear is the hood is enabled
        static bool Prefix(PawnRenderTree __instance, Apparel ap, PawnRenderNode headApparelNode)
        {
            if (ap.def.apparel.layers.Contains(ApparelLayerDefOf.Overhead) && __instance.pawn.apparel.WornApparel.Exists(ap => ap.GetComp<CompApparelWithAttachedHeadgear>()?.isHatOn ?? false))
            {
                return false; // Hide
            }
            return true;
        }

        // Add the hooded headgear render node
        static void Postfix(PawnRenderTree __instance, Apparel ap)
        {
            if (ap.GetComp<CompApparelWithAttachedHeadgear>()?.CompRenderNodes() is List<PawnRenderNode> renderNodes)
            {
                foreach (PawnRenderNode node in renderNodes)
                {
                    if (__instance.ShouldAddNodeToTree(node?.Props))
                    {
                        __instance.AddChild(node, null);
                    }
                }
            }
        }
    }

    // Hide a pawn's hair if the pawn is wearing an apparel with a toggleable hood that is enabled
    [HarmonyPatch(typeof(PawnRenderTree), nameof(PawnRenderTree.AdjustParms))]
    public static class Harmony_PawnRenderTree_AdjustParms_HideHairIfHoodIsUp
    {
        static void Postfix(PawnRenderTree __instance, ref PawnDrawParms parms)
        {
            Pawn pawn = __instance.pawn;

            if (pawn.apparel != null && PawnRenderNodeWorker_Apparel_Head.HeadgearVisible(parms))
            {
                if (pawn.apparel.WornApparel.Exists(ap => ap.GetComp<CompApparelWithAttachedHeadgear>()?.isHatOn ?? false))

                    parms.skipFlags |= RenderSkipFlagDefOf.Hair;
            }
        }
    }
}
