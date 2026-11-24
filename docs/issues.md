# Opening Issues

Track work through issues.

## Before You Open One

1. Search existing issues to avoid duplicates.
2. Keep it to **one problem or task per issue**.

## Writing a Good Title

Short, specific, descriptive

## Bug Report Template

```
**What happened?**

**What did you expect to happen?**

**Steps to reproduce**
1.
2.
3.

**Screenshots / error messages (if any)**
```

## Feature / Task Template

```
**Description**
What needs to be built and why?

**Acceptance criteria**
- [ ]
- [ ]
```

## Labels

| Label         | Use for                          |
| ------------- | -------------------------------- |
| `bug`         | Something isn't working          |
| `feature`     | New functionality                |
| `chore`       | Setup, refactoring, config, docs |
| `urgent`      | Blocks others or is due soon     |
| `help wanted` | Needs another set of eyes        |

## Working With Issues

- **Assign yourself** when you start working on one, so nobody doubles up.
- Branch from the issue (see [git-conventions.md](git-conventions.md)) and reference it in your PR with `Closes #<number>`.
- Add a comment if you get blocked or the scope changes.
- Close issues through merged PRs, not manually, when possible.
