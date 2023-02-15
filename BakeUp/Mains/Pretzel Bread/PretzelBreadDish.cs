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
using Unity.Entities;

namespace KitchenBakeUp.Mains
{
    class PretzelBreadDish : CustomDish
    {
        public override string UniqueNameID => "Pretzel Bread Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("PretzelBread");
        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("PretzelBread");
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => false;

        public override List<string> StartingNameSet => new List<string>
        {
            "Rise to the Occasion",
            "Batter Up",
            "Knead for Speed",
            "Bready, Set, Dough",
            "Rolling in Dough",
            "The Cheese Knees",
            "Bringing in the Bread",
            "Dough You Believe It?",
            "Loafing Around",
            "Knead a Break?",
            "It's The Yeast We Can Do"
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.PretzelBread,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Pot,
            Refs.Water,
            Refs.Flour
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook,
            Refs.Proof,
            Refs.Knead
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Knead or add water to flour to make dough. Proof dough in proofing bowl, then boil in a pot with water. Bake, then serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Pretzel Bread", "Adds Pretzel Bread as a Main", "Bread") )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            DisplayPrefab.ApplyMaterialToChild("Bread", "Bread - Cooked");
            DisplayPrefab.ApplyMaterialToChild("Salt", "Mayonnaise");
            DisplayPrefab.ApplyMaterialToChild("Score", "Mayonnaise");

            IconPrefab.ApplyMaterialToChild("Bread", "Bread - Cooked");
            IconPrefab.ApplyMaterialToChild("Salt", "Mayonnaise");
            IconPrefab.ApplyMaterialToChild("Score", "Mayonnaise");
        }
    }
}
