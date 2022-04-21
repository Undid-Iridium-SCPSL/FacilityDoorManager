namespace FacilityDoorManager
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Enums;
    using Exiled.API.Interfaces;

    public sealed class Config : IConfig
    {
        [Description("Control over what rooms scp's are locked from per SCP.")]
        public Dictionary<RoleType, HashSet<RoomType>> ScpRoomLimit { get; set; } =
            new Dictionary<RoleType, HashSet<RoomType>> {

                { RoleType.Scp049, null },
                { RoleType.Scp0492, new HashSet<RoomType> { RoomType.LczAirlock } },
                { RoleType.Scp106, null },
                { RoleType.Scp079, null },
                { RoleType.Scp096, null },
                { RoleType.Scp173, null },
                { RoleType.Tutorial, null },
                { RoleType.Scp93953, null },
                { RoleType.Scp93989, null },
            };

        [Description("Control over what doors will be black listed from opening on round start.")]
        public Dictionary<DoorType, bool> DoorVariantControl { get; set; } =
            new Dictionary<DoorType, bool>
            {
                { DoorType.UnknownDoor, false },
                { DoorType.Scp012, false },
                { DoorType.Scp012Bottom, false },
                { DoorType.Scp012Locker, false },
                { DoorType.Scp049Armory, false },
                { DoorType.Scp079First, false },
                { DoorType.Scp079Second, false },
                { DoorType.Scp096, false },
                { DoorType.Scp106Bottom, false },
                { DoorType.Scp106Primary, false },
                { DoorType.Scp106Secondary, false },
                { DoorType.Scp173Gate, false },
                { DoorType.Scp173Connector, false },
                { DoorType.Scp173Armory, false },
                { DoorType.Scp173Bottom, false },
                { DoorType.GR18, false },
                { DoorType.Scp914, false },
                { DoorType.CheckpointEntrance, false },
                { DoorType.CheckpointLczA, false },
                { DoorType.CheckpointLczB, false },
                { DoorType.EntranceDoor, false },
                { DoorType.EscapePrimary, false },
                { DoorType.EscapeSecondary, false },
                { DoorType.ServersBottom, false },
                { DoorType.GateA, false },
                { DoorType.GateB, false },
                { DoorType.HczArmory, false },
                { DoorType.HeavyContainmentDoor, false },
                { DoorType.HID, false },
                { DoorType.HIDLeft, false },
                { DoorType.HIDRight, false },
                { DoorType.Intercom, false },
                { DoorType.LczArmory, false },
                { DoorType.LczCafe, false },
                { DoorType.LczWc, false },
                { DoorType.LightContainmentDoor, false },
                { DoorType.NukeArmory, false },
                { DoorType.NukeSurface, false },
                { DoorType.PrisonDoor, false },
                { DoorType.SurfaceGate, false },
            };

        [Description("Control over what specific settings will be applied.")]
        public class Configuration_choices
        {
            [Description("Whether to enable all patching or not")]
            public bool Patch_all { get; set; } = true;

            [Description("Debug flag.")]
            public bool Debug_enabled { get; set; } = false;

            [Description("Enable all doors to be randomly opened at start of round")]
            public bool Random_doors { get; set; } = false;

            [Description("Safe Facility logic")]
            public bool Safe_facility { get; set; } = false;
        }

        [Description("Control over what doors will be black listed from opening on round start.")]
        public Configuration_choices Behavior_rules { get; set; } = new Configuration_choices();

        [Description("Whether to enable or disable plugin")]
        public bool IsEnabled { get; set; } = true;

    }
}