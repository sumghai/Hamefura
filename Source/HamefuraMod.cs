using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Hamefura
{
    public class HamefuraMod : Mod
    {
        public HamefuraMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("com.Hamefura.patches");
            harmony.PatchAll();
        }

        // After resolving a pawn's apparel graphics, we conditionally render any headgear attached to apparel
        // (e.g. hoods, masks, helmets) depending on the Gizmo state in CompApparelWithAttachedHeadgear
        [HarmonyPatch(typeof(PawnGraphicSet), nameof(PawnGraphicSet.ResolveApparelGraphics))]
        static class PawnGraphicSet_ResolveApparelGraphics_IgnoreHoodedApparel
        {
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
                        }
                    }
                }
            }
        }
    }
}
