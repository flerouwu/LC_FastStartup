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

## Installation

### Thunderstore

TODO: Upload to Thunderstore.

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
