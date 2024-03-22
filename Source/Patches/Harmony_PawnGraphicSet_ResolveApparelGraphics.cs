using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Hamefura.Patches
{
    // TODO - update for RW 1.5 pawn rendering system
    /* 
    [HarmonyPatch(typeof(PawnGraphicSet), nameof(PawnGraphicSet.ResolveApparelGraphics))]
    public static class Harmony_PawnGraphicSet_ResolveApparelGraphics
    {
        // After resolving a pawn's apparel graphics, we conditionally render any headgear attached to apparel
        // (e.g. hoods, masks, helmets) depending on the Gizmo state in CompApparelWithAttachedHeadgear
        static void Postfix(PawnGraphicSet __instance, Pawn ___pawn)
        {
            using (List<Apparel>.Enumerator enumerator = ___pawn.apparel.WornApparel.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ApparelGraphicRecord item;
                    if (enumerator.Current.TryGetComp<CompApparelWithAttachedHeadgear>() is CompApparelWithAttachedHeadgear comp)
                    {
                        Apparel hoodApparel = (Apparel)ThingMaker.MakeThing(comp.Props.attachedHeadgearDef);
                        ApparelGraphicRecordGetter.TryGetGraphicApparel(hoodApparel, ___pawn.story.bodyType, out ApparelGraphicRecord hoodApparelGraphicRecord);

                        if (comp.isHatOn)
                        {
                            ___pawn.Drawer.renderer.graphics.apparelGraphics.Add(hoodApparelGraphicRecord);
                        }
                        else
                        {
                            ___pawn.Drawer.renderer.graphics.apparelGraphics.RemoveAll(x => x.sourceApparel == hoodApparel);
                        }

                        GlobalTextureAtlasManager.TryMarkPawnFrameSetDirty(___pawn);
                    }
                }
            }
        }
    }*/
}
