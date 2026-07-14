# About #

This is a repo template for creating BASE Modules.

Key aspects to notice:

* Module and relevant file names contain a `KWMODULENAME` token for quick renaming using the provided `post-build.ps1` script.
* Module is composed of multiple Assemblies, following DDD patterns, approximately as follows:
  * `*.Interface.UI.Web` invokes APIs found in
  * `*.Interface.API.GraphQL`, composed of thin Controllers wrapping
  * `*.Interface.API.REST`, composed of thin Controllers wrapping
  * `*.Interface.API.ODATA`, composed of thin Controllers wrapping
  * `*.Interface.Models` and
  * `*.Application` services that orchestrate calls between
  * `*.Domain`
  * `*.Infrastructure` and
  * `*.Infrastructure.Data.EF` and
  * `*.Substrate` referring to base contracts, etc.

## Dependabot setup

Every generated module repository should keep these files:

* `.github/dependabot.yml` — checks NuGet dependencies from `/SOURCE` and GitHub Actions from `/`.
* `.github/workflows/dependabot-auto-merge.yml` — requests squash auto-merge for Dependabot major, minor, and patch updates.
* `.github/workflows/dependency-policy.yml` — reports outdated packages and fails when a package has major-version drift.

The auto-merge workflow does not bypass validation. It only requests auto-merge for pull requests created by `dependabot[bot]`. GitHub merges the pull request only after required repository checks and branch-protection rules pass.

If a module stores `Directory.Packages.props` at its repository root rather than under `/SOURCE`, change the NuGet entry's `directory` value to `/`.

When creating a module from this template:

1. Replace the `KWMODULENAME` tokens.
2. Keep the Dependabot files in `.github`.
3. Confirm the NuGet directory matches the location of `Directory.Packages.props`.
4. Enable **Allow auto-merge** in the repository's GitHub settings.
5. Require the module's build and test checks in branch protection.
6. Commit and push the new module repository before adding or updating its parent submodule pointer.
 

