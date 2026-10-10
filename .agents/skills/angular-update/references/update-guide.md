# Retrieve the selected Angular Update Guide

Read when resolving a path. Use current official sources:

- [Update Guide](https://angular.dev/update-guide)
- [Compatibility](https://angular.dev/reference/versions)
- [Release/support policy](https://angular.dev/reference/releases)
- [ng update](https://angular.dev/cli/update)
- Framework/CLI/library release notes, migration metadata and published packages.

## Checklist and phases

Obtain rendered recommendations for the selected transition when browser tooling
permits. HTTP success or selectors alone is insufficient. Choose Advanced, assess
actual API/configuration usage, and set Material/ngUpgrade/OS options for the
project and execution shell; a remote browser's OS may differ.

Confirm source/target, recommendations and phases. Record selections separately:
shared URLs may omit toggles and may not support actual minor/patch precision.
Use query parameters only when supported by the current guide.

If rendering cannot expose the checklist, inspect official
[recommendations](https://github.com/angular/angular/blob/main/adev/src/app/features/update/recommendations.ts)
and [filter/phase logic](https://github.com/angular/angular/blob/main/adev/src/app/features/update/update.component.ts).
Locate moved files in the official repository. Read, never execute, downloaded
TypeScript; record revision/date and relevant step identifiers/descriptions.
Prefer release-specific evidence over unreleased main changes.

Interpret `possibleIn`, `necessaryAsOf`, complexity and flags using matching logic;
target-major-only filtering or guessed arithmetic can omit steps. Schema fields
need not be active UI controls. Preserve before/during/after phases and classify
required, optional and inapplicable actions with exclusion evidence. Some "after"
recommendations have later deadlines. Verify automated outcomes without blindly
rerunning migrations listed in the guide.

## Precision and fallback

Check complete Node/TypeScript/RxJS ranges and effective peers/engines, including
upper bounds. Resolve conflicting broad guide statements against exact released
packages, versioned documentation and release notes before incompatible installs.

Map actual versions to supported guide selections; supplement exact minor/patch
intervals with core/CLI notes, migrations and security advisories, including SSR,
preview APIs and backports. An empty same-major checklist does not establish a no-op.

Report rendered versus source-reconstructed guidance. Generic tables, peers and
CLI logs alone cannot establish manual-step coverage. Without a checklist or
equivalent release-specific evidence, stop before dependency changes.
Offline, require sufficient supplied/cached official evidence and package artifacts
for the exact path; disclose revision/limitations and never infer current "latest"
from stale caches or substitute memory/third-party advice.
