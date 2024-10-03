using System;

class Commands {
    private ConnectionToDB db;

    public Commands() {
        db = new ConnectionToDB();
    }

    // Метод для отображения всех контактов
    public void ShowAllContacts() {
        db.ShowAllContacts();
    }

    // Метод для поиска контактов
    public void Search() {
        Console.WriteLine("Выберите поле для поиска:");
        Console.WriteLine("1. Имя");
        Console.WriteLine("2. Фамилия");
        Console.WriteLine("3. Номер телефона");
        Console.WriteLine("4. Email");
        Console.Write("> ");
        string choice = Console.ReadLine();

        string field = choice switch {
            "1" => "name",
            "2" => "surname",
            "3" => "phone",
            "4" => "email",
            _ => null
        };

        if (field == null) {
            Console.WriteLine("Неверный выбор.");
            return;
        }

        Console.Write("Введите строку для поиска: ");
        string query = Console.ReadLine();
        db.SearchContact(field, query);
    }

    // Метод для добавления нового контакта
    public void NewContact() {
        User user = new User();
        user.Create();
        db.SaveUser(user.Name, user.Surname, user.Phone, user.Email);
    }

    // Метод для выхода из программы
    public void Exit() {
        Console.WriteLine("Выход из программы.");
        Environment.Exit(0);
    }

    // Метод для отображения меню
    public void ShowMenu() {
        while (true) {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Показать все контакты");
            Console.WriteLine("2. Поиск контактов");
            Console.WriteLine("3. Добавить новый контакт");
            Console.WriteLine("4. Выход");
            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    ShowAllContacts();
                    break;
                case "2":
                    Search();
                    break;
                case "3":
                    NewContact();
                    break;
                case "4":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }
}
