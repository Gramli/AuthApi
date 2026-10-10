# Git context and interrupted upgrades

Read for dirty worktrees, isolation or resuming.

## Context and user changes

Record root/worktree, branch/HEAD and Git operation state; inspect staged/unstaged
diffs, untracked paths and relevant nested repositories/submodules. Keep local
content/hashes sufficient to verify preservation and distinguish user/tool changes,
including index state. Do not expose secrets or user-file contents in reports/logs.

Use current HEAD unless the user/repository specifies another inspected base.
Do not resolve unrelated merges/rebases, switch bases, fetch/merge or commit user
work merely to start. Stop unsafe overlap/unresolved conflicts.

A worktree isolates committed inputs, omitting staged/unstaged/untracked inputs.
Resolve which state matters; never silently omit/copy user changes. Choose an
unused permitted path, inspect assignments and never force replacement or share
writable node_modules. Reuse only the intended upgrade context; otherwise choose
a unique branch. Branches save commits, not uncommitted files; retain/report edits
and the worktree path when interrupted.

## Before each migration

Recheck status after installs, baseline checks and migrations, including generated
artifacts and untracked skill files. Assess schematic/lifecycle effects; do not
change ignore rules or commit unrelated files to satisfy tooling.

Verify `--allow-dirty` in the executing CLI's help/versioned docs. It bypasses
cleanliness, not file protection: require known edits, protected/excluded overlap
and subsequent preservation checks. Apply explicitly per command; new changes
require reassessment. If unsafe, isolate appropriately or resolve the specific
overlap with the user. Never substitute Git force/discard flags.

Check CLI `--create-commits` and Nx commit/agent settings. Disable unapproved
automatic commits; do not enable another agent just to run migrations.
Authorized checkpoints must preserve the user's index and stage only reviewed
upgrade changes.

## Recovery

Keep task notes or a temporary record outside the deliverable, reporting its
location when available: original versions, requested/resolved target, guide
evidence, runner/runtime/commands, completed/pending migrations and manual work,
changed paths and last validated state. Record installation, migrations and
validation as separate milestones.

Prepared plans and changed manifests are partial destinations. Reuse verified
original baseline evidence; never restore/reinstall source packages into them or
invent baseline failures. If evidence is missing, disclose it and establish a
reliable starting point from safely identifiable original inputs; an isolated
original-state check must not reset the live workspace.

Resume the existing context/record and reconcile current manifests, lock/installed
versions, output and later user edits. Distinguish installation, schematic, manual
and validation failures; do not repeat completed stages or branch by default.

For unfinished Angular schematics, establish true pre-update versions, inspect
official migration collections/CLI flags and partial edits, and assess rerun safety.
Use local `ng update <one-package> --migrate-only` with verified `--from`, `--to`
and/or `--name` as supported; recovery flags have version-specific constraints,
and schematics are not necessarily idempotent. Nx recovery uses its retained plan
and completed entries, not a new plan generated from installed destinations.

Report missing original-version/completion evidence rather than claiming a no-op.
Ordinary current workspaces without interruption evidence need no historical logs.
