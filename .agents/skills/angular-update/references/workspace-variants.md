# Workspace and dependency variants

Read for Nx/custom tooling, libraries or coordinated peers. Preserve the manager
and workspace boundaries; package.json files are not necessarily install roots.

## Resolution and tooling

Reconcile packageManager, lockfile, manager/Angular CLI configuration and CI.
Inspect workspaces, overrides/resolutions, patches, aliases and file/link inputs.
Resolve conflicts before installing; never delete a lockfile to bypass peers.
Use reproducible baseline/final installs and documented update modes.

Discover framework packages/update groups, optional localize/elements/upgrade/
service-worker/SSR/language-service packages, compiler-cli, CLI/devkit/build
packages, builders, Material/CDK and third-party migration collections.
Verify effective peers/engines, framework alignment and duplicate runtimes;
independent package releases need not share patch numbers.

Record compatible exact destinations within constraints. Use verified local
execution; missing binaries must not silently trigger latest downloads.
Officially required temporary CLIs need explicit published versions and compatible
engines/source/target paths.

## Runtime selection

Choose the latest patch of the newest LTS line matching target Angular and
project/tooling constraints. Verify [Node LTS status](https://nodejs.org/en/about/previous-releases)
and [Angular ranges](https://angular.dev/reference/versions); honor explicit requirements.
Use older compatible Node temporarily for baseline/intermediate migrations.

Before changing Node pins, verify bundled/effective CI npm, overrides, published
Node engines and install/publish requirements, including current Node/npm minima
and provider/workflow requirements for [trusted publishing/OIDC](https://docs.npmjs.com/trusted-publishers/).
Pin npm separately in project/CI when needed; preserve the package manager and
publishing method. Report compatibility conflicts.

## Migration owner

For Nx, use matching help/release guidance, the
[Angular/Nx matrix](https://nx.dev/docs/kb/angular-nx-version-matrix) and
[update workflow](https://nx.dev/docs/features/automate-updating-dependencies).
Nx/Angular majors differ; plan compatible checkpoints and aligned plugins.
Inspect planned package changes/migrations, install with the workspace manager,
then execute the plan. Account for included/omitted Angular/CLI/Material schematics;
run independent ng update only for an officially identified missing step.
Retain recovery evidence and verify commit/prompt/agent behavior; newer documented
features may be absent from installed Nx.

Custom/non-CLI workspaces follow their documented supported migration route.
Do not create angular.json or convert builders to force the default workflow.
If no route exists, explain it; version edits alone do not prove migration.

## Libraries and peers

Inspect library manifests/peers, ng-package/entry points, TypeScript and ng-packagr
compatibility. Build dependencies in order, production packages and consumer apps;
development source aliases can hide packaging failures. Check partial/full Ivy and
declared consumer support against [library guidance](https://angular.dev/tools/libraries/creating-libraries).
Rebuild local/link libraries, avoid duplicate runtimes and unsupported peer-range
expansion, and consult exceptional-path guidance for View Engine/ngcc.

Plan Material/CDK (including CDK-only), SSR, ngUpgrade, test/lint plugins and
third-party releases/migrations before updates. Run documented schematics;
do not add Material to CDK-only projects. Inspect themes/DOM and migration TODOs.

Source-only/destination-only peers need a documented joint update or bridge release.
Do not cycle incompatible installs or replace libraries without authorization;
report unsupported transitions and scoped alternatives.

For `--force`, distinguish stale metadata from actual incompatibility; require
supporting evidence, explained residual risk, no safer route and authorization
when a material choice remains. Never silently bypass peers or combine bypasses.
Preserve warnings and validate affected runtime behavior.
