using KitchenBakeUp.Utils;
using KitchenBakeUp;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenBakeUp.Mains
{
    class PretzelBread : CustomItem
    {
        public override string UniqueNameID => "PretzelBread";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PretzelBread");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override int MaxOrderSharers => 2;


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Bread", "Bread - Cooked");
            Prefab.ApplyMaterialToChild("Salt", "Mayonnaise");
            Prefab.ApplyMaterialToChild("Score", "Mayonnaise");
        }
    }
}
