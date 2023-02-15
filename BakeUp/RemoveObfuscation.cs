using Kitchen;
using KitchenBakeUp;
using KitchenData;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Entities;
using static UnityEngine.EventSystems.EventTrigger;

namespace KitchenBakeUp.Utils
{
    class RemoveObfuscation : GenericSystemBase
    {
        private EntityQuery EntitiesToActOn;
        protected override void Initialise()
        {
            EntitiesToActOn = GetEntityQuery(new QueryHelper()
                .All(typeof(CItem), typeof(CObfuscateProgressIndicator), typeof(CHeldBy))
            );
        }
        protected override void OnUpdate()
        {
            using var ents = EntitiesToActOn.ToEntityArray(Allocator.Temp);
            using var my_components = EntitiesToActOn.ToComponentDataArray<CHeldBy>(Allocator.Temp);

            for (var i = 0; i < ents.Length; i++)
            {
                var ent = ents[i];
                var my_component = my_components[i];

                var component_holder = my_component.Holder;


                if (my_component.Holder != default(Entity) && !Has<CRestrictProgressVisibility>(component_holder))
                {
                    EntityManager.RemoveComponent<CObfuscateProgressIndicator>(ent);
                }
            }
        }
    }
}
