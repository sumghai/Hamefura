using Verse;

namespace Hamefura
{
    public class PawnRenderNode_ApparelToggleableHood : PawnRenderNode
    {
        public CompApparelWithAttachedHeadgear attachedHeadgearComp;

        public PawnRenderNode_ApparelToggleableHood(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree)
        {
        }

        public override GraphicMeshSet MeshSetFor(Pawn pawn)
        {
            return HumanlikeMeshPoolUtility.GetHumanlikeHeadSetForPawn(pawn);
        }
    }
}