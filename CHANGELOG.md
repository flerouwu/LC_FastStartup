### [1.1.2](https://github.com/flerouwu/LC_FastStartup/releases/tag/1.1.2)

**Commit:** [`75c144bb`](https://github.com/flerouwu/LC_FastStartup/commit/75c144bb89ca71f32841963962c6122a6d007878)

- **Launch Options Skip:** Fixed an issue that caused a NullReferenceException to be thrown on startup.

### [1.1.1](https://github.com/flerouwu/LC_FastStartup/releases/tag/1.1.1)

**Commit:** [`a0037ba0`](https://github.com/flerouwu/LC_FastStartup/commit/a0037ba0d55d1597392eb2de484dbd12f481b610)

**BREAKING CHANGE**

Config files have versions that are compared to check for new config values.
If you are using an older config file, a warning will be printed.

It's highly recommended to backup your config file and regenerate it.

**Changes**

<!-- Link References -->
[ea9ba803]: https://github.com/flerouwu/LC_FastStartup/commit/ea9ba80304ad18ea12d000cf994a9cbebcd2a316
[d2443b39]: https://github.com/flerouwu/LC_FastStartup/commit/d2443b39449a161b8cb14e694862b0cd60037031
[Issue #2]: https://github.com/flerouwu/LC_FastStartup/issues/2

- **Splash Screen Skip** ([`ea9ba803`][ea9ba803]): Added additional config values adjust the delay and duration of the skip.
- **Config** ([`ea9ba803`][ea9ba803]): Added config version and additional values for splash screen skip.
- **Launch Options Skip** ([`d2443b39`][d2443b39]): Fixes [Issue #2] - incompatibility with custom moons.
  - The skip now only runs once per mod load.


### [1.1.0](https://github.com/flerouwu/LC_FastStartup/releases/tag/1.1.0)

**Commit:** [`45187fe`](https://github.com/flerouwu/LC_FastStartup/commit/45187fef53bedcc3a93c5cce9fe9af74b2b2a74e)

You can now configure what the mod disables and choose the default launch mode!

### [1.0.0](https://github.com/flerouwu/LC_FastStartup/releases/tag/1.0.0)

**Commit:** [`56270aa`](https://github.com/flerouwu/LC_FastStartup/commit/56270aa1700b0670e08819442182b10e1f4f7192)

First mod release! Automatically skips all splash screens and boots into online mod.