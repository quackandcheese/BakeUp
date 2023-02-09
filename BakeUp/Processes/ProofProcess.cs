using KitchenData;
using KitchenLib.Utils;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenBakeUp.Appliances;

namespace KitchenBakeUp.Processes
{
    public class ProofProcess : CustomProcess
    {
        // The unique internal name of this process
        public override string UniqueNameID => "ProofProcess";

        // The "default" appliance of this process (e.g., counter for "chop", hob for "cook")
        // When a dish requires this process, this is the appliance that will spawn at the beginning of a run
        public override GameDataObject BasicEnablingAppliance => Refs.ProofingBowl;

        // Whether or not the process can be obfuscated, such as through the "Blindfolded Chefs" card. This is normally set to `true`
        public override bool CanObfuscateProgress => true;

        // The localization information for this process. This must be set for at least one language. 
        public override LocalisationObject<ProcessInfo> Info
        {
            get
            {
                var info = new LocalisationObject<ProcessInfo>();

                // Note: for testing, I recommend setting "my_custom_icon" to "knead" for now until we add the custom icon
                info.Add(Locale.English, LocalisationUtils.CreateProcessInfo("Proof", "knead"));

                return info;
            }
        }

        // This is property which you probably don't need. Setting this allows a custom dish to require this process but
        // makes the game think it is a different process when checking for kitchen validity when selling appliances. The
        // main instance where this is used is for the vanilla dishes that require ovens instead of hobs. There is a dummy
        // process, called "RequireOven" whose BasicEnablingAppliance is an oven but whose psuedoprocess is cook. This
        // makes the game spawn an oven but require the "cook" process for oven dishes, such as pizza.
        // public override Process IsPseudoprocessFor => /* the parent process */;
    }
}
