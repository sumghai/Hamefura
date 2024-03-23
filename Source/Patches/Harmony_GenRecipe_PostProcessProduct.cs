using HarmonyLib;
using UnityEngine;
using Verse;

namespace Hamefura
{
    [HarmonyPatch(typeof(GenRecipe), nameof(GenRecipe.PostProcessProduct))]
    public static class Harmony_GenRecipe_PostProcessProduct
    {
        static void Prefix(ref Thing product)
        {
            CompApparelIgnoreStuffColor compApparelIgnoreStuffColor = product.TryGetComp<CompApparelIgnoreStuffColor>();

            if (compApparelIgnoreStuffColor != null)
            {
                product.SetColor(Color.white);
            }
        }
    }

}
