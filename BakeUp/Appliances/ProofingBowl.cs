using KitchenBakeUp.Customs;
using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenLib.Utils;
using UnityEngine;
using Kitchen;
using KitchenBakeUp.Processes;
using KitchenBakeUp.Utils;

namespace KitchenBakeUp.Appliances
{
    public class ProofingBowl : CustomAppliance
    {
        public override string UniqueNameID => "ProofingBowl";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ProofingBowl");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Proofing Bowl", "Good for rising dough", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder(),
            new CRestrictProgressVisibility()
            {
                HideWhenActive = false,
                HideWhenInactive = false,
                ObfuscateWhenActive = true,
                ObfuscateWhenInactive = true
            }
        };


        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>()
        {
            // ...
            new Appliance.ApplianceProcesses()
            {
                Process = GDOUtils.GetCastedGDO<Process, ProofProcess>(),  // reference to the base process
                Speed = 1f,                                              // the speed multiplier when using this appliance (for reference, starter = 0.75, base = 1, danger hob/oven = 2)
                IsAutomatic = true,
                Validity = ProcessValidity.Generic                      // (optional) whether the process is automatic on this appliance
            }
            // ...
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var bowl = Prefab.GetChild("Bowl");
            var counter = bowl.GetChild("Base_L_Counter.blend");

            // Visuals
            bowl.ApplyMaterialToChild("Bowl.001", "Mayonnaise", "Flour");
            bowl.ApplyMaterialToChild("Cloth", "Paper - White");
            bowl.ApplyMaterialToChild("Top", "Wood - Default");

            counter.ApplyMaterial("Wood 4 - Painted", "Wood - Default");
            counter.ApplyMaterialToChild("Handle_L_Counter.blend", "Knob");

            var holdTransform = Prefab.GetChildFromPath("HoldPoint").transform;
            var holdPoint = Prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform;
        }
    }
}
