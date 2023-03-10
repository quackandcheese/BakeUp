using KitchenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using KitchenLib.Customs;
using KitchenBakeUp.Utils;
using KitchenLib.Utils;

namespace KitchenBakeUp.Mains
{
    class ProofedDough : CustomItem
    {
        public override string UniqueNameID => "Proofed Dough";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ProofedDough");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "P";


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetChild("Bread.004").ApplyMaterial("Raw Pastry");
        }
    }
}

