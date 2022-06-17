﻿using System;
using BD_Optics_Ifrastructure.Repositories;
using DB_Optics_core.Data;

namespace BD_App_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var waresRepository = new WaresRepository();
            int deleteID;
            try
            {
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
                            case "3":
                                var updatedWare = updateWares();
                                waresRepository.update(updatedWare);
                                var updated_Wares = waresRepository.getAll();
                                ShowWares(updated_Wares);
                                break;
                            case "4":
                                deleteID = getDeleteID();
                                waresRepository.delete(deleteID);
                                break;
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        static Wares updateWares()
        {
            Console.WriteLine("Введите идентификатор изменяемой записи: ");
            var ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите наименование товара: ");
            var Name = Console.ReadLine();

            Console.WriteLine("Введите стомимость товара: ");
            var Cost = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите идентификатор категории: ");
            var CategoryID = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите идентификатор специального предложения: ");
            var DiscountID = int.Parse(Console.ReadLine());

            return new Wares(ID, Name, Cost, CategoryID, DiscountID);
        }

        static int getDeleteID()
        {
            Console.WriteLine("Введите идентификатор удаляемой записи");
            int ID = int.Parse(Console.ReadLine());

            return ID;
        }
    }
}
