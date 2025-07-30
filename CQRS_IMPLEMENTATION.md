# CQRS Implementation

This project now supports both traditional service-based architecture and CQRS (Command Query Responsibility Segregation) pattern.

## What is CQRS?

CQRS (Command Query Responsibility Segregation) is a pattern that separates read and write operations for a data store. In this implementation:

- **Commands**: Handle write operations (Create, Update, Delete)
- **Queries**: Handle read operations (Get, GetAll)
- **Handlers**: Process commands and queries
- **MediatR**: Mediator pattern implementation for handling commands and queries

## Architecture

### Commands
Commands represent write operations and are located in:
- `presentation/Commands/User/` - User commands
- `presentation/Commands/Product/` - Product commands

### Queries
Queries represent read operations and are located in:
- `presentation/Queries/User/` - User queries
- `presentation/Queries/Product/` - Product queries

### Handlers
Handlers process commands and queries and are located in:
- `presentation/Handlers/User/` - User handlers
- `presentation/Handlers/Product/` - Product handlers

### Controllers
CQRS-based controllers are located in:
- `API/Controllers/CQRS/` - CQRS controllers using MediatR

## API Endpoints

### Traditional Service-based API
- `/api/users/*` - Traditional user endpoints
- `/api/products/*` - Traditional product endpoints

### CQRS-based API
- `/api/cqrs/users/*` - CQRS user endpoints
- `/api/cqrs/products/*` - CQRS product endpoints

## Usage Examples

### Creating a User (CQRS)
```csharp
// Command
var command = new CreateUserCommand(userCreateDto);
var result = await mediator.Send(command);
```

### Getting All Users (CQRS)
```csharp
// Query
var query = new GetAllUsersQuery();
var users = await mediator.Send(query);
```

### Updating a Product (CQRS)
```csharp
// Command
var command = new UpdateProductCommand(id, productUpdateDto);
var result = await mediator.Send(command);
```

## Benefits of CQRS

1. **Separation of Concerns**: Read and write operations are clearly separated
2. **Scalability**: Can optimize read and write operations independently
3. **Flexibility**: Can use different data stores for reads and writes
4. **Maintainability**: Clear structure makes code easier to maintain
5. **Testability**: Commands and queries can be tested independently

## Dependencies Added

- **MediatR**: For handling commands and queries
- **AutoMapper**: For object mapping (configured but not yet implemented)

## Migration Path

The project maintains backward compatibility by keeping the traditional service-based controllers. You can:

1. Use traditional endpoints: `/api/users/*`, `/api/products/*`
2. Use CQRS endpoints: `/api/cqrs/users/*`, `/api/cqrs/products/*`

Both approaches work simultaneously, allowing for gradual migration.

## Next Steps

1. Implement AutoMapper for better object mapping
2. Add validation using FluentValidation
3. Implement event sourcing for audit trails
4. Add separate read/write databases for full CQRS benefits
5. Implement caching for read operations 