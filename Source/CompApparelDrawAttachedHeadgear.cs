using RimWorld;
using Verse;

namespace Hamefura
{
    public class CompApparelDrawAttachedHeadgear : ThingComp
    {
        private CompProperties_ApparelDrawAttachedHeadgear Props => (CompProperties_ApparelDrawAttachedHeadgear)props;

        public Apparel Apparel => parent as Apparel;

        public Pawn Pawn => Apparel.Wearer;

        public override void PostDraw()
        {
            base.PostDraw();

            if (Pawn != null)
            {
                Log.Warning("Hamefura :: " + parent.def.defName + " is being worn by " + Pawn.Name.ToStringFull);
                if (Props.headgearGraphicData == null)
                {
                    Log.Warning("Hamefura :: No additional graphics specified for " + parent.def.defName);
                }
                else {
                    Log.Warning("Hamefura :: " + parent.def.defName + " has found additional graphics!");
                }
            }
        }
    }
}