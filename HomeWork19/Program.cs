using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork19
{
    //Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,  частотой работы  процессора,
    //объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
    //Создать список, содержащий 6-10 записей с различным набором значений характеристик.
    //Определить:
    //- все компьютеры с указанным процессором.Название процессора запросить у пользователя;
    //- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
    //- вывести весь список, отсортированный по увеличению стоимости;
    //- вывести весь список, сгруппированный по типу процессора;
    //- найти самый дорогой и самый бюджетный компьютер;
    //- есть ли хотя бы один компьютер в количестве не менее 30 штук?
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> listPCs = new List<PC>()
            {
                new PC(){ Article =1223455, Brand = "Acer", CPU = "Intel Core i5", CPU_frequency = 2.9, RAM = 8, HDD=512, GPU_RAM = 4, Cost = 70000, Quantity=23},
                new PC(){ Article =4354534, Brand = "HP", CPU = "AMD Ryzen 5", CPU_frequency = 3.6, RAM = 16, HDD=1024, GPU_RAM = 4, Cost = 65000, Quantity=49},
                new PC(){ Article =5467773, Brand = "Asus", CPU = "Intel Core i3", CPU_frequency = 2.9, RAM = 8, HDD=256, GPU_RAM = 2, Cost = 45000, Quantity=2},
                new PC(){ Article =1500004, Brand = "iRU", CPU = "Intel Core i7", CPU_frequency = 4.2, RAM = 16, HDD=1024, GPU_RAM = 6, Cost = 95000, Quantity=5},
                new PC(){ Article =4432234, Brand = "iRU", CPU = "AMD Ryzen 3", CPU_frequency = 2.6, RAM = 8, HDD=512, GPU_RAM = 2, Cost = 35000, Quantity=5},
                new PC(){ Article =1000020, Brand = "MSI", CPU = "Intel Core i5", CPU_frequency = 4.4, RAM = 16, HDD=1024, GPU_RAM = 12, Cost = 150000, Quantity=1},
                new PC(){ Article =4545666, Brand = "Acer", CPU = "AMD Ryzen 5", CPU_frequency = 2.9, RAM = 16, HDD=512, GPU_RAM = 4, Cost = 80000, Quantity=23},
                new PC(){ Article =7896753, Brand = "Acer", CPU = "AMD Ryzen 3", CPU_frequency = 2.4, RAM = 8, HDD=128, GPU_RAM = 1, Cost = 30000, Quantity=14},
                new PC(){ Article =3254532, Brand = "DELL", CPU = "Intel Core i3", CPU_frequency = 3.6, RAM = 16, HDD=256, GPU_RAM = 1, Cost = 42000, Quantity=6},
                new PC(){ Article =1111111, Brand = "GIGABYTE", CPU = "Intel Core i9", CPU_frequency = 5.3, RAM = 32, HDD=2048, GPU_RAM =10 , Cost = 350000, Quantity=1},
            };            
            while (true)
            {
                Console.WriteLine("\nВведите код операции:\n1 - вывести список компьютеров по указанному процессору\n" +
                "2 - вывести все компьютеры с указанным минимальным объемом ОЗУ\n" +
                "3 - вывести список всех компьютеров, отсортированный по возрастанию цены\n" +
                "4 - вывести список всех компьютеров, отсортированный по убыванию цены\n" +
                "5 - вывести список всех компьютеровб отсортированный по типу процессора\n" +
                "6 - поиск компьютера с максимальной стоимостью\n" +
                "7 - поиск компьютера с минимальной стоимостью\n" +
                "8 - поиск наличия компьютеров в наличии в минимально необходимом количестве");
                switch (Console.ReadLine())
                {
                    case "1":
                        SearchByCPU(listPCs);
                        break;
                    case "2":
                        SearchByRAM(listPCs);
                        break;
                    case "3":
                        SortByCost(listPCs);
                        break;
                    case "4":
                        SortByCostDescending(listPCs);
                        break;
                    case "5":
                        SortByCPU(listPCs);
                        break;
                    case "6":
                        SearchMaxCost(listPCs);
                        break;
                    case "7":
                        SearchMinCost(listPCs);
                        break;
                    case "8":
                        ReqQuantity(listPCs);
                        break;
                    default:
                        Console.WriteLine("Вы ввели недопустимый код операции");
                        break;
                }
            }            
            Console.ReadKey();
        }
        public static void SearchByCPU(List<PC> listPCs)        //вывод списка ПК по указанной модели процессора
        {
            Console.WriteLine("Список достпных моделей процессоров:");
            List<string> CPUs = listPCs
                .Select(CPU => CPU.CPU)
                .Distinct()
                .ToList();
            foreach (var item in CPUs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Введите модель процессора:");
            string str = Console.ReadLine();
            List<PC> PCs = listPCs
                .Where(PC => PC.CPU == str)
                .ToList();
            Console.WriteLine("Доступные системные блоки:");
            foreach (var item in PCs)
            {
                Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
            }
        }
        public static void SearchByRAM(List<PC> listPCs)        //вывод списка ПК с объемом оперативной памяти не меньше указанной
        {
            Console.WriteLine("Введите требуемый минимальный объем памяти в Гб:");
            int str = Convert.ToInt32(Console.ReadLine());
            List<PC> PCs = listPCs
                .Where(PC => PC.RAM >= str)
                .ToList();
            Console.WriteLine("Доступные системные блоки:");
            foreach (var item in PCs)
            {
                Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
            }
        }
        public static void SortByCost(List<PC> listPCs)     //сортировка списка ПК по возрастанию цены
        {            
            List<PC> PCs = listPCs
                .OrderBy(PC => PC.Cost)
                .ToList();
            Console.WriteLine("Список доступных системных блоков отсортированный по стоимости:");
            foreach (var item in PCs)
            {
                Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
            }
        }
        public static void SortByCostDescending(List<PC> listPCs)       //сортировка списка ПК по убыванию цены
        {
            List<PC> PCs = listPCs
                .OrderByDescending(PC => PC.Cost)
                .ToList();
            Console.WriteLine("Список доступных системных блоков отсортированный по стоимости:");
            foreach (var item in PCs)
            {
                Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
            }
        }
        public static void SortByCPU(List<PC> listPCs)      //список отсортированный по типу процессора 
        {
            var PCs = listPCs
                    .GroupBy(PC => PC.CPU)
                    .Select(g => new
                    {
                        Name = g.Key,
                        Count = g.Count(),
                        PCs = g.Select(PC => PC)
                    });                    
            Console.WriteLine("Список доступных системных блоков отсортированный по типу процессора:");
            foreach (var group in PCs)
            {                
                Console.WriteLine($"\n{ group.Name}, {group.Count} шт.");
                foreach (PC item in group.PCs)
                {
                    Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
                }
            }
        }
        public static void SearchMaxCost(List<PC> listPCs) 
        {
            int maxCost = listPCs
                .Max(PC => PC.Cost);
            List<PC> PCs = listPCs
                    .Where(PC => PC.Cost == maxCost)                  
                    .ToList();
            Console.WriteLine("Список системных блоков с максимальной стоимостью:");
            foreach (var item in PCs)
            {
                Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
            }
        }       //поиск системного блока с максимальной стоимостью
        public static void SearchMinCost(List<PC> listPCs)
        {
            int minCost = listPCs
                .Min(PC => PC.Cost);
            List<PC> PCs = listPCs
                    .Where(PC => PC.Cost == minCost)
                    .ToList();
            Console.WriteLine("Список системных блоков с минимальной стоимостью:");
            foreach (var item in PCs)
            {
                Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
            }
        }       //поиск системного блока с минимальной стоимостью
        public static void ReqQuantity(List<PC> listPCs)        //поиск модели доступной на складе в необходимом количестве
        {
            Console.WriteLine("Введите необходимое количество системных блоков:");
            int str = Convert.ToInt32(Console.ReadLine());
            bool exist = listPCs
                .Any(PC => PC.Quantity >= str);
            if (exist)
            {
                List<PC> PCs = listPCs
                    .Where(PC => PC.Quantity >= str)
                    .ToList();
                Console.WriteLine("Системные блоки доступные в необходимом количестве:");
                foreach (var item in PCs)
                {
                    Console.WriteLine($"\nАртикул: {item.Article}\nПроизводитель: {item.Brand}\nМодель ЦП: {item.CPU}\nЧастота ЦП: {item.CPU_frequency} Ггц\nОбъем ОЗУ: {item.RAM} Гб\nОбъем: {item.HDD} Гб\nОбъем ОЗУ ГП: {item.GPU_RAM} Гб\nЦена: {item.Cost} руб\nОстаток: {item.Quantity} шт.");
                }
            }          
            
        }
    }   
}
