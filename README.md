# NukeLock
A simple plugin that allows Customization of the Warhead

# Commands
Name | Permission | Description | CommandType
---- | ---------- | ----------- | -----------
nukelock | nl.nukelock | Switches the Warhead between cancelable and uncancelable | RemoteAdmin

# Config
Name | Type | Description | Default
---- | ---- | ----------- | -------
is_enabled | bool | Should the plugin be enabled? | true
debug | bool | Should debug messages be shown? | false
warhead_auto_armed | bool | Should the Warhead be auto armed at the start of the Round? | true
auto_nuke | int | After what time should the warhead be automaticly started and can't be stopped (-1 = Disabled) | 900
auto_nuke_perma_broadcast_timer | int | After what autonuke time should a permanently broadcast be broadcasted across the map to tell the AutoNuke will be activated? %COUNTDOWN% will be replaced with the time left until autonuke will be activated | 30
auto_nuke_perma_broadcast_message | string | ^^ | <color=red>Alpha Warhead Emergency Detonation Sequence will engage in %COUNTDOWN% seconds</color>
warhead_cancelable | bool | Should the Warhead be uncancelable at the start of the Round? | false
hint_time | int | How long should the Hint be displayed wgeb a player tries to disable the Nuke while uncancelable? | 3
hint_message | string | What hint should be displayed when a player tries to disable the nuke while uncancelable? | <color=red>This Nuke cannot be disabled</color>
detonation_broadcast_time | ushort | How long should a broadcast be broadcasted when the AutoNuke activates? (-1 = Disabled) | 3
detonation_broadcast_message | string | What broadcast should be broadcasted when the AutoNuke activates? | <color=red>The Alpha Warhead Detonation Sequence engaged, <b>This Warhead cannot be stopped</b></color>
cassie_warnings | Dictionary | After what time should a cassie message be broadcasted? | 600, 300, 120, 60, 30

# Default Config
```yml
nuke_lock:
  # Should the plugin be enabled?
  is_enabled: true
  # Should debug messages be shown?
  debug: false
  # Should the Warhead be auto armed at the start of the Round?
  warhead_auto_armed: true
  # After what time should the warhead be automaticly started and can't be stopped (-1 = Disabled)
  auto_nuke: 900
  # After what autonuke time should a permanently broadcast be broadcasted across the map to tell the AutoNuke will be activated? %COUNTDOWN% will be replaced with the time left until autonuke will be activated
  auto_nuke_perma_broadcast_timer: 30
  auto_nuke_perma_broadcast_message: <color=red>Alpha Warhead Emergency Detonation Sequence will engage in %COUNTDOWN% seconds</color>
  # Should the Warhead be uncancelable at the start of the Round?
  warhead_cancelable: false
  # How long should the Hint be displayed when a player tries to disable the Nuke while it can't be stopped? (-1 = Disabled)
  hint_time: 3
  # What hint should be displayed when a player tries to disable the nuke while it can't be stopped?
  hint_message: <color=red>This Nuke cannot be disabled</color>
  # How long should a broadcast be broadcasted when the AutoNuke activates? (-1 = Disabled)
  detonation_broadcast_time: 3
  # What broadcast should be broadcasted when the AutoNuke activates?
  detonation_broadcast_message: <color=red>The Alpha Warhead Detonation Sequence engaged, <b>This Warhead cannot be stopped</b></color>
  # After what time should a cassie message be broadcasted?
  cassie_warnings:
    600: Attention, all personnel, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 10 Minutes
    300: Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 5 Minutes
    120: Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 2 Minutes
    30: Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 30 Seconds
```
