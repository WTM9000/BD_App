using System;
using BD_Optics_Ifrastructure.Repositories;
using DB_Optics_core.Data;

namespace BD_App_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var waresRepository = new WaresRepository();

            Console.WriteLine("Выберете действие: \n" +
                              "1. Работа с таблицей Wares\n" +
                              "2. Работа с таблицей Warehouse\n" +
                              "3. Работа с таблицей Categories\n" +
                              "4. Аналитические запросы\n");
            var i = Console.ReadLine();
            switch (i)
            {
                case "1":
                    Console.WriteLine("Выберете действие: \n" +
                              "1. Чтение данных\n" +
                              "2. Добавление данных\n" +
                              "3. Редактирование данных\n" +
                              "4. Удаление данных\n");
                    var n = Console.ReadLine();
                    switch (n)
                    {
                        case "1":
                            var wares = waresRepository.getAll();
                            ShowWares(wares);
                            break;
                        case "2":
                            var newWare = createWares();
                            waresRepository.add(newWare);
                            var new_wares = waresRepository.getAll();
                            ShowWares(new_wares);
                            break;
                    }
                    break;
            }
        }

        static void ShowWares(Wares[] wares)
        {
            foreach (var ware in wares)
            {
                Console.WriteLine(ware);
            }
        }

        static Wares createWares()
        {
            Console.WriteLine("Введите наименование товара: ");
            var Name = Console.ReadLine();
            Console.WriteLine("Введите стомимость товара: ");
            var Cost = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите идентификатор категории: ");
            var CategoryID = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите идентификатор специального предложения: ");
            var DiscountID = int.Parse(Console.ReadLine());

            return new Wares(0, Name, Cost, CategoryID, DiscountID);
        }
    }
}
