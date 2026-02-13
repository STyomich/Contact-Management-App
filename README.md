# Contact-Management-App

A modern, full-featured contact management application with a clean user interface and robust backend. This application allows users to create, read, update, and delete contacts efficiently with support for multiple contact fields and organization features.

## Features

- Create and manage contacts with detailed information
- Search and filter contacts
- Organize contacts into groups or categories
- Edit and update contact details
- Delete contacts with confirmation
- Responsive web interface
- REST API backend
- Data persistence with database storage

## Tech Stack

- **Backend**: MVC Server
- **Database**: MSSQL
- **Containerization**: Docker & Docker Compose

## Prerequisites

- Docker
- Docker Compose

## Quick Start with Docker Compose

### 1. Clone the Repository

```bash
git clone <repository-url>
cd Contact-Management-App
```

### 2. Environment Configuration

Configure ENV variable in docker-compose and Dockerfile.

### 3. Start the Application

```bash
docker-compose up -d
```

This command will:
- Build and start the database container
- Build and start the backend server container
- Set up all necessary networks and volumes

### 4. Access the Application

- **Presentation**: http://localhost:8080
- **Database**: localhost:1433

## Docker Compose Services

### Database Service
- MSSQL database for storing contact information
- Persistent volume for data storage
- Auto-initialization with schema

### Backend Service
- Server running on port 8080
- Handles all business logic and database operations
- Depends on database service

## Common Commands

### Start services
```bash
docker-compose up -d
```

### Stop services
```bash
docker-compose down
```

### View logs
```bash
docker-compose logs -f
```

### View specific service logs
```bash
docker-compose logs -f backend
```

### Rebuild containers
```bash
docker-compose up -d --build
```

### Access database shell
```bash
docker-compose exec db psql -U user -d contacts_db
```

## Development

To modify the application:

1. Edit source files in `src/` directory
2. Rebuild containers: `docker-compose up -d --build`
3. Changes will be reflected in running containers

## Troubleshooting

### Port already in use
Change the port mapping in `docker-compose.yml`:
```yaml
ports:
  - "8080:8080"  # Maps 8080 on host to 8080 in container
```

### Database connection errors
Ensure the database service is running:
```bash
docker-compose logs db
```

### Container won't start
Check logs for detailed error messages:
```bash
docker-compose logs service_name
```

## License

MIT

