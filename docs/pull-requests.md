# Pull Requests

All changes to `main` go through a pull request (PR). **DON'T PUSH TO `main`**.

## Before Opening a PR

- [ ] Branch is up to date with `main` (`git pull origin main` and resolve conflicts)
- [ ] App builds and runs locally with no errors
- [ ] You've tested your change manually (and run any tests)
- [ ] No secrets, debug code, or commented-out code

## Opening the PR

**Title:** short summary, same style as commits (e.g. `feat: add login page`).

**Description template:**

```
## What does this PR do?
Brief summary of the change.

## Related issue
Closes #<issue number>

## How to test
1. Step one
2. Step two

## Screenshots (for UI changes)
```

Keep PRs **small and focused**. Aim for under ~300 lines changed. Smaller PRs get reviewed faster and cause fewer conflicts.

## Reviewing

- Every PR needs **at least 1 approval** from a teammate (not the author).
- Aim to review within **24 hours**. We're on a tight deadline, so don't let PRs sit.
- Review for: Does it work? Is it readable? Does it follow our [coding standards](coding-standards.md)?
- Be kind and specific. Suggest, don't demand. Use "nit:" for minor, non-blocking comments.
- Reviewer: approve or request changes. Author: reply to or resolve every comment.

## Merging

- The **author** merges once approved and checks pass.
- Use **Squash and merge** to keep `main` history clean.
- **Delete the branch** after merging.
- If something urgent is blocking the team and no reviewer is available, post in the group chat before merging.
