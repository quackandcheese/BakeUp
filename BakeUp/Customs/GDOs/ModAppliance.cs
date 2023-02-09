using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;

namespace KitchenBakeUp.Customs
{
    public abstract class ModAppliance : CustomAppliance
    {
        public abstract override string UniqueNameID { get; }

        private bool GameDataBuilt = false;

        public virtual List<(Locale, ApplianceInfo)> InfoList { get; protected set; }

        public override sealed void OnRegister(GameDataObject gdo)
        {
            gdo.name = $"BakeUp - {UniqueNameID}";

            if (GameDataBuilt)
            {
                return;
            }

            Modify(gdo as Appliance);
        }
        public virtual void Modify(Appliance appliance) { }
    }
}