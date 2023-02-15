using KitchenBakeUp.Mains;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenBakeUp
{
    internal class Refs
    {
        #region Vanilla References
        // Items
        public static Item Pot => Find<Item>(ItemReferences.Pot);
        public static Item Water => Find<Item>(ItemReferences.Water);
        public static Item Flour => Find<Item>(ItemReferences.Flour);
        public static Item Dough => Find<Item>(ItemReferences.Dough);

        // Processes
        public static Process Cook => Find<Process>(ProcessReferences.Cook);
        public static Process Chop => Find<Process>(ProcessReferences.Chop);
        public static Process Knead => Find<Process>(ProcessReferences.Knead);
        public static Process Oven => Find<Process>(ProcessReferences.RequireOven);
        #endregion

        #region IngredientLib References
        //public static Item Chicken => Find<Item>("IngredientLib", "chicken");
        #endregion

        #region Modded References
        // Items
        public static Item ProofedDough => Find<Item, ProofedDough>();
        public static Item BoiledProofedDough => Find<Item, BoiledProofedDough>();
        public static Item ProofedDoughPotCooked => Find<Item, ProofedDoughPotCooked>();
        public static ItemGroup ProofedDoughPot => Find<ItemGroup, ProofedDoughPot>();
        public static Item PretzelBread => Find<Item, PretzelBread>();

        // Process
        public static Process Proof => Find<Process, Processes.ProofProcess>();

        // Appliance
        public static Appliance ProofingBowl => Find<Appliance, Appliances.ProofingBowl>();

        // Cards
        public static Dish PretzelBreadDish => Find<Dish, PretzelBreadDish>();
        #endregion



        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }

        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }

        private static Appliance.ApplianceProcesses FindApplianceProcess<C>() where C : CustomSubProcess
        {
            ((CustomApplianceProccess)CustomSubProcess.GetSubProcess<C>()).Convert(out var process);
            return process;
        }
    }
}
