# NukeLock
A simple plugin that allows Customization of the Warhead

# Commands
All NukeLock commands begins with `nukelock` or `nl` prefix.
Command | Prefix | Required permission | Description | Example
------- | ------ | ------------------- | ----------- | -------
arm | a | nl.arm | Arms/Unarms the Alpha Warhead. | nukelock arm
lock | l | nl.lock | Locks/Unlocks the Alpha Warhead. | nukelock lock

# Config
Name | Type | Description | Default
---- | ---- | ----------- | -------
is_enabled | bool | Should the plugin be enabled? | true
warhead_auto_armed | bool | Should the Warhead be armed at the start of the Round? | true
warhead_cancelable | bool | Should the Warhead be locked at the start of the Round? | false
radiation_death_reason | string | Death Message when the player gets killed by Radiation. | Died by Radiation
radiation_delay | float | After which delay should radiation start when the warhead detonated. (-1 = Disabled) | 120
radiation_warning_message | string | Message to be shown when the Warhead Detonated. (Empty = Disabled) | <color=red>The Alpha Warhead has been detonated, Radiation will occur in 2 Minutes</color>
radiation_begin_message | string | Message to be shown when the Radiation has occured. (Empty = Disabled) | <color=red>Radiation has now reached the Surface Zone</color>
radiation_interval | int | The Interval that the radiation_damage will be dealth to all players after the warhead detonates. | 5
radiation_damage | float | The Damage dealth to players after each radiation_interval | 2
auto_nuke | int | After what time should the warhead be automaticly started and can't be stopped (-1 = Disabled) | 900
auto_nuke_perma_broadcast_timer | int | After what autonuke time should a permanently broadcast be broadcasted across the map to tell the AutoNuke will be activated? %COUNTDOWN% will be replaced with the time left until autonuke will be activated | 30
auto_nuke_perma_broadcast_message | string | // | <color=red>Alpha Warhead Emergency Detonation Sequence will engage in %COUNTDOWN% seconds</color>
hint_time | int | How long should the Hint be displayed when a player tries to disable the Nuke while it can't be stopped? (-1 = Disabled) | 3
hint_message | string | What hint should be displayed when a player tries to disable the nuke while it can't be stopped? | <color=red>This Nuke cannot be disabled</color>
detonation_broadcast_time | ushort | How long should a broadcast be broadcasted when the AutoNuke activates? (-1 = Disabled) | 3
detonation_broadcast_message | string | What broadcast should be broadcasted when the AutoNuke activates? | <color=red>The Alpha Warhead Detonation Sequence engaged, <b>This Warhead cannot be stopped</b></color>
warhead_detonation_timer | bool | Whether or not a broadcast will be shown to all players to tell how many seconds are remaining until the warhead explodes. | true
warhead_detonation_message | string | Message to be shown to tell players how many seconds are remaining until the warhead explodes. %COUNTDOWN% will be replaced with the seconds until the warhead detonates | <color=red>Alpha Warhead detonates in T-Minus</color> <color=orange>%COUNTDOWN% seconds</color>
warhead_disables_team_respawn | bool | Whether or not team respawning will be disabled when the warhead detonated. | true
warhead_color | Colors | What Color should the warhead have when the warhead starts. (Putting one to -1 will disable it) | 255, 255, 255
cassie_warnings | Dictionary | After what time should a cassie message be broadcasted? (Empty = Disabled) | 600, 300, 120, 30

# Default Config
```yml
nuke_lock:
# Should the plugin be enabled?
  is_enabled: true
  # Should the Warhead be armed at the start of the Round?
  warhead_auto_armed: true
  # Should the Warhead be locked at the start of the Round?
  warhead_cancelable: false
  # Death Message when the player gets killed by Radiation.
  radiation_death_reason: Died by Radiation
  # After which delay should radiation start when the warhead detonated. (-1 = Disabled)
  radiation_delay: 120
  # Message to be shown when the Warhead Detonated. (Empty = Disabled)
  radiation_warning_message: <color=red>The Alpha Warhead has been detonated, Radiation will occur in 2 Minutes</color>
  # Message to be shown when the Radiation has occured. (Empty = Disabled)
  radiation_begin_message: <color=red>Radiation has now reached the Surface Zone</color>
  # The Interval that the radiation_damage will be dealth to all players after the warhead detonates.
  radiation_interval: 5
  # The Damage dealth to players after each radiation_interval
  radiation_damage: 2
  # After what time should the warhead be automaticly started and can't be stopped (-1 = Disabled)
  auto_nuke: 900
  # After what autonuke time should a permanently broadcast be broadcasted across the map to tell the AutoNuke will be activated? %COUNTDOWN% will be replaced with the time left until autonuke will be activated
  auto_nuke_perma_broadcast_timer: 30
  auto_nuke_perma_broadcast_message: <color=red>Alpha Warhead Emergency Detonation Sequence will engage in %COUNTDOWN% seconds</color>
  # How long should the Hint be displayed when a player tries to disable the Nuke while it can't be stopped? (-1 = Disabled)
  hint_time: 3
  # What hint should be displayed when a player tries to disable the nuke while it can't be stopped?
  hint_message: <color=red>This Nuke cannot be disabled</color>
  # How long should a broadcast be broadcasted when the AutoNuke activates? (-1 = Disabled)
  detonation_broadcast_time: 3
  # What broadcast should be broadcasted when the AutoNuke activates?
  detonation_broadcast_message: <color=red>The Alpha Warhead Detonation Sequence engaged, <b>This Warhead cannot be stopped</b></color>
  # Whether or not a broadcast will be shown to all players to tell how many seconds are remaining until the warhead explodes.
  warhead_detonation_timer: true
  # Message to be shown to tell players how many seconds are remaining until the warhead explodes. %COUNTDOWN% will be replaced with the seconds until the warhead detonates
  warhead_detonation_message: <color=red>Alpha Warhead detonates in T-Minus</color> <color=orange>%COUNTDOWN% seconds</color>
  # Whether or not team respawning will be disabled when the warhead detonated.
  warhead_disables_team_respawn: true
  # What Color should the warhead have when the warhead starts. (Putting one to -1 will disable it)
  warhead_color:
    red: 255
    green: 255
    blue: 255
  # After what time should a cassie message be broadcasted? (Empty = Disabled)
  cassie_warnings:
    600: Attention, all personnel, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 10 Minutes
    300: Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 5 Minutes
    120: Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 2 Minutes
    30: Danger, The Alpha Warhead Emergency Detonation Sequence will be started in TMinus 30 Seconds
```
