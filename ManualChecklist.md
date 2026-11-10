# Manual QA: чек-лист для API

1. GET /posts/1: статус 200, есть поля id, userId, title, body
2. GET /posts/999999: ожидаю 404 (несуществующий пост)
3. GET /users/1: статус 200, id = 1, есть name и email
4. POST /posts с валидным телом: статус 201, в ответе есть id
5. POST /posts с пустым телом: проверить, как API реагирует
6. Заголовок ответа Content-Type = application/json
7. Время ответа в разумных пределах (до 1-2 секунд)

Примечание: jsonplaceholder это fake API, поэтому созданные данные не сохраняются.