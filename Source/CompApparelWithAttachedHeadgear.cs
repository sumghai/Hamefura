using RimWorld;
using System.Collections.Generic;
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
                    defaultLabel = "Hamefura_ToggleableHeadgearCommand_Label".Translate(Props.attachedHeadgearDef.label),
                    defaultDesc = "Hamefura_ToggleableHeadgearCommand_Desc".Translate(Props.attachedHeadgearDef.label),
                    icon = ContentFinder<Texture2D>.Get(Props.toggleUiIconPath),
                    isActive = () => isHatOn,
                    toggleAction = delegate
                    {
                        isHatOn = !isHatOn;
                        Pawn.Drawer.renderer.graphics.ResolveApparelGraphics();
                    },
                    turnOffSound = null,
                    turnOnSound = null
                };
                yield return command_Toggle;
            }
        }
    }
}