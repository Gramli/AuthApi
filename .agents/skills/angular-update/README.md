# Angular update skill

Upgrade Angular versions using official migrations, sequential validated majors,
protected user work and clean-install verification. No bundled scripts or extra
packages are required by the skill itself.

```text
angular-skills/
|-- SKILL.md
|-- references/
|   |-- update-guide.md
|   |-- git-and-resume.md
|   |-- workspace-variants.md
|   |-- validation.md
|   `-- legacy-and-prerelease.md
|-- assets/report-template.md
`-- README.md
```

## Install

Copy the **whole bundle**, keeping relative paths, to:

```text
<repository-root>/.agents/skills/angular-update/
```

angular-skills is a distribution folder. Keep one authoritative installed copy
and follow repository tracking policy: untracked skill files can block ng update;
the agent must preserve them, not silently commit/ignore them.

Personal location: `~/.agents/skills/angular-update`
(Windows: `%USERPROFILE%\.agents\skills\angular-update`).
Personal installs are local; repository installs serve teammates/hosted agents.
Copilot additionally supports .github/skills and ~/.copilot/skills. See
[Codex skills](https://developers.openai.com/codex/skills/) and
[Copilot skills](https://docs.github.com/en/copilot/how-tos/copilot-on-github/customize-copilot/customize-cloud-agent/add-skills).

## Use

```text
Use $angular-update to upgrade this project to Angular 22.
Use $angular-update to plan an upgrade to Angular 22 without modifying the repository.
```

Targets can be major, minor, exact or latest stable; Angular 22 is an example.
Matching version-upgrade requests can trigger automatically. Standalone conversion
and unrelated modernization are separate. Restart if discovery fails or provide
the installed SKILL.md path, with supporting files beside it.

For Copilot, use VS Code agent mode or CLI with repository/terminal access.
CLI: check `/skills list`, then invoke `/angular-update`.
See [Copilot CLI skills](https://docs.github.com/en/copilot/how-tos/copilot-cli/customize-copilot/add-skills).

## Prerequisites and recovery

Provide official documentation/registry access or sufficient exact cached evidence,
compatible local runtimes, the repository manager and validation prerequisites.
Host permissions/user choices apply; no automatic commits, pushes, PRs, manager
changes or global Node installation.

Retain the worktree/recovery record on interruption. Resume the intended context:
installed targets may still have unfinished migrations. Reports distinguish
requested/resolved/actual versions, last validated state, partial edits and remaining
work. SUCCESS needs evidence, including isolated npm ci; no-op repairs leave the
no-op path. Defective locks can undergo controlled regeneration with diff review,
affected validation and another fresh npm ci.

## Evaluate revisions

Use disposable fixtures, never live upgrades merely to test instructions.
Metadata/link checks establish packaging, not behavior. Assess decisions/artifacts:

| Scenario | Expected behavior |
| --- | --- |
| Plan/review only | Read-only; no branch/install/migration |
| Exact patch/constrained minor | Retain constraint; inspect interval evidence |
| Multiple majors, no commit authorization | Validate sequentially; no implicit commits |
| Dirty staged/unstaged/untracked files | Record/preserve them; establish safe context |
| Overlapping edits | Resolve inputs/isolation before mutation |
| Installed target after failed schematic | Recover pending migrations; no false no-op |
| Unsupported initial Node | Activate source-compatible runtime before installation |
| Nx/custom builder | Supported owner; avoid duplicate migration flows |
| Guide returns selectors | Retrieve rendered checklist or official data/logic |
| Current project without historical logs | Eligible no-op; no fabricated history requirement |
| SSR/i18n/library runtime/output failure | No SUCCESS based only on compilation |
| Optional modernization | Preserve supported setup unless scope justifies it |

Include negative triggers such as standalone conversion or unrelated feature work;
score preservation, command plans, migration coverage and evidence rather than wording.
