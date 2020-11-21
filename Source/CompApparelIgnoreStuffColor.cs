using UnityEngine;
using Verse;

namespace Hamefura
{
    public class CompApparelIgnoreStuffColor : CompColorable
    {
        public override void Initialize(CompProperties props)
        {
            base.Initialize(props);
            CompColorable comp = parent.GetComp<CompColorable>();
            if (comp != null && !comp.active)
            {
                parent.GetComp<CompColorable>().active = true;
            }
            parent.Notify_ColorChanged();
        }
    }
}
