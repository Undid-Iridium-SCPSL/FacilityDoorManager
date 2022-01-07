using Exiled.API.Features;
using System;

namespace FacilityDoorManager.Handlers
{
    internal class RoundStartingBehaviors
    {
        public static Random random_generator = new Random();
        private FacilityDoorManager plugin_instance;

        public RoundStartingBehaviors(FacilityDoorManager plugin_instance)
        {
            this.plugin_instance = plugin_instance;
        }
        internal void OnRoundStarted()
        {
            foreach (Door current_door in Map.Doors)
            {
                if (this.plugin_instance.Config.DoorVariantControl.TryGetValue(current_door.Type, out bool enabled_door) && this.next_random_value())
                {
                    current_door.IsOpen = true;
                }
            }
        }

        public bool next_random_value()
        {
            return RoundStartingBehaviors.random_generator.Next(0, 2) != 0;
        }
    }
}