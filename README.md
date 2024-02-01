[Visual Studio]: https://visualstudio.com/
[JetBrains Rider]: https://jetbrains.com/rider/

# FastStartup

Lethal Company mod to skip the animations / splashes that play
on game startup.

> [!NOTE]
> FastStartup does not increase the load times of your game, it only skips the initial startup animations / splash screens.

### Animations Skipped

- Startup Splashes
    - Unity watermark splash
    - Zeekerss (game developers) splash
- [Boot Animation](https://github.com/flerouwu/LC_FastStartup/blob/main/Assets/BootAnim.png)
- Launch Mode - defaults to Online
- Menu Animation (lil squash thingy)
- LAN mode warning popup (that mentions VPN / firewall usage)

### Configuration

Everything that FastStartup does is configurable within the `BepInEx/config/dev.flero.lethal.FastStartup.cfg` file.
The config file has comments that should explain what everything does. If you are confused, feel free to open an issue.

**Note:** You must have launched the game after installing the mod before the config file is generated.

<details>
<summary>Default Config</summary>

```properties
## Settings file was created by plugin FastStartup v1.1.2
## Plugin GUID: dev.flero.lethal.FastStartup

[FastStartup]

## Version of this configuration file. DO NOT CHANGE THIS
# Setting type: Int32
# Default value: 2
ConfigVersion = 2

[LaunchMode]

## Whether we should skip the launch mode screen.
# Setting type: Boolean
# Default value: true
Enabled = true

## Default mode to launch into.
# Setting type: LaunchMode
# Default value: Online
# Acceptable values: Online, Lan
DefaultMode = Online

## Whether to disable the 'You are in LAN mode' popup.
# Setting type: Boolean
# Default value: true
DisableLanPopup = true

[Skips]

## Whether we should skip the terminal-like boot animation.
# Setting type: Boolean
# Default value: true
BootAnim = true

## Whether we should skip the small squash animation of the main menu.
# Setting type: Boolean
# Default value: true
MenuAnim = true

[Splashes]

## Whether we should skip the splash screens.
# Setting type: Boolean
# Default value: true
Enabled = true

## Delay in seconds before starting the splash skip.
# Setting type: Int32
# Default value: 0
Delay = 0

## Duration in seconds of how long the loop runs for before cancelling.
# Setting type: Int32
# Default value: 15
Duration = 15
```
</details>

## Installation

### Thunderstore

You can search for "LC_FastStartup" in your package manager or manually download it on [Thunderstore](https://thunderstore.io/c/lethal-company/p/flerouwu/LC_FastStartup/).

### Direct Download

1. Download the latest release from the [releases page](https://github.com/flerouwu/LC_FastStartup/releases).

2. Extract the `flerouwu-LC_FastStartup` folder into your BepInEx plugins directory.

    Usually, this is located at `Lethal Company/BepInEx/plugins/`.

3. Launch your game and enjoy the improved startup times.

## Contributing

### Pre-requisites

- An IDE/editor that can modify .NET C# files.

    It's recommended to use [Visual Studio] or [JetBrains Rider].

- .NET Core 7.0 SDK - [Download](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

- Installed copy of Lethal Company with BepInEx 5 installed.

### Setup

1. Clone this repository.
2. Copy `FastStartup.csproj.user.example` to `FastStartup.csproj.user` and modify the contents.
