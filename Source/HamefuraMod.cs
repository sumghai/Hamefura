using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
