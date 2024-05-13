using Verse;

namespace Hamefura
{
    public class PawnRenderNodeWorker_Apparel_Head_ToggleableHood : PawnRenderNodeWorker_Apparel_Head
    {
        public override bool CanDrawNow(PawnRenderNode n, PawnDrawParms parms)
        {
            PawnRenderNode_ApparelToggleableHood node = n as PawnRenderNode_ApparelToggleableHood;
            if (!base.CanDrawNow(node, parms))
            {
                return false;
            }
            return node.attachedHeadgearComp.isHatOn;
        }
    }
}