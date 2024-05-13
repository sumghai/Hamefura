using Verse;

namespace Hamefura
{
    public class CompProperties_ApparelWithAttachedHeadgear : CompProperties
    {
        [NoTranslate]
        public string attachedHeadgearGraphicPath;

        [NoTranslate]
        public string toggleUiIconPath;

        [MustTranslate]
        public string attachedHeadgearLabel;

        public CompProperties_ApparelWithAttachedHeadgear()
        {
            compClass = typeof(CompApparelWithAttachedHeadgear);
        }
    }
}
