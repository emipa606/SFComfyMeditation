# GitHub Copilot Instructions for SF Comfy Meditation (Continued)

This document outlines the guidelines and coding conventions used in the SF Comfy Meditation (Continued) mod for RimWorld. It covers the mod's purpose, key features, coding patterns, XML integration, Harmony patching, and suggestions for using GitHub Copilot effectively.

## Mod Overview and Purpose

**Name:** SF Comfy Meditation (Continued)  
**Author:** SheiFoxy  
**Description:** This mod updates SheiFoxys original mod by fixing UI-icon sizes and adding six comfy meditation pillows for each meditation focus type. Pawns can sit on these cushions and meditate at a nearby focus, similar to meditation spots.

## Key Features and Systems

### Features
- **Meditation Cushions:** Six different types of meditation cushions, each with unique stats and effects.
- **Comfort and Beauty:** Each cushion offers a balance of comfort and beauty, with some variations.
- **Throne Cushion:** One cushion functions as a throne, satisfying room throne requirements but offering less focus gain than a regular throne.

### Systems
- **Pawn Behavior:** Pawns will sit on the cushions and meditate at nearby focus points.
- **Room Requirements:** The throne cushion satisfies room throne requirements.
- **Compatibility:** Should be compatible with most mods unless they directly interfere with meditation spots.

## Coding Patterns and Conventions

### C# Coding Conventions
- **Namespace:** Use `Mlie.SFComfyMeditation` as the namespace for all C# files.
- **Class Structure:** 
  - `Base.cs`: Contains the main class `Base` with methods like `AllMeditationSpotsForPawn`, `AllOnMapOfPawnWithDef`, and a `Transpiler`.
  - `BuildingExtension_MeditationOn.cs`: Contains the class `BuildingExtension_MeditationOn` for extending building behavior.

### XML Integration
- **Def Files:** All XML definitions are located in the `1.7/Defs` directory.
- **ThingDefs:** Each cushion type is defined in its respective XML file (`Artistic Cushion.xml`, `Base Cushion.xml`, etc.).
- **ResearchProjectDefs:** Any related research projects are defined in `ResearchProjects_Misc.xml`.

### Harmony Patching
- **Transpiler:** Used to modify the behavior of existing methods in the RimWorld game code.
- **Patching Structure:** Ensure that patches are well-documented and maintainable to avoid conflicts with other mods.

## Suggestions for Copilot

### General Tips
- **Code Completion:** Use Copilot for quick code completion and suggestions when implementing new features or fixing bugs.
- **Documentation:** Leverage Copilot to generate comments and documentation for new methods and classes to improve code readability.

### XML Handling
- **Def Creation:** When creating new XML definitions, use Copilot to generate boilerplate code for `ThingDef`, `BuildingDef`, and other relevant definitions.
- **Def Integration:** Use Copilot to integrate new definitions with existing game systems, ensuring correct references and relationships.

### Harmony Patches
- **Patch Generation:** Use Copilot to generate basic patch structures, including the necessary attributes and methods.
- **Patch Testing:** After generating patches, thoroughly test them to ensure they work as expected and do not introduce conflicts with other mods.

### Best Practices
- **Modular Code:** Break down complex logic into smaller, reusable methods and classes.
- **Error Handling:** Implement error handling and logging to assist in debugging and maintaining the mod.
- **Community Engagement:** Stay connected with the RimWorld modding community to share knowledge, receive feedback, and stay updated with the latest developments.

By following these guidelines and leveraging GitHub Copilot effectively, you can contribute to the SF Comfy Meditation (Continued) mod in a way that is consistent with the project's standards and enhances the overall modding experience.

## License

This mod is open source and falls under the Zombie License 1year. If the author does not respond to permission requests for 1 year, permission is granted for someone else to take over the project.

## Credits

- **Legodude17:** For writing the C# part of the mod.
- **Rimworld Discord Modding Community:** For providing invaluable support and resources.

## Support

For best support, please use the Discord-channel for error-reporting. Do not report errors by making a discussion-thread, as the author may not receive notifications. If you have a solution for a problem, please post it to the GitHub repository.

## Tags

- cushions
- comfort

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

