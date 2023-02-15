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
    class BoiledProofedDough : CustomItem
    {
        public override string UniqueNameID => "BoiledProofedDough";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BoiledProofedDough");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;

        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 2f,
                Process = Refs.Cook,
                Result = Refs.PretzelBread
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Bread.003", "Raw Pastry");
            Prefab.ApplyMaterialToChild("Score.001", "Sack");
        }
    }
}
