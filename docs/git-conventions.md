# Commit and Branch Conventions

## Branching Model

**`main`** is always working and deployable, and all work happens in **short-lived feature branches** that merge back into `main` via PR.

```
main ──●────────●─────────●──
        \      / \       /
         feature|login  fix/cart-total
```

### Branch Names

Format: `type/short-description` (lowercase, hyphens, optionally with issue number)

| Type       | Use for                    | Example                 |
| ---------- | -------------------------- | ----------------------- |
| `feature/` | New functionality          | `feature/12-login-page` |
| `fix/`     | Bug fixes                  | `fix/cart-total`        |
| `chore/`   | Setup, refactoring, config | `chore/update-packages` |
| `docs/`    | Documentation only         | `docs/readme-setup`     |

### Branch Rules

- Always branch from an up-to-date `main`:
  ```
  git checkout main
  git pull
  git checkout -b feature/12-login-page
  ```
- Keep branches short-lived: merge within a few days to limit conflicts.
- One branch per issue/task.
- **DON'T WORK DIRECTLY ON `main`**.

## Commit Messages

Format: `type: short summary` (present tense, imperative, ~50 chars)

| Type       | Use for                                 |
| ---------- | --------------------------------------- |
| `feat`     | A new feature                           |
| `fix`      | A bug fix                               |
| `docs`     | Documentation changes                   |
| `refactor` | Code change that doesn't alter behavior |
| `style`    | Formatting only                         |
| `test`     | Adding or updating tests                |
| `chore`    | Build, config, packages, etc.           |

### Examples

- ✅ `feat: add login page`
- ✅ `fix: correct cart total after item removal`
- ✅ `docs: add setup steps to README`
- ❌ `fixed stuff`
- ❌ `WIP`
- ❌ `changes`

### Commit Tips

- Commit small and often: each commit should do one thing.
- Add the issue number in the body or end if helpful: `fix: correct cart total (#18)`.
- Don't commit `bin/`, `obj/`, `.vs/`, or secrets. Make sure `.gitignore` covers them.
- Pull before you push to avoid messy merges.

## Handling Merge Conflicts

1. `git checkout main && git pull`
2. `git checkout your-branch && git merge main`
3. Resolve conflicts in your editor, then build and run the app to confirm everything still works.
4. Commit the merge and push.
