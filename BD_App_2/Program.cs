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
            var wares = waresRepository.getAll();
            Console.WriteLine("Выберете действие: \n" +
                              "1. Работа с таблицей Wares\n" +
                              "2. Работа с таблицей Warehouse\n" +
                              "3. Работа с таблицей Categories\n" +
                              "4. Аналитические запросы\n");
            var i = Console.ReadLine();
            switch(i)
            {
                case "1":
                    Console.WriteLine("Выберете действие: \n" +
                              "1. Чтение данных\n" +
                              "2. Добавление данных\n" +
                              "3. Редактирование данных\n" +
                              "4. Удаление данных\n");
                    ShowWares(wares);
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
    }
}
