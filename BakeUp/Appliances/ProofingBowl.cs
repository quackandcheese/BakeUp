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

namespace KitchenBakeUp.Appliances
{
    public class ProofingBowl : ModAppliance
    {
        public override string UniqueNameID => "ProofingBowl";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Proofing Bowl");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override IDictionary<Locale, ApplianceInfo> InfoList => new Dictionary<Locale, ApplianceInfo>()
        {
            { Locale.English, LocalisationUtils.CreateApplianceInfo("Proofing Bowl", "Good for rising dough", new(), new()) }
        };

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder()
        };


        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>()
        {
            // ...
            new Appliance.ApplianceProcesses()
            {
                Process = Refs.ProofProcess,  // reference to the base process
                Speed = 1,                                              // the speed multiplier when using this appliance (for reference, starter = 0.75, base = 1, danger hob/oven = 2)
                IsAutomatic = true                                      // (optional) whether the process is automatic on this appliance
            }
            // ...
        };

    }
}
