# Coding Standards

Make it readable please.

## Naming

| Thing                               | Style              | Example                      |
| ----------------------------------- | ------------------ | ---------------------------- |
| Classes, methods, properties, enums | `PascalCase`       | `OrderService`, `GetTotal()` |
| Interfaces                          | `I` + `PascalCase` | `IOrderService`              |
| Local variables, parameters         | `camelCase`        | `orderId`                    |
| Private fields                      | `_camelCase`       | `_orderService`              |
| Async methods                       | end with `Async`   | `GetOrdersAsync()`           |
| Constants                           | `PascalCase`       | `MaxItemsPerOrder`           |

## Project Structure (MVC)

- `Controllers/` – handle requests and return views or results. **Keep them thin.**
- `Models/` – entities and database models.
- `ViewModels/` – classes shaped for a specific view. Don't pass database entities straight to views.
- `Views/` – Razor views. Display logic only, no business logic.
- `Services/` – business logic lives here (injected into controllers via DI).
- `Api/` – exposed API endpoints for other front-end alternatives

## Rules of Thumb

- **Thin controllers, thick services.** If a controller action is growing past ~20 lines, move logic into a service.
- Use **dependency injection** instead of `new`-ing up services.
- Use `async`/`await` for database and I/O calls.
- Validate input with data annotations on ViewModels and check `ModelState.IsValid` in POST actions.
- One class per file, and the file name matches the class name.
- Use `var` when the type is obvious from the right-hand side; otherwise write the type.
- Remove unused `using`s, dead code, and commented-out code before committing.
- Avoid magic strings/numbers. Use constants or config.
- Don't leave `Console.WriteLine` or debug code in committed work.

## Secrets and Config

- **Never commit** passwords, API keys, or real connection strings.
- Use dotnetenv for sensitive configs.
- If you add a new required setting, document it in the README.

## Database / Entity Framework Migrations

Migrations are the #1 source of merge conflicts. To avoid them:

- Tell the team before adding a migration.
- Pull the latest `main` before creating one.
- Keep one migration per PR, with a descriptive name (`AddOrderStatusColumn`).

## Formatting

- 4 spaces for indentation, braces on their own line.
- Run `dotnet format` (or Visual Studio's _Format Document_) before committing.
- Aim for lines under ~120 characters.
- Match existing code
