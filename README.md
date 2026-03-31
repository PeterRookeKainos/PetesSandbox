# PetesSandbox
Sandbox for various projects, currently a Kainos Dot Net course.

This repository contains a collection of C# (.NET) and Python projects covering a range of topics from basic console applications through to ASP.NET Core web APIs and MVC applications.

---

## Projects

### HelloWorld
A minimal "Hello, World!" console application.  It serves as a starting point for the course and confirms that the .NET toolchain is installed and working correctly.

**Key concepts:** Console output, top-level statements.

---

### Calculator
A console application that performs basic arithmetic (addition, subtraction, multiplication, division).

- `SimpleCalculator.cs` – static `Calculate(int a, int b, char operation)` method implemented with a C# switch expression.
- Validates the operator character and guards against division by zero, throwing descriptive exceptions.
- `Program.cs` – demonstrates each of the four operations.

**Key concepts:** Static classes, switch expressions, exception handling.

---

### Fizzbuzz
A classic FizzBuzz implementation that accepts a numeric argument on the command line and prints results as a JSON-style array string.

- Numbers divisible by 3 → `"Fizz"`, by 5 → `"Buzz"`, by both → `"FizzBuzz"`, otherwise the number itself.
- Uses `StringBuilder` for efficient string construction.
- Handles quirks between `dotnet run` (passes the executable name as the first argument) and IDE execution.

**Key concepts:** Command-line arguments, `StringBuilder`, modulo arithmetic.

---

### BankAccount
A bank account management system demonstrating object-oriented design.

- `Account.cs` – encapsulates account holder name, balance, and overdraft state.
  - `Deposit(amount)` – adds funds; throws `ArgumentException` for non-positive amounts.
  - `Withdraw(amount)` – deducts funds; sets overdraft flag when balance goes negative.
  - `Transfer(targetAccount, amount)` – transfers between accounts with validation (insufficient funds, null target, self-transfer).
  - `IsOverdrawn()` – returns `true` when balance is negative.
  - `ToString()` – formats the account as `"Account Holder: <name>, Balance: <currency>"`.
- `Program.cs` – demonstrates deposit, withdrawal, and transfer operations.

**Key concepts:** Classes, properties, method overloads, exception handling, currency formatting.

---

### Shapes
A polymorphic shape hierarchy demonstrating the Factory design pattern.

- `IShape.cs` – interface defining the `GetArea()` contract.
- `Shape.cs` – abstract base class shared by all concrete shapes.
- Concrete shapes: `Circle`, `Rectangle`, `Triangle`, `Hexagon` – each calculates its own area and validates that dimensions are positive.
- `ShapeFactory.cs` – factory method that accepts a shape-type string and dimensions array, instantiating the correct shape using a switch expression.
- `Program.cs` – creates shapes directly and via the factory, and uses LINQ to query collections of shapes.

**Key concepts:** Interfaces, abstract classes, inheritance, polymorphism, Factory pattern, LINQ.

---

### Twitcher
A bird-watching data analysis application.

- `Bird.cs` – static class that stores a week of bird counts `[0, 2, 5, 3, 7, 8, 4]`.
  - Overloaded methods for both the internal array and a caller-supplied `int[]`:
    - `Today()` / `LastWeek()` – access today's or the full week's count.
    - `IncrementToday()` – increments the last day's count using the end-index (`^`) operator.
    - `HasDayWithoutBirds()` – returns `true` if any day recorded zero sightings.
    - `CountOfBirdsUpToday(day)` – sums bird counts up to (but not including) the given day.
    - `BusyDays()` – counts days where more than 5 birds were seen, using a LINQ query expression.

**Key concepts:** Static classes, overloaded methods, LINQ query syntax, `^` index operator, `yield return`.

---

### LingTutorial
A LINQ tutorial (project name is a typo of "LinqTutorial") that generates a standard 52-card deck.

- `Suits()` and `Ranks()` are iterator methods (`yield return`) that lazily produce suit and rank strings.
- A nested LINQ `from … from … select` expression computes the Cartesian product of suits × ranks.
- Each card is printed as an anonymous type `{ Suit, Rank }`.

**Key concepts:** LINQ query syntax, nested `from` clauses, `yield return`, lazy enumeration, anonymous types.

---

### Asynchronous
A teaching project that contrasts synchronous and asynchronous programming by simulating making breakfast.

- `Breakfast.cs` – synchronous implementation: each item (coffee, eggs, hash browns, toast, orange juice) is prepared one at a time using `Task.Delay(...).Wait()`.
- `BreakfastAsync.cs` – asynchronous implementation using `async`/`await` and `Task.WhenAll`, so independent cooking tasks run concurrently.
- `Program.cs` – runs both versions, measures elapsed time with `Stopwatch`, and uses ANSI escape codes to colour-code the console output for easy comparison.

**Key concepts:** `async`/`await`, `Task`, `Task.WhenAll`, `Stopwatch`, synchronous vs. asynchronous patterns.

---

### unit-testing-using-dotnet-test
An introduction to test-driven development (TDD) with xUnit.

- `PrimeService/PrimeService.cs` – `IsPrime(int candidate)` method stub: returns `false` for values less than 2 and throws `NotImplementedException` for larger values (intentionally incomplete – the exercise is to implement it).
- `PrimeService.Tests/PrimeService_IsPrimeShould.cs` – xUnit test suite covering prime and non-prime cases.

**Key concepts:** TDD, xUnit, `[Fact]`, `[Theory]`, `[InlineData]`.

---

### GitLabGenerateTests
An exploration project for working with the GitLab API and auto-generating test files.

- `Option.cs` – CLI option model parsed from command-line arguments.
- `Program.cs` – entry point (minimal; logic is being developed iteratively).
- `GitLabGenerateTests.Test/OptionTests.cs` – unit tests for the `Option` class.
- Includes a `Dockerfile` for containerised execution.

**Key concepts:** Command-line argument parsing, GitLab API integration, Docker.

---

### TodoApi
An ASP.NET Core Web API for managing a to-do list, built with Entity Framework Core and an in-memory database.

- `Models/TodoItem.cs` – data model with `Id`, `Name`, `IsComplete`, and `Secret` fields.
- `Models/TodoContext.cs` – EF Core `DbContext`.
- `Controllers/TodoItemsController.cs` – RESTful CRUD controller:
  - `GET /api/TodoItems` – list all items.
  - `GET /api/TodoItems/{id}` – retrieve a single item.
  - `POST /api/TodoItems` – create a new item.
  - `PUT /api/TodoItems/{id}` – update an existing item.
  - `DELETE /api/TodoItems/{id}` – delete an item.
- `Program.cs` – configures the in-memory database, OpenAPI/Swagger, and the controller pipeline.

**Key concepts:** ASP.NET Core Web API, Entity Framework Core, in-memory database, REST, OpenAPI.

---

### ReadConfig
An ASP.NET Core MVC application demonstrating how to read strongly-typed configuration from `appsettings.json`.

- `AppOptions.cs` – POCO class bound to a configuration section.
- `Program.cs` – registers `IOptions<AppOptions>` via the dependency injection container.
- `Controllers/HomeController.cs` – injects `IOptions<AppOptions>` and passes the values to a view.

**Key concepts:** ASP.NET Core MVC, `IConfiguration`, `IOptions<T>`, dependency injection, `appsettings.json`.

---

### ToDo (ToDoMvc)
A full ASP.NET Core MVC application for managing to-do tasks, backed by Entity Framework Core with a SQLite database.

- `Models/ToDo.cs` – data model with `Id`, `ToDoName`, `ToDoDescription`, `IsComplete`, `DateCompleted`, and `UserName`, annotated with data-validation attributes.
- `Data/ToDoContext.cs` – EF Core `DbContext`.
- `Controllers/ToDoController.cs` – MVC controller with Create, Read, Update, and Delete (CRUD) actions backed by Razor views.
- `Program.cs` – registers the EF Core context, applies migrations at startup, and configures the MVC pipeline.

**Key concepts:** ASP.NET Core MVC, Entity Framework Core, SQLite, Razor views, data annotations, CRUD.

---

### MvcMovie
A full-featured ASP.NET Core MVC application for browsing and managing a movie catalogue.

- `Models/Movie.cs` – movie entity with title, release date, genre, price, and rating.
- `Models/SeedData.cs` – seeds the database with sample movies on first run.
- `Data/MvcMovieContext.cs` – EF Core `DbContext`.
- `Controllers/MoviesController.cs` – CRUD controller with a search/filter action (`Index`) and genre filtering via a `MovieGenreViewModel`.
- `Program.cs` – wires up SQLite, Serilog structured logging, EF Core migrations, and static file serving.
- Razor views for listing, creating, editing, and deleting movies.

**Key concepts:** ASP.NET Core MVC, Entity Framework Core, SQLite, Serilog logging, Razor views, ViewModels, search/filtering.

---

### OracleLanguage
A Python script that calls the Oracle Cloud Infrastructure (OCI) AI Language service to perform several NLP tasks on two sample documents.

- **Language detection** – identifies the dominant language of each document.
- **Text classification** – categorises documents into predefined topics.
- **Named Entity Recognition (NER)** – extracts entities such as people, organisations, and locations.
- **Key phrase extraction** – identifies the most important phrases.
- **Sentiment analysis** – analyses sentiment at both the aspect and sentence level.
- **PII entity masking** – detects and masks personally identifiable information (e.g., credit card numbers, email addresses, phone numbers) with `*` characters, leaving the last four characters visible.

**Prerequisites:** OCI credentials configured (`~/.oci/config`) and a valid `compartment_id` set in the script.

**Key concepts:** OCI SDK, NLP, NER, sentiment analysis, PII masking.
