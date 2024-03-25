using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Hamefura
{
    [DefOf]
    public static class HamefuraDefOf
    {
        public static List<ThingDef> Hamefura_HoodDefs => GetHoodDefs();

        public static List<ThingDef> GetHoodDefs()
        {
            List<ThingDef> hoodedApparelDefs = DefDatabase<ThingDef>.AllDefs.Where(x => x.HasComp(typeof(CompApparelWithAttachedHeadgear))).ToList();
            List<ThingDef> hoodDefs = new List<ThingDef>();

            foreach (ThingDef hoodedApparelDef in hoodedApparelDefs)
            {
                hoodDefs.Add(hoodedApparelDef.GetCompProperties<CompProperties_ApparelWithAttachedHeadgear>().attachedHeadgearDef);
            }

            return hoodDefs;
        }
    }
}
