using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;

namespace KitchenBakeUp.Customs
{
    public abstract class ModAppliance : CustomAppliance
    {
        public struct VariableApplianceProcess
        {
            public ItemList Items;
            public List<Appliance.ApplianceProcesses> Processes;
        }
        public virtual IDictionary<Locale, ApplianceInfo> InfoList { get; internal set; }
        public virtual List<VariableApplianceProcess> VariableApplianceProcesses { get; internal set; }
    }
}