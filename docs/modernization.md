# Set 06: maintenance case study

## Why this slice

The baseline is commit `21469daf0ce89e466dc1a8114f2ad3ce6d163af7` (June 2023). Set 06 already contains five implementations and example-based tests, allowing a bounded improvement to existing code rather than a new unrelated application. Original test files are retained unchanged.

Priorities, in order: correctness and explicit contracts; regression tests; reproducible build and CI; readable documentation. Broad rewrites and feature additions are deferred.

## Contracts and tradeoffs

| Method | Input and output contract | Time / additional space |
| --- | --- | --- |
| `CollectionContainsWord` | Whole-string ordinal matching; optional ordinal case-insensitivity. Null source or target returns false; null entries never match; empty strings can match. Enumerates once and stops on a match. | O(total characters compared) / O(1) |
| `IsPrimeNumber` | Integers below 2 return false. Correctness is intended across the entire Int32 domain. | O(√n) / O(1) |
| `IndexOfLastUniqueLetter` | Case-sensitive UTF-16 code units, including spaces and punctuation. Returns a UTF-16 index or -1. Null throws `ArgumentNullException`. | O(n) expected / O(k) distinct code units |
| `MaxConsecutiveCount` | Longest adjacent run of equal integers, not total frequency. Empty returns 0; singleton returns 1; null throws `ArgumentNullException`. Does not mutate input. | O(n) / O(1) |
| `GetEveryNthElement` | Positions n, 2n, … using one-based positions. Null or n ≤ 0 returns an empty array, preserving supplied tests. Output is an independent array. | O(floor(count/n)) / O(floor(count/n)) output |

`divisor <= num / divisor` avoids integer overflow from squaring the divisor. Trial division is sufficient for Int32 inputs; cryptographic primality testing is outside scope.

A dictionary removes repeated scanning for uniqueness at the cost of memory. The historical method name says “letter,” but the behavior deliberately remains code-unit based. Grapheme-aware handling would require a different contract and tests; this sample does not silently reinterpret indices.

Nullable analysis is enabled in the featured implementation and new regression tests. It is not enabled wholesale over legacy exercises, which have their own inconsistent null behavior. Public method names and instance-call style remain compatible with the supplied tests. New null exceptions replace incidental null-reference exceptions for required inputs.

## Regression strategy

- `100140049` (= 10007²) exposes the original prime-check limit; `int.MaxValue` exercises the overflow-safe loop bound. A small exhaustive range is compared with straightforward trial division.
- Empty, singleton, all-distinct, and final-run arrays cover boundaries missing from the supplied run-count tests. Separated repeats must not combine; input must not change.
- Turkish culture reproduces the old casing problem. Iterators detect a second enumeration and consumption past a successful match, without timing-based assertions.
- Nulls, empty strings, whole-value matching, mixed case, spaces, accented characters, and surrogate pairs pin down text contracts.
- Extreme sampling steps, special floating-point values, and independent result storage cover selection semantics.

Original suites stay in CI to detect compatibility regressions across the SDK/test-runner migration. Sets 01–05 are not otherwise hardened in this change. Known follow-up review targets include overflow in factorial and two-sum, and null/culture policy in other methods; these are outside the featured slice.

## Repository changes

Both projects move from .NET 6 to .NET 10. Test packages are pinned to explicit versions (not described as the latest). `global.json` permits stable .NET 10 feature-band updates. Generated `bin`/`obj` contents are removed from the new tree and ignored; no old commits are rewritten. The executable becomes a deterministic five-example demo.

The workflow has read-only repository permissions, builds in Release, runs the complete suite, and preserves test-result artifacts. Package restore requires NuGet access. GitHub may require Actions to be enabled for this older fork.

## Definition of done

1. Restore, Release build, all tests, and demo pass in an environment with .NET 10.
2. Review the focused code and regressions; confirm documented null and Unicode decisions.
3. Explain why the old prime and singleton cases fail, why ordinal comparison is intentional, and the memory tradeoff in the uniqueness algorithm.
4. Only then merge and use the repository as a maintenance sample.

Suggested next personal exercise: add an exhaustive small-array reference test for consecutive runs, without AI assistance, and explain what it catches that the examples do not. No additional product features are necessary for this sample.

## Interview walkthrough

Open the original Set 06 at the baseline commit and reproduce the singleton and large-square failures. Show the regression tests and new implementation. Explain compatibility choices, then show a passing CI run. Describe the work as an AI-assisted modernization that you have personally reviewed and can modify; avoid implying this small exercise is a production system.
