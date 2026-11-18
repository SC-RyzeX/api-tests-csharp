# QA Automation: API + UI (C# / .NET 10 / xUnit)

## Структура
- `Api/` : API-тесты (jsonplaceholder.typicode.com)
- `Ui/` : UI-тесты на Selenium (saucedemo.com), паттерн Page Object
- `Ui/Pages/` : классы страниц (LoginPage, InventoryPage, CartPage)
- `ManualChecklist.md` : ручной чек-лист

## Что проверяется
- API: GET и POST запросы, коды ответов 200/201, содержимое ответа, Theory с 3 наборами данных
- UI: логин (валидный и 3 негативных набора данных), 6 товаров на странице, добавление в корзину

## Требования
.NET 8 SDK, Google Chrome

## Запуск
    dotnet test                              (все тесты)
    dotnet test --filter Category=API        (только API)
    dotnet test --filter Category=UI         (только UI)

Без окна браузера (PowerShell):
    $env:HEADLESS="1"; dotnet test --filter Category=UI

## На что смотреть
Проверки ожидаемого результата (Assert) в каждом тесте.