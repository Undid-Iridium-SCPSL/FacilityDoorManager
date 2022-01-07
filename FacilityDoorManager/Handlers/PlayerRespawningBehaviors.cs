using Exiled.Events.EventArgs;

namespace FacilityDoorManager.Handlers
{
    internal class PlayerRespawningBehaviors
    {
        private FacilityDoorManager plugin_instance;

        public PlayerRespawningBehaviors(FacilityDoorManager facilityDoorManager)
        {
            this.plugin_instance = facilityDoorManager;
        }

        internal void OnRespawning(SpawningEventArgs ev)
        {
            ev.Player.IsGodModeEnabled = true;
            ev.Player.NoClipEnabled = true;
        }
    }
}