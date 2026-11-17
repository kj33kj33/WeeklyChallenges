# Weekly Challenges — C# re-entry sample

A focused maintenance exercise: revisit a 2023 C# practice repository, fix observable defects, make algorithm contracts explicit, and add regression tests on .NET 10.

**Start with [Challenge Set 06](ChallengesWithTestsMark8/ChallengesSet06.cs), its [new regression tests](ChallengesWithTestsMark8.Tests/ChallengesSet06RegressionTests.cs), and the [engineering walkthrough](docs/modernization.md).** The other five sets remain historical practice code, not a claim of production readiness.

## Run in five minutes

Install the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0), then:

```sh
git clone https://github.com/kj33kj33/WeeklyChallenges.git
cd WeeklyChallenges
# Until the modernization PR is merged:
git switch portfolio/set06-reentry
dotnet restore ChallengesWithTestsMark8.sln
dotnet build ChallengesWithTestsMark8.sln --configuration Release --no-restore
dotnet test ChallengesWithTestsMark8.sln --configuration Release --no-build
dotnet run --project ChallengesWithTestsMark8 --configuration Release --no-build
```

Expected demo output:

```text
Weekly Challenges | Set 06 modernization
Contains ALPHA (ignore case): True
100140049 is prime: False
Last unique index in aabbc: 4
Longest run in [1, 3, 3, 3, 2]: 3
Every third value: 3, 6
```

Run just the featured slice:

```sh
dotnet test ChallengesWithTestsMark8.sln --filter 'FullyQualifiedName~ChallengesSet06'
```

`global.json` selects a stable .NET 10 SDK, allowing newer feature bands within that major version. Both projects target `net10.0`. The application has no third-party runtime dependencies. Tests use xUnit and the Visual Studio test runner.

## What changed

| Area | 2023 behavior | Modernized behavior |
| --- | --- | --- |
| Prime detection | Stops testing divisors at 9,999; accepts 10007² as prime | Tests through the square root safely across the Int32 range |
| Consecutive runs | Singleton returns 0; repeated rescanning | Singleton returns 1; one linear pass |
| Word matching | Re-enumerates input and lowercases using current culture | Single pass, short-circuit, explicit ordinal comparison |
| Last unique character | Quadratic scan | Frequency map and reverse scan |
| Every nth element | Scans every input position | Direct indexing into a correctly sized result array |
| Repository | One-line README, old test dependencies, tracked build outputs | Reproducible commands, regression tests, CI, ignored generated output |

## Verification and scope

The GitHub Actions workflow builds the solution, runs **all original tests plus the new regressions**, runs the demo, and uploads TRX results. Check the [Actions page](https://github.com/kj33kj33/WeeklyChallenges/actions) for actual run results. A workflow file alone is not evidence of a passing run.

The editing environment did not have a .NET SDK and could not download one, so local build/test execution was unavailable. Do not describe this branch as verified until CI or a local run passes. See the PR for the latest verification status.

This is a small code-maintenance sample demonstrating debugging, boundary tests, complexity reasoning, and controlled migration. It is not a deployed application or evidence of commercial experience. No API, database, UI, or additional challenge sets are needed to finish this slice.

## Provenance

This repository is a fork of [mvdoyle/WeeklyChallenges](https://github.com/mvdoyle/WeeklyChallenges). The original exercise structure and supplied tests come from that repository; the fork contains the 2023 practice implementations. The modernization is AI-assisted and should be reviewed, run, and explained by the portfolio owner before being presented as evidence of current skills. Existing history and attribution are retained. No new license is asserted over the inherited material.
