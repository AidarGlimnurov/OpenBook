Îñíîâíûå ôóíêöèè:
- ðåãèñòðàöèÿ ÂÑÅ
- ïðîñìîòð êíèã ÂÑÅ
- èçìåíåíèå â ëè÷íîì êàáèíåòå ÂÑÅ
- äîáàâèòü/óáðàòü êíèãó â/èç èçáðàííîãî ÂÑÅ
- íàïèñàòü îòçûâ ÂÑÅ
- ÷èòàòü â ÷èòàëêå ÂÑÅ
- ñêà÷àòü pdf ÂÑÅ
- ñîçäàòü êíèãó (äîáàâèòü öèêë, æàíðû, íàçâàíèå, îáëîæêà, îïèñàíèå, àâòîð, îïóáëèêîâàòü ñðàçó/íåïóáëèêîâàòü, äîáàâèòü ãëàâû !!!ÍÀ ÄÎÁÎÂËÅÍÈÅ ÃËÀÂ ÄÎËÆÍÀ ÁÛÒÜ ÓÄÎÁÍÀß DRAG&DROP ØÒÓÊÀ, ×ÒÎÁÛ ÌÅÍßÒÜ ÌÅÑÒÀÌÈ!!!) ÀÂÒÎÐ
- îïóáëèêîâàòü êíèãó ÀÂÒÎÐ
- ñîçäàòü öèêë (íàçâàíèå, äîáàâèòü êíèãè* íåîáÿç.) ÀÂÒÎÐ
- ñîçäàòü ãëàâó (íàçâàíèå ãëàâû, îïèñàíèå âñòðîåííûé ðåäàêòîð èëè èç ôàéëà .md, ìîæíî ñðàçó â êíèãó äîáàâèòü ìîæíî ýòî ïîçæå ñäåëàòü) ÀÂÒÎÐ
- ñîçäàòü æàíð ÀÄÌÈÍ
- ðåäàêòèðîâàòü æàíð ÀÄÌÈÍ
- Ïðîñìòàðèâàòü è ðåäàêòèðîâàòü âñå êíèãè ÀÄÌÈÍ ÌÎÆÅÒ ÇÀÕÎÄÈÒÜ ÏÎÄ ÂÑÅÌÈ ÀÊÊÀÓÍÒÀÌÈ
- Ïîèñê, êàê ïî àâòîðàì, òàê è ïî êíèãàì ÂÑÅ
- Ôèëüòðû ê ïîèñêó ÂÑÅ
- ðåäàêòîð md
- ïîäòâåðæäåíèå ïî÷òû

```mermaid
erDiagram
    User||--|{Book :use
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
        bool IsVerif
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
        string Content
        int Number
        int BookId FK
    }
    Review{
        int Id PK
        int BookId FK
        int UserId FK
        string Text
        DateTime CreateDate
        bool IsEdited
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
