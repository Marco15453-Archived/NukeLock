# NukeLock
A simple plugin that allows user with perms to lock the nuke (You cannot cancel it after it has been activated)

# Commands
Name | Permission | Description | CommandType
---- | ---------- | ----------- | -----------
nukelock | nl.nukelock | Switches the Warhead between cancelable and uncancelable | RemoteAdmin

# Config
Name | Type | Description | Default
---- | ---- | ----------- | -------
is_enabled | bool | Should the plugin be enabled? | true
warhead_cancelable | bool | Should the Warhead be uncancelable at the start of the Round? | false
hint_time | int | How long should the Hint be displayed wgeb a player tries to disable the Nuke while uncancelable? | 3
hint_message | string | What hint should be displayed when a player tries to disable the nuke while uncancelable? | <color=red>This Nuke cannot be disabled</color>

# Default Config
```yml
nuke_lock:
  # Should the plugin be enabled?
  is_enabled: true
  # Should the Warhead be uncancelable at the start of the Round?
  warhead_cancelable: false
  # How long should the Hint be displayed wgeb a player tries to disable the Nuke while uncancelable? (-1 = Disabled)
  hint_time: 3
  # What hint should be displayed when a player tries to disable the nuke while uncancelable?
  hint_message: <color=red>This Nuke cannot be disabled</color>
```