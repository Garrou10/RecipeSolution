# Recipe API - Laboration 2 (Omförsök 2)

Ett RESTful Web API byggt i ASP.NET Core 8 för att hantera recept. Projektet är utvecklat med Clean Architecture (Controller, Service, Repository) och Test Driven Development (TDD).

## 🛠️ Åtgärder från tidigare feedback
Denna inlämning åtgärdar specifikt de punkter som togs upp i tidigare bedömning:

1. **Validering & DTOs:** Controllern tar nu emot `CreateRecipeDto` istället för den faktiska domänmodellen. Detta gör att ASP.NET Core-valideringen (`[Required]`, `[Range]`, etc.) aktiveras korrekt och returnerar `400 Bad Request` vid felaktig data, innan anropet når Service-lagret.
2. **Difficulty-endpoint:** En endpoint för svårighetsgrad (`GET /api/recipes/difficulty/{level}`) är nu fullt implementerad genom hela flödet (Controller -> Service -> Repository).
3. **Swagger:** Swashbuckle är installerat och konfigurerat. API:et kan nu testas visuellt via webbläsaren.
4. **Sök-parameter:** Parametern för sök-endpointen är uppdaterad till `[FromQuery] string q` enligt specifikationen.
5. **Tester:** Testsviten är utökad till 8 godkända enhetstester (5 för Service-lagret och 3 för Controllern).

## 🚀 Hur du kör projektet

1. Klona repositoryt till din lokala maskin.
2. Öppna projektet i Visual Studio eller en terminal.
3. Navigera till API-mappen:
   ```bash
   cd RecipeApi