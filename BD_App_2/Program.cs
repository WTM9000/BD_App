using System;
using BD_Optics_Ifrastructure.Repositories;
using DB_Optics_core.Data;
using DB_Optics_core.Interface;

namespace BD_App_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var waresRepository = new WaresRepository();
            var categoryRepository = new CategoryRepository();
            string n;
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
                        n = Console.ReadLine();
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
                    case "3":
                        Console.WriteLine("Выберете действие: \n" +
                                  "1. Чтение данных\n" +
                                  "2. Добавление данных\n" +
                                  "3. Редактирование данных\n" +
                                  "4. Удаление данных\n");
                        n = Console.ReadLine();
                        switch(n)
                        {
                            case "1":
                                var categories = categoryRepository.getAll();
                                ShowCategories(categories);
                                break;
                            case "2":
                                var newCategory = createCategories();
                                categoryRepository.add(newCategory);
                                var new_categories = categoryRepository.getAll();
                                ShowCategories(new_categories);
                                break;
                            case "3":
                                var updatedCategory = updateCategories();
                                categoryRepository.update(updatedCategory);
                                var updated_Categories = categoryRepository.getAll();
                                ShowCategories(updated_Categories);
                                break;
                            case "4":
                                deleteID = getDeleteID();
                                categoryRepository.delete(deleteID);
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

        static void ShowCategories(Category[] categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
        }

        static Category createCategories()
        {
            Console.WriteLine("Введите наименование категории: ");
            var Name = Console.ReadLine();

            return new Category(0, Name);
        }

        static Category updateCategories()
        {
            Console.WriteLine("Введите идентификатор изменяемой записи: ");
            var ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите наименование товара: ");
            var Name = Console.ReadLine();

            return new Category(ID, Name);
        }
        static int getDeleteID()
        {
            Console.WriteLine("Введите идентификатор удаляемой записи");
            int ID = int.Parse(Console.ReadLine());

            return ID;
        }
    }
}
