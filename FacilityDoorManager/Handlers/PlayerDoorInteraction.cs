using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityDoorManager.Handlers
{
    internal class PlayerDoorInteraction
    {
        private FacilityDoorManager plugin_instance;

        public PlayerDoorInteraction(FacilityDoorManager facilityDoorManager)
        {
            this.plugin_instance = facilityDoorManager;
        }

        internal void OnDoorInteraction(InteractingDoorEventArgs entity)
        {
            try
            {

                if (plugin_instance.Config.Behavior_rules.Safe_facility && entity.Player.IsScp)
                {
                    if (plugin_instance.Config.ScpRoomLimit.TryGetValue(entity.Player.Role, out HashSet<RoomType> room_types))
                    {
                        if (room_types != null)
                        {
                            if (room_types.Contains(entity.Player.CurrentRoom.Type) && entity.Player.CurrentRoom.Doors.Any(curr_room => curr_room == entity.Door))
                            {
                                entity.IsAllowed = false;
                                return;
                            }
                        }

                    }
                }

            }
            catch (Exception harmony_error)
            {
                Log.Error($"PlayerDoorInteraction.OnDoorInteraction: {harmony_error}\n{harmony_error.StackTrace}\n{Environment.StackTrace}");
            }

        }

    }
}
