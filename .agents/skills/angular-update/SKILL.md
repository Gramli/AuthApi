---
name: angular-update
description: Upgrade Angular framework and CLI versions in an existing Angular workspace. Excludes standalone conversion and unrelated Angular modernization.
---

# Angular update

Upgrade to the requested version with focused compatibility changes and preserved
behavior. User instructions and host permissions take precedence. Review, planning
and dry-run requests remain read-only.

## 1. Inspect and plan

- Read repository instructions; identify the Git/workspace root, package manager,
  lockfile, CI, apps/libraries, builders and peers. Reconcile declared, locked and
  installed versions; stale node_modules is not the migration source.
- Obtain the target if missing. Verify published releases: latest stable within a
  requested major/minor, or the exact requested version. Resolve coordinated
  package versions independently; identical patch numbers need not exist.
- Prefer the latest Node LTS compatible with target Angular/project constraints;
  honor explicit requirements. Check [runtime/npm guidance](references/workspace-variants.md#runtime-selection)
  before changing pins.
- Plan one major at a time, normally at each intermediate major's latest stable
  patch. Preserve the final constraint. Downgrades and pure AngularJS migrations
  are outside scope; use [exceptional paths](references/legacy-and-prerelease.md)
  for historical or explicitly requested prerelease upgrades.
- Read [guide retrieval](references/update-guide.md) for the actual checklist,
  compatibility ranges and before/during/after phases, including minor/patch
  supplements. Use [workspace variants](references/workspace-variants.md) for Nx,
  custom tooling, libraries and coordinated dependencies.
- Detect interrupted upgrades or prepared migration plans using
  [Git and recovery](references/git-and-resume.md). Installed target packages
  alone do not establish completion or a no-op.

Present resolved versions, migration owner, transitions, runtime changes and
validation scope. Continue authorized work; clarify material scope/safety choices.

## 2. Preserve the starting state

At target with compatible packages and no pending work, a no-op skips branch
creation, baseline installation and migrations.
Verify existing runtime/packages and section 5 requirements, including isolated
npm ci. Needed lockfile repairs or runtime-pin changes end the no-op and require
protected mutation.

Record branch/HEAD and staged, unstaged and untracked changes. Before project
mutations, create/reuse a verified upgrade branch/worktree unless the user chooses
another safe context. Follow repository naming or `chore/update-angular-<source>-to-<target>`;
never overwrite a branch. Temporary evidence/caches need no project branch.

Follow [Git and recovery](references/git-and-resume.md) for isolation, dirty-tree
options and resuming. Preserve user files/index; never automatically stash, reset,
clean, restore user files or rewrite history. Do not implicitly commit, push or
open PRs; honor explicit authorization and applicable repository instructions.

## 3. Establish the baseline

Activate source-compatible Node/package manager before installation or project
tooling; check complete ranges/engines. Use the existing runtime manager within
user constraints; report unavailable activation before dependency changes.

For fresh upgrades, inspect lifecycle effects and install/verify source dependencies
reproducibly where supported. Run and record scoped [validation](references/validation.md).
For resumed work, reuse original baseline evidence and recover pending stages;
never reinstall source packages against already-changed destination manifests.
Resolve migration-blocking baseline problems within scope or report the blocker.

## 4. Complete each transition

1. Maintain original package versions, destinations, commands, migration milestones
   and last validated state in task notes or a local record outside the deliverable.
2. Execute required before/during/after steps in order using compatible temporary
   runtimes. Verify final Node/npm before updating project/CI pins.
3. Recheck dirty-tree safety before every migration. Use the selected owner's
   verified local tooling and resolved versions. Avoid global ng or implicit latest
   downloads for inspection; required temporary CLIs must be versioned/supported.
   For Angular CLI, run local ng update through the manager with resolved versions.
   Follow Nx/custom plans; coordinate Angular, Material/CDK, SSR and third-party
   migrations as described in [workspace variants](references/workspace-variants.md).
4. Preserve supported architecture/tooling; decide optional migration prompts
   before execution. Modernization needs a request or justification within scope.
5. Apply [validation](references/validation.md), inspect changes against the starting
   state, fix upgrade-caused failures and rerun invalidated checks. Complete this
   step's migrations/dependency checks/required validation before advancing.
   On interruption, preserve edits and follow recovery; installed packages do not
   become a validated source automatically.

## 5. Complete and report

SUCCESS requires the resolved target, coordinated compatibility and supported
actual Node/TypeScript/RxJS, completed migrations, preserved user changes,
passing installation/build/runtime checks,
and configured tests/lint passing or demonstrably unchanged baseline failures.
For npm, require [fresh-directory npm ci](references/validation.md#final-clean-directory-npm-verification)
with supported Node, CI's npm version and lifecycle scripts enabled, including
no-ops. Follow its repair/full-regeneration fallback, diff review and revalidation;
preserve the live installation. Missing required evidence prevents SUCCESS.

Use PARTIAL after a validated transition when target/evidence remains incomplete;
otherwise BLOCKED, disclosing partial edits. Identify validated no-ops explicitly.
Adapt [the report template](assets/report-template.md), respecting user format.
Include clean-install command, Node/npm versions, platform/result and unavailable
native CI-platform verification alongside migration, validation and recovery evidence.
