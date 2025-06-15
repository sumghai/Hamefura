using RimWorld;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace Hamefura
{
    public class CompApparelWithAttachedHeadgear : ThingComp
    {
        public CompProperties_ApparelWithAttachedHeadgear Props => (CompProperties_ApparelWithAttachedHeadgear)props;

        public Apparel Apparel => parent as Apparel;

        public Pawn Pawn => Apparel.Wearer;

        public bool isHatOn;

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref isHatOn, "isHatOn", defaultValue: false, forceSave: true);
        }

        public override List<PawnRenderNode> CompRenderNodes()
        {
            List<PawnRenderNode> hoodRenderNode = new();
            PawnRenderNodeProperties properties = new();

            // Calculate rendering offset for head apparel layer
            PawnRenderNode value;
            PawnRenderNode headApparelNode = (Pawn.drawer.renderer.renderTree.nodesByTag.TryGetValue(PawnRenderNodeTagDefOf.ApparelHead, out value) ? value : null);

            // Set up rendering properties for the hood
            properties.texPath = Props.attachedHeadgearGraphicPath;
            properties.debugLabel = Props.attachedHeadgearLabel.Split('/').Last() + " (dummy)";
            properties.color = Apparel.DrawColor;
            properties.shaderTypeDef = Apparel.def.graphicData.shaderType;
            properties.workerClass = typeof(PawnRenderNodeWorker_Apparel_Head_ToggleableHood);
            properties.parentTagDef = PawnRenderNodeTagDefOf.ApparelHead;
            properties.baseLayer = headApparelNode.Props.baseLayer;

            PawnRenderNode_ApparelToggleableHood hoodApparelNode = new(Pawn, properties, Pawn.drawer.renderer.renderTree)
            {
                attachedHeadgearComp = this
            };
            hoodRenderNode.Add(hoodApparelNode);

            return hoodRenderNode;
        }

        public override IEnumerable<Gizmo> CompGetWornGizmosExtra()
        {
            foreach (Gizmo item in base.CompGetWornGizmosExtra())
            {
                yield return item;
            }

            if (Pawn != null)
            {
                Command_Toggle command_Toggle = new Command_Toggle
                {
                    defaultLabel = "Hamefura_ToggleableHeadgearCommand_Label".Translate(Props.attachedHeadgearLabel),
                    defaultDesc = "Hamefura_ToggleableHeadgearCommand_Desc".Translate(Props.attachedHeadgearLabel),
                    icon = ContentFinder<Texture2D>.Get(Props.toggleUiIconPath),
                    isActive = () => isHatOn,
                    toggleAction = delegate
                    {
                        isHatOn = !isHatOn;
                        Pawn.Drawer.renderer.SetAllGraphicsDirty();
                    },
                    turnOffSound = null,
                    turnOnSound = null
                };
                yield return command_Toggle;
            }
        }
    }
}