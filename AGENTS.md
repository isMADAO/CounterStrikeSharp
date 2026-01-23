# Repository Guidelines

## Project Structure and Module Organization

- `src/`: Native plugin core and engine integration (C++).
- `managed/`: .NET 8 API, runtime, and test projects (C#).
- `managed/CounterStrikeSharp.API.Tests/`: xUnit-based managed tests.
- `managed/CounterStrikeSharp.Tests.Native/`: Native test plugin used in engine-level tests.
- `examples/`: Sample plugins (e.g., `examples/WarcraftPlugin`).
- `libraries/`: Vendored third-party dependencies and SDKs.
- `configs/`: Runtime and project configuration assets.
- `makefiles/`, `tooling/`, `eng/`: Build helpers and internal tooling.
- `docfx/`: Documentation generation assets.

## Build, Test, and Development Commands

- Init submodules before building:
  - `git submodule update --init --recursive`
- Configure and build the native plugin with CMake:
  - `mkdir build && cd build`
  - `cmake ..`
  - `cmake --build . --config Debug`
- Run managed tests (xUnit):
  - `dotnet test managed/CounterStrikeSharp.API.Tests/CounterStrikeSharp.API.Tests.csproj`
  - Note: `managed/CounterStrikeSharp.Tests.Native` targets in-game execution; run only in the server environment.

## Coding Style and Naming Conventions

- Formatting rules are defined in `.editorconfig`:
  - 4-space indent, LF endings, 140 max line length.
  - JSON/YAML use 2-space indent.
- C++ formatting uses `.clang-format`; lint hints live in `.clang-tidy`.
- Prefer descriptive class and method names consistent with existing C# and C++ styles.

## Testing Guidelines

- Managed tests use xUnit (see `managed/CounterStrikeSharp.API.Tests`).
- Name tests by behavior (e.g., `TranslationTests`, `SteamIdTests`).
- Keep test resources under the test project’s `Resources/` folder.

## Commit and Pull Request Guidelines

- Commit messages follow an imperative, conventional style:
  - Examples: `feat: add ...`, `fix(schema): update ...`, `chore(deps): ...`.
- Before opening a PR:
  - Search existing PRs and issues to avoid duplicates.
  - Start a discussion for large features.
  - Include a clear description, tests run, and any relevant screenshots or logs.
  - Target `master` and keep branches focused.
