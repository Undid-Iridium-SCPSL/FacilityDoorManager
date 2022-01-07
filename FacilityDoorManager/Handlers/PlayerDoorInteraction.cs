using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using FacilityDoorManager.Utilities;
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

        private bool loaded_information { get; set; } = false;

        private Dictionary<RoleType, HashSet<RoomType>> scp_lock_to_rooms;
        internal void OnDoorInteraction(InteractingDoorEventArgs entity)
        {
            try
            {

                if (plugin_instance.Config.behavior_rules.safe_facility)
                {

                    if (entity.Player.IsScp)
                    {

                        if (scp_lock_to_rooms == null)
                        {
                            scp_lock_to_rooms = plugin_instance.Config.ScpRoomLimit;
                        }

                        RoleType player_role = entity.Player.Role;
                        if (scp_lock_to_rooms.TryGetValue(player_role, out HashSet<RoomType> room_types))
                        {
                            LoggerTool.log_msg_static("5");
                            LoggerTool.log_msg_static($"I wonder what our current room is {entity.Player.CurrentRoom.Type}");
                            LoggerTool.log_msg_static($"I wonder what the door says {entity.Door}");
                            LoggerTool.log_msg_static($"I wonder what the door says {entity.Player.CurrentRoom.Doors}");
                            //LoggerTool.log_msg_static($"I wonder what the door says {entity.Player.ReferenceHub.}");
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
                Log.Error($"OverloadForceReloadPost.OverloadForceReloadPost: {harmony_error}\n{harmony_error.StackTrace}\n{Environment.StackTrace}");
            }
            entity.IsAllowed = true;
        }

        private void add_room_to_scp(RoleType player_role, RoomType current_room)
        {
            if (plugin_instance.Config.ScpRoomLimit.TryGetValue(player_role, out HashSet<RoomType> allocated_rooms))
            {
                if (allocated_rooms.Contains(current_room))
                {
                    if (!scp_lock_to_rooms.ContainsKey(player_role))
                    {
                        scp_lock_to_rooms[player_role] = new HashSet<RoomType> { current_room };
                    }
                    else
                    {
                        scp_lock_to_rooms[player_role].Add(current_room);
                    }
                }
            }
        }
    }
}
