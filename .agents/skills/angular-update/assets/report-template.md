# Angular upgrade report

Adapt this template to the user's output format. Include evidence, not empty
sections. For review/plan-only requests, report a read-only plan rather than an
execution status. Keep official links beside the decisions they support when useful.

```text
Angular update
Context: <branch and worktree path, or existing context for no-op/preflight block>
Git state: <uncommitted migration changes; existing user changes preserved>
Original source: <resolved versions before this task's first migration>
Requested target: <user constraint>
Resolved target: <exact core and coordinated package destinations>
Actual versions: <installed/resolved versions; distinguish inconsistent states>
Result: SUCCESS | PARTIAL | BLOCKED <explicitly identify a validated no-op>

Upgrade path and important changes
<planned/completed transitions, migration owner, meaningful required changes>
Last validated state: <versions, runtime and validation scope>

Validation
<command, project/configuration/environment and result for installation/build>
<selected tests/lint/feature checks with commands and actual results>
<unchanged baseline failures, not configured, or not run with reasons>

Remaining work
<failed command and relevant error, unfinished migrations/manual work and next action>
Recovery evidence: <record location or task evidence needed to resume>
<None when all required work is complete>

Official evidence
<sources, selected guide versions/options, retrieval method and recorded revision>
<minor/patch supplements; historical/prerelease/offline limitations when applicable>
```

PARTIAL means at least one validated transition completed while target/required
evidence remains incomplete. BLOCKED can still include installed packages or
partial edits; never imply that an unsuccessful command left the workspace untouched.
For SUCCESS with unchanged baseline failures, show those limitations explicitly.
