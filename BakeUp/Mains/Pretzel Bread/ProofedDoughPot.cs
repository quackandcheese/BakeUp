using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenData.ItemGroup;
using KitchenBakeUp.Utils;
using KitchenBakeUp;

namespace KitchenBakeUp.Mains
{
    class ProofedDoughPot : CustomItemGroup<ProofedDoughPotItemGroupView>
    {
        public override string UniqueNameID => "ProofedDoughPot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ProofedDoughPot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Pot
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Water
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.ProofedDough
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 4f,
                Process = Refs.Cook,
                Result = Refs.ProofedDoughPotCooked
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pot = Prefab.GetChildFromPath("Pot/Pot.001");

            //Visuals

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal Dark");

            Prefab.ApplyMaterialToChild("Water", "Water");
            Prefab.GetChild("Pretzel Dough.001").ApplyMaterialToChild("Bread.001", "Raw Pastry");


            Prefab.GetComponent<ProofedDoughPotItemGroupView>()?.Setup(Prefab);
        }
    }


    public class ProofedDoughPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pot"),
                    Item = Refs.Pot,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pretzel Dough.001"),
                    Item = Refs.ProofedDough,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Water"),
                    Item = Refs.Water
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "Do",
                    Item = Refs.ProofedDough
                }
            };
        }
    }
}
