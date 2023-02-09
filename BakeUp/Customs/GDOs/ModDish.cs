using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;

namespace KitchenBakeUp.Customs
{
    public abstract class ModDish : CustomDish
    {
        public virtual IDictionary<Locale, string> LocalisedRecipe { get; }

        public virtual IDictionary<Locale, UnlockInfo> InfoList { get; }
    }
}