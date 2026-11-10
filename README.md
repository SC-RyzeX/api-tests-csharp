# api-tests-csharp
Sum tests or sum like dat just freestyling
THESE ARE MY NONSENSE TESTS OF BEGINNER LEVEL SO EXPECT MISTAKES AND MAYBE SOME ERRORS 
I DO THIS FOR FUN AND FOR SELF-EDU PURPOSES(for now)

# API Tests (C# / xUnit)

Автотесты для публичного тестового API https://jsonplaceholder.typicode.com

## Что проверяется
- `PostsApiTests.cs`:
  - GetPost_ReturnsCorrectPost: GET /posts/1 возвращает 200 и правильный id
  - CreatePost_Returns201: POST /posts возвращает 201 и тот же title
  - GetUser_ReturnsRequestedUser: Theory с 3 наборами данных (id 1, 2, 3)

## Запуск
Нужен .NET 8 SDK.

    dotnet test

## На что смотреть
Файл `PostsApiTests.cs`: проверки ожидаемого результата (Assert) в каждом тесте.

## Manual QA
См. `ManualChecklist.md`