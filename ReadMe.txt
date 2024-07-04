# Credit Card Validation API

## Overview

This API validates credit card numbers using the Luhn algorithm.

## Endpoints

- `POST /api/creditcard/validate`
  - **Request Body:** `{ "cardNumber": "string" }`
  - **Response:** `{ "isValid": true/false }`

## Setup

1. Clone the repository
2. Run `dotnet build`
3. Run `dotnet run`

## Testing

1. Run `dotnet test`

## SonarQube Integration

1. Install SonarQube
2. Run SonarScanner commands

## Error Handling

- Custom middleware for global error handling




Best Practices

- Keep controllers thin: Delegate business logic to services.
- Use dependency injection: For better testability and maintainability.
- Follow SOLID principles: Ensure your code is modular and scalable.
- Write unit tests: Cover critical paths and edge cases.
- Handle errors gracefully: Use middleware for global error handling.
- Document your code: Use XML comments and Swagger for API documentation.
- Use meaningful commit messages: Follow a consistent format.
- Integrate code analysis tools: Use tools like SonarQube to maintain code quality.
- Secure sensitive data: Never log or expose sensitive information like credit card numbers.