# Validation

Read for final npm verification and feature-dependent checks. Use repository/CI
commands scoped to affected projects.

## Baseline and checks

Record source-supported runtimes, commands/configuration and failure evidence.
Matching error text alone does not establish an unchanged baseline cause.
Resolve/report failures preventing a reliable migration starting point.

Verify manifest/lock/installed-tree consistency; workspace installs are preliminary.
Run affected production builds, configured non-watch tests/lint and necessary
libraries/configurations. Do not introduce unrelated test/lint frameworks.
Rerun checks invalidated by fixes; use existing tests/focused checks rather than
creating a broad suite. Unresolved upgrade-caused failures prevent advancement.

## Final clean-directory npm verification

Workspace npm ci can pass with incomplete nested lock entries that fail fresh CI.
Before SUCCESS for npm, including no-ops:

1. Create a fresh temporary copy outside the live workspace, within permissions.
   Include final package.json, package-lock.json/npm-shrinkwrap.json, .npmrc and
   other install configuration, workspace manifests, local dependencies/archives,
   patches and lifecycle inputs, preserving relative layout. No node_modules in
   any copied input; do not reference the live dependency tree/local inputs.
2. Activate the selected final Node and effective CI npm version, including any
   separate npm pin; verify actual versions against final configuration, not host
   defaults/latest. Match resolution-affecting CI flags/env.
   Inspect copied scripts/inputs to prevent live-workspace/user-file mutations.
3. Run real `npm ci --ignore-scripts=false --dry-run=false` with required CI flags.
   Confirm effective lifecycle-script execution and prerequisites. Do not hide
   failures by disabling scripts. Dry runs, lockfile-only operations and existing-
   workspace installs are insufficient.
4. Report command, Node/npm, OS/platform/architecture, lifecycle setting, exit
   status/result and verified inputs; later install-input changes invalidate proof.
   Prefer native CI verification; disclose unavailability and the actual platform.
   Missing native verification prevents SUCCESS when required by the project.
   Keep authentication out of reports.

Use the executing version's [npm ci guidance](https://docs.npmjs.com/cli/commands/npm-ci).
Other managers retain their supported workflow; this gate does not authorize conversion.

## Final runtime and publishing checks

Using final Node/package-manager versions and the verified clean installation,
run configured builds and applicable package/publish dry runs, such as
`npm publish --dry-run`. Supply inputs and inspect lifecycle effects in isolation;
use supported commands and report versions, commands/results. Dry runs cannot
verify publishing authentication (OIDC exchange/registry authorization); report
it as unverified. Do not publish merely to validate.

## Repair and full regeneration

Retain/classify the error. Repair lock defects in isolation using the repository
manager's generation workflow, preserving the live installation. Review changes
before applying them in the protected upgrade context; do not bypass peers or
silently update unrelated dependencies.

If a demonstrated lock defect survives targeted repair:

- Save the failed lock for comparison. In another fresh copy without node_modules,
  remove only the copied lockfile. Preserve user files/original installation.
- Run real `npm install --ignore-scripts=false --dry-run=false` with supported Node,
  CI's npm and applicable configuration/flags. Preserve requested Angular precision
  and declared constraints; record full regeneration.
- Review added nested entries plus version, integrity, registry/resolution and tree
  changes. Preserve unrelated resolutions where practical, explain necessary
  changes and verify coordinated compatibility before applying the reviewed lock.
- Rerun affected builds/tests/checks against the regenerated graph in isolation;
  previous-workspace results do not validate changed resolutions.

After either repair, recopy final reviewed inputs into another fresh directory
without node_modules and repeat real npm ci. npm install generation is recovery,
not final verification. Report regeneration/dependency changes; investigate
remaining failures with retained evidence instead of repeatedly discarding locks.

A failed check ends an apparent no-op; permitted repair first needs protected
mutation. Honor read-only scope and report unavailable/out-of-scope verification
or repairs as blockers. Keep live installation/user files intact throughout.

## Feature checks

Choose applicable checks from official release notes, including minor/patch,
preview/security and change-detection changes that compile successfully.

| Feature | Required evidence when affected |
| --- | --- |
| Browser | Startup, routing, forms, async updates and console errors; preserve zone/zoneless and change-detection behavior unless required/requested. New-app defaults alone do not justify conversion. |
| SSR/hydration/prerender | Actual rendered HTML, hydration, routes/host configuration and prerender output; build success or HTTP responses can conceal client-rendering fallback. |
| PWA | Worker generation, asset paths/registration and affected offline/update behavior using existing harnesses; generation alone is insufficient runtime evidence. |
| i18n | Affected localized production builds, localize compatibility, translation errors, locale output/base URLs. |
| Material/CDK | Themes, DOM/overlays/interactions, migration TODOs and intended visual differences; review golden changes. |
| Libraries | Production packaging/entry points and appropriate consumer builds; source aliases can conceal peer/packaging failures. |
| Deployment/builders | Output layout, server entry, assets/baseHref, styles/custom features and consuming scripts. Adjust configuration for changed artifact contracts; do not deploy merely to validate. |
| Supported browsers | Compare required Browserslist/support with [target policy](https://angular.dev/reference/versions). Resolve dropped requirements without silently changing support or speculative polyfills. |

## Results and limitations

Never hide errors or weaken compiler/lint checks, assertions, coverage or budgets,
skip tests or regenerate snapshots merely to pass. Explain justified changes;
official fallback options need assessment and a user choice only for unresolved
material risk/behavior.

Distinguish pass, fail, unchanged baseline failure, not configured and not run
with reason. Document missing infrastructure/credentials/browsers and run useful
local checks. Missing required build/runtime/clean-install evidence prevents
SUCCESS; justified optional expensive skips need not block.
