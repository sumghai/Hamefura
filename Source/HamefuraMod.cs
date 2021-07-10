using HarmonyLib;
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
    }
}
