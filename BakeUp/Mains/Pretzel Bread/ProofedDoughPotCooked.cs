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
    public class ProofedDoughPotCooked : CustomItem
    {
        public override string UniqueNameID => "ProofedDoughPotCooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ProofedDoughPotCooked");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 1;
        public override Item SplitSubItem => Refs.BoiledProofedDough;
        public override List<Item> SplitDepletedItems => new() { Refs.Pot };
        public override Item DisposesTo => Refs.Pot;
        public override bool PreventExplicitSplit => false;


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pot = Prefab.GetChildFromPath("Pot/Pot.001");
            var dough = Prefab.GetChild("Boiled Pretzel Dough.001");

            //Visuals
            dough.ApplyMaterialToChild("Bread.002", "Raw Pastry");
            dough.ApplyMaterialToChild("Score.002", "Sack");

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal Dark");
        }
    }
}
