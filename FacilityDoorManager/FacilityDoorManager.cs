using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using System;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;
namespace FacilityDoorManager
{

    public class FacilityDoorManager : Plugin<Config>
    {



        public static Config early_config;



        /// <inheritdoc />
        public override string Author => "Undid-Iridium";

        /// <inheritdoc />
        public override string Name => "FacilityDoorManager";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 3);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(1, 1, 4);



        private Handlers.RoundStartingBehaviors roundStartBehavior;

        private Handlers.PlayerDoorInteraction playerDoorBehavior;


        /// <summary>
        /// Entrance function called through Exile
        /// </summary>
        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        /// <summary>
        /// Destruction function called through Exile
        /// </summary>
        public override void OnDisabled()
        {
            UnRegisterEvents();
            base.OnDisabled();
        }


        /// <summary>
        /// Registers events for EXILE to hook unto with cororotines (I think?)
        /// </summary>
        public void RegisterEvents()
        {
            // Register the event handler class. And add the event,
            // to the EXILED_Events event listener so we get the event.
            if (Config.Behavior_rules.Random_doors)
            {
                roundStartBehavior = new Handlers.RoundStartingBehaviors(this);
                early_config = Config;
                ServerEvents.RoundStarted += roundStartBehavior.OnRoundStarted;
            }

            if (Config.Behavior_rules.Safe_facility)
            {
                playerDoorBehavior = new Handlers.PlayerDoorInteraction(this);
                PlayerEvents.InteractingDoor += playerDoorBehavior.OnDoorInteraction;
            }

            Log.Info("FacilityDoorManager has been loaded");

        }

        /// <summary>
        /// Unregisters the events defined in RegisterEvents, recommended that everything created be destroyed if not reused in some way.
        /// </summary>
        public void UnRegisterEvents()
        {
            if (Config.Behavior_rules.Random_doors)
            {
                ServerEvents.RoundStarted -= roundStartBehavior.OnRoundStarted;
            }

            if (Config.Behavior_rules.Safe_facility)
            {
                PlayerEvents.InteractingDoor -= playerDoorBehavior.OnDoorInteraction;
            }

            Log.Info("FacilityDoorManager has been unloaded");
        }
    }

}
