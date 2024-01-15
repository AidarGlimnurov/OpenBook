�������� �������:
- ����������� ���
- �������� ���� ���
- ��������� � ������ �������� ���
- ��������/������ ����� �/�� ���������� ���
- �������� ����� ���
- ������ � ������� ���
- ������� pdf ���
- ������� ����� (�������� ����, �����, ��������, �������, ��������, �����, ������������ �����/�������������, �������� ����� !!!�� ���������� ���� ������ ���� ������� DRAG&DROP �����, ����� ������ �������!!!) �����
- ������������ ����� �����
- ������� ���� (��������, �������� �����* ������.) �����
- ������� ����� (�������� �����, �������� ���������� �������� ��� �� ����� .md, ����� ����� � ����� �������� ����� ��� ����� �������) �����
- ������� ���� �����
- ������������� ���� �����
- ������������� � ������������� ��� ����� ����� ����� �������� ��� ����� ����������
- �����, ��� �� �������, ��� � �� ������ ���
- ������� � ������ ���

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