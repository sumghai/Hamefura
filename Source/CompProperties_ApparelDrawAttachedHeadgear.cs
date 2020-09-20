using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Hamefura
{
    class CompProperties_ApparelDrawAttachedHeadgear : CompProperties
    {
        public GraphicData headgearGraphicData;

        public CompProperties_ApparelDrawAttachedHeadgear()
        {
            compClass = typeof(CompApparelDrawAttachedHeadgear);
        }
    }
}
