using bankProject_C_;

Bank bank = new Bank(3);

do
{
    Console.Clear();
    Console.WriteLine(bank.Info());

    Console.WriteLine($"\n1 - Add\n2 - Delete\n3 - Select");

    int choice;
    int.TryParse(Console.ReadLine(), out choice);
    int id = 3;

    // если не "добавление клиента" то выбор его id
    if(choice != 1)
    {
        Console.WriteLine("Input client`s id");
        int.TryParse(Console.ReadLine(), out id);
    }
    
    switch(choice)
    {
        case 1:
            // добавление клиента 
            Console.WriteLine("Enter name and balance");
            string? name = Console.ReadLine();
            decimal balance;
            decimal.TryParse(Console.ReadLine(), out balance);

            Console.WriteLine(bank.Add(name, balance));
            break;

        case 2:
            // удаление клиента
            Console.WriteLine(bank.Remove(id));
            break;

        case 3:
            // работа с выбранным клиентом - операции с деньгами
            char c;
            int operation;
            decimal sum = 0;
            do
            {
                Console.WriteLine(bank.ClientInfo(id));
                Console.WriteLine($"\n1 - add money" +
                                  $"\n2 - withdrawal money" +
                                  $"\n3 - transfer money");
                
                int.TryParse(Console.ReadLine(), out operation);
               
                
                if(operation != 3)
                {
                    Console.WriteLine("\nEnter sum");
                    decimal.TryParse(Console.ReadLine(), out sum);
                }

                // операции с деньгами, в зависимости от выбранного модификатора
                switch(operation)
                {
                    case 1:
                        Console.WriteLine(bank.Transactions(id, sum, 0, 'S'));
                        break;

                    case 2:
                        Console.WriteLine(bank.Transactions(id, sum, 1, 'C'));
                        break;

                    case 3:
                        Console.WriteLine(bank.Transactions(id, sum, 2, 'C'));
                        break;
                }

                Console.WriteLine("Enought? y/n");
                c = Convert.ToChar(Console.ReadLine().ToLower());

            } while (c != 'y');
            break;
    }

    Console.WriteLine("\nPress <ESC> to exit...");

} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
