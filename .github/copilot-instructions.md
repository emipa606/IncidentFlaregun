# GitHub Copilot Instructions for Incident Flaregun (Continued)

## Mod Overview and Purpose
Incident Flaregun (Continued) is an updated version of the mod originally created by LingLuo. It introduces new gameplay mechanics to the RimWorld universe by adding two unique flare gun weapons. These flare guns can be crafted on the machining table and serve as tools to summon different in-game events, injecting excitement and unpredictability into the otherwise peaceful game environment.

### Key Features and Systems
- **Two New Flare Guns**: 
  - **Random Flare Gun**: This weapon randomly triggers an unspecified event.
  - **Controlled Flare Gun**: This weapon allows the player to summon a specific event of their choosing.
  
- **Crafting and Usage**: Both flare guns are crafted at the machining table, integrating seamlessly with RimWorld's existing crafting system.
  
- **Localized for Chinese and English**: The mod supports both Simplified Chinese and English languages.

### Coding Patterns and Conventions
- **C# Files**: The mod comprises four C# files, each dedicated to specific functionalities. For instance, `Verb_LaunchIncident.cs` handles the logic for event triggering when flare guns are used.
  
- **Type and Member Definitions**:
  - Use clear, descriptive names for types and members to maintain readability.
  - Keep method names indicative of their functions (e.g., `ApplyMeleeDamageToTarget`).

- **File Organization**: C# and XML files are organized by functionality (e.g., separate folders for `AttackEye` and `ZeroTechFlare`).

### XML Integration
- **Definition Files**: Use XML files for defining new game objects and behaviors:
  - `SuperGun.xml` defines the characteristics of the new flare guns.
  - `ImpliedDefs.xml` template file aids in localization and further modding capabilities.
  
- **Structure and Naming Conventions**: Keep XML tag structures consistent for easy parsing. Use precise and meaningful names for things like `ThingDef` and `unfinishedThingDef`.

### Harmony Patching
- **Method Patching**: Incorporate HarmonyLib for runtime method patching to modify or extend the base game functionality where necessary.

### Suggestions for Copilot
To enhance the development experience using GitHub Copilot, consider the following suggestions:

1. **Auto-completions for Common Patterns**: Leverage Copilot to generate boilerplate code for repetitive tasks such as XML file definitions or Harmony patches.
   
2. **Identify Code Snippets**: Use Copilot to find optimized code snippets for common tasks in C# related to weapon behaviors or event management.
   
3. **Write XML Templates**: Utilize Copilot to draft XML templates quickly for new game objects or localization entries.
   
4. **Discover C# Library Functions**: Employ Copilot for discovering and integrating C# libraries relevant to RimWorld modding, enhancing functionalities like event handling or custom UI elements.

5. **Improve Readability**: Allow Copilot to suggest improvements in code readability and documentation across the mod project.

By following these guidelines and employing the features of GitHub Copilot, you can streamline your development process for the Incident Flaregun mod and ensure high-quality code integration.


This copilot-instructions.md file provides a comprehensive guide for developers working on the "Incident Flaregun (Continued)" mod for RimWorld, covering an overview, key features, coding conventions, XML and Harmony integration, as well as suggestions for utilizing GitHub Copilot effectively.

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

