# FacilityDoorManager

Allows users to have doors randomly open at start of round, and can blacklist which does should not be attempted to be open.
Allows users to lock specific SCP's from specific doors in specific rooms. This means that if they attempt to open the door it will fail. SCP106 can still walk through them but cannot close/open if you set it based on room.

Keep in mind that doors parent's may not exist (Unknown door's) or they may belong to a different room.

Example configuration 
```
facility_door_manager:
# Control over what rooms scp's are locked from per SCP.
  scp_room_limit:
    Scp049:
    - LczAirlock
    Scp0492:
    - LczAirlock
    Scp106:
    - LczAirlock
    Scp079:
    - LczAirlock
    Scp096:
    - LczAirlock
    Scp173:
    - LczAirlock
    Tutorial:
    - LczAirlock
    Scp93953:
    - LczAirlock
    Scp93989:
    - LczAirlock
  # Control over what doors will be black listed from opening on round start.
  door_variant_control:
    UnknownDoor: false
    Scp012: false
    Scp012Bottom: false
    Scp012Locker: false
    Scp049Armory: false
    Scp079First: false
    Scp079Second: false
    Scp096: false
    Scp106Bottom: false
    Scp106Primary: false
    Scp106Secondary: false
    Scp173Gate: false
    Scp173Connector: false
    Scp173Armory: false
    Scp173Bottom: false
    GR18: false
    Scp914: false
    CheckpointEntrance: false
    CheckpointLczA: false
    CheckpointLczB: false
    EntranceDoor: false
    EscapePrimary: false
    EscapeSecondary: false
    ServersBottom: false
    GateA: false
    GateB: false
    HczArmory: false
    HeavyContainmentDoor: false
    HID: false
    HIDLeft: false
    HIDRight: false
    Intercom: false
    LczArmory: false
    LczCafe: false
    LczWc: false
    LightContainmentDoor: false
    NukeArmory: false
    NukeSurface: false
    PrisonDoor: false
    SurfaceGate: false
  # Control over what doors will be black listed from opening on round start.
  behavior_rules:
  # Whether to enable all patching or not
    patch_all: true
    # Debug flag.
    debug_enabled: true
    # Enable all doors to be randomly opened at start of round
    random_doors: true
    # Safe Facility logic
    safe_facility: true
  # Whether to enable or disable plugin
  is_enabled: true
```

