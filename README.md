# URL Shortener Backend

A minimalist URL shortening service. This backend generates short codes for long URLs and stores them for redirection purposes.

---

## ✨ Key Features

- **URL Shortening**: Convert long URLs into 7-character short codes
- **Unique Code Generation**: Random codes with collision detection
- **Database Storage**: Persistent storage using Entity Framework Core
- **REST API**: Basic endpoints for URL management
- **Validation**: Automatic code uniqueness checks

---

## 🛠️ Project Structure

| File                      | Description                                  |
|---------------------------|----------------------------------------------|
| `ShortenController.cs`    | API endpoints (to be implemented)            |
| `ShortenedUrl.cs`         | Database entity model                        |
| `ShortnerUrlRequest.cs`   | Request DTO for URL shortening               |
| `UrlShorteningServices.cs`| Core shortening logic service                |
| `AppDbContext.cs`         | Database context configuration               |
| `Program.cs`              | Application configuration and startup        |

---


### Code Generation Logic
- **7-character codes** using `A-Z, a-z, 0-9` (62 possible characters → ~3.5 trillion combinations)
- Random generation with `System.Random`
- Database uniqueness verification before returning codes


### Key Sections in the README:

1. **Features**: Highlights the main functionality of the API.
2. **Technologies Used**: Details the stack used in the project.
3. **Setup Instructions**: Describes how to set up and run the project.
4. **API Endpoints**: Lists and explains the available API routes.
5. **Directory Structure**: Provides an overview of the file structure in the project.
6. **Contributing**: Offers guidance for contributors.
7. **License**: If you are using a particular license (like MIT), it can be mentioned here.

Feel free to adjust any of the sections according to your needs!



