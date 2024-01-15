Основные функции:
- регистрация ВСЕ
- просмотр книг ВСЕ
- изменение в личном кабинете ВСЕ
- добавить/убрать книгу в/из избранного ВСЕ
- написать отзыв ВСЕ
- читать в читалке ВСЕ
- скачать pdf ВСЕ
- создать книгу (добавить цикл, жанры, название, обложка, описание, автор, опубликовать сразу/непубликовать, добавить главы !!!НА ДОБОВЛЕНИЕ ГЛАВ ДОЛЖНА БЫТЬ УДОБНАЯ DRAG&DROP ШТУКА, ЧТОБЫ МЕНЯТЬ МЕСТАМИ!!!) АВТОР
- опубликовать книгу АВТОР
- создать цикл (название, добавить книги* необяз.) АВТОР
- создать главу (название главы, описание встроенный редактор или из файла .md, можно сразу в книгу добавить можно это позже сделать) АВТОР
- создать жанр АДМИН
- редактировать жанр АДМИН
- Просмтаривать и редактировать все книги АДМИН МОЖЕТ ЗАХОДИТЬ ПОД ВСЕМИ АККАУНТАМИ
- Поиск, как по авторам, так и по книгам ВСЕ
- Фильтры к поиску ВСЕ

```mermaid
erDiagram
    User||--|{Book :use
    User||--|{Chapter :use
    User||--||Basket :use
    User||--|{Review :use
    User}|--||Role :use

    Book||--|{Chapter :use
    Book||--|{Review :use
    Book}|--||Cycle :use

    Book||--|{BookBasket :use
    Basket||--|{BookBasket :use

    Book||--|{BookGenre :use
    Genre||--|{BookGenre :use

    Post}|--||User :use
    
    Subscribe}|--||User :Auth
    Subscribe}|--||User :Sub

    User{
        int Id PK
        string Email
        string Password
        string Name
        int RoleId FK
    }
    Book{
        int Id PK
        byte Cover
        string Name
        string Description
        string Author
        bool IsPublished
    }
    Subscribe{
        int Id PK
        int AuthorId FK
        int SunscriberId FK
    }
    Post{
        int Id PK
        int UserId FK
        string Content
        DataTime CreatedAt
    }
    Basket{
        int Id PK
        int UserId FK
    }
    Role{
        int Id PK
        string Name
    }
    Chapter{
        int Id PK
        string Name
        string Conent
        int Number
    }
    Review{
        int Id PK
        int BookId FK
        int UserId FK
    }
    Cycle{
        int Id PK
        string Name
    }
    Genre{
        int Id PK
        string Name
    }
    BookBasket{
        int BookId FK
        int BasketId FK
    }
    BookGenre{
        int BookId FK
        int BasketId FK
    }
```