# Historical and prerelease paths

Read for unsupported releases, historical tooling or explicitly requested prereleases.

## Historical paths

Check support policy and archived official evidence. Downloadable packages do not
guarantee current migration support; disclose best-effort historical steps.
Keep sequential majors even when intermediates are unsupported.

Establish historical framework/CLI pairing and configuration format; majors were
not always aligned and pre-v6 paths do not universally support modern ng update.
Use versioned instructions/metadata; report missing routes rather than inventing
commands. Isolate compatible Node/managers/native dependencies locally, preserving
machine settings/user files; report missing artifacts/registries without deleting locks.

Check actual transition prerequisites: View Engine/ngcc, RxJS compatibility layers,
legacy Material/MDC, Universal/SSR packaging and custom builders. Migrate before
needed APIs/tools disappear. Verify the path rather than copying historical commands.
Pure AngularJS migration is separate; upgrading Angular in ngUpgrade hybrids remains in scope.

## Prerelease and preview APIs

Require an explicit prerelease request and verified published precision.
Unconstrained `--next` does not preserve an exact RC. Use matching official
preview/release notes, migration collections and peer/engine metadata; disclose
stable-table gaps and the evidence supporting the transition.

Inspect actual schematic ranges for prerelease-to-prerelease/stable updates.
Previously run migrations may be skipped; reinstalling stable packages need not
rerun them. Check recovery evidence and rerun safety, not presumed idempotence.

Even stable releases can change experimental/developer-preview APIs across
minor/patch intervals. Inspect used APIs and exact changes; optional preview
adoption stays outside an ordinary version upgrade.
