using Exiled.API.Features;
using System;
using UnityEngine;
namespace FacilityDoorManager.Handlers
{
    internal class RoundStartingBehaviors
    {

        private FacilityDoorManager plugin_instance;

        public RoundStartingBehaviors(FacilityDoorManager plugin_instance)
        {
            this.plugin_instance = plugin_instance;
        }
        internal void OnRoundStarted()
        {
            foreach (Door current_door in Door.List)
            {
                if (plugin_instance.Config.DoorVariantControl.TryGetValue(current_door.Type, out bool enabled_door) && next_random_value())
                {
                    current_door.IsOpen = true;
                }
            }
        }

        public bool next_random_value()
        {
            return UnityEngine.Random.Range(0, 2) != 0;
        }
    }
}