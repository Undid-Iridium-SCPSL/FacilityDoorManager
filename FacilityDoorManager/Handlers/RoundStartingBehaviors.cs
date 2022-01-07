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
                if (this.plugin_instance.Config.DoorVariantControl.TryGetValue(current_door.Type, out bool enabled_door))
                {


                    bool output = next_random_value();
                    if (output)
                    {
                        //LoggerTool.log_msg_static($"{current_door.Type} , and the hash/info {current_door.GetHashCode()} , {current_door.Base.RequiredPermissions.RequiredPermissions}");
                        current_door.IsOpen = true;
                    }
                }


            }
        }

        public bool next_random_value()
        {
            if (random_generator.Next(0, 2) == 0)
                return false;
            else
                return true;
        }
    }
}