namespace C__9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>()
            {
               new Order { Customer = "Алиса", Product = "Ноутбук", Price = 75000,
               Quantity = 1, Category = "Электроника"},
               new Order { Customer = "Алиса", Product = "Мышь", Price = 900,
               Quantity = 2, Category = "Электроника"},
            };
            //1. Заказы дороже 1000 отсортированные по сумме
            var expensiveOrders = orders
                .Select(o =>
                new
                {
                    o.Customer,
                    o.Product,
                    Total = o.Quantity * o.Price,
                })
                .Where(x => x.Total > 1000)
                .OrderByDescending(x => x.Total);

            foreach (var o in expensiveOrders) 
            {
                Console.WriteLine($"{o.Customer} | {o.Product} | {o.Total} руб");
            }

        }
    }
}
/*
 * 
 * LINQ
 * 
 * LINQ (Language Integrated Query) - язык интегрированных запросов.
 * По сути представляет собой SQL-подобный язык запросов внутри С#
 * Необходим/удобен при работе с коллекциями, базами данных, объектами, сериализацией.
 * 
 * LINQ делится на два синтаксиса:
 * 1. Query LINQ - похож на SQL.
 * 2. Method LINQ - Обычные методы для работы с данными. Напоминает Java Scritp.
 * 
 * Примеры:
 * 1. Query LINQ: результат = from имя_переменной in источник_данных
 * select имя_переменной;
 * 2. Method LINQ: результат = источник.Select(лямбда);
 * 
 * Особенности LINQ:
 * 1. Это язык запросов внутри С#
 * 2. Отложенное выпалнение - это значит, что объект хранящий запрос, хранит ТОЛЬКО запрос до тех пор,
 * пока этот запрос не будет вызван явно или не будет обращения к результату запроса.
 * 
 * Пример:
 * Lisgt<int> lt = new List<int> {1,2,3,4,5,6,7,8,9}; 
 * var nums = lt.Where(n => % 2 == 0);
 * Console.Writeline(nums); // не будет выполнен запрос, вернёт информацию о запросе.
 * 
 * Здесь у нас переменная nums просто хранит запрос. Она его не выполняет пока мы не сделаем:
 * nums.ToList();
 * или не переберём этот объект nums (через for или  foreach)
 * 
 * Основные методы LINQ:
 * 1. Where - метод фильтрации. Фильтрует все значения по условию.
 * Lisgt<int> lt = new List<int> {1,2,3,4,5,6,7,8,9}; 
 * var nums = lt.Where(n => % 2 == 0);
 * 
 * 
 * 2. Select - метод проекции. Преобразует каждый элемент последовательности в новые объекты
 * var names = List<string> {"Jonh", "Andrew", "Anna-Maria"};
 * var info = names Select(name => new
 * {
 *     Original = name,
 *     Length = name.Length,
 *     Upper = name.ToUpper()
 * });
 * В данном примере мы из списка имён (строк) создали список анонимных объектов.
 * 3. OrderBy/OrderByDescending - метод сартировки. Сортирует по ключу. Их отличие в том,
 * что один сортирует по возраствнию, другой по убыванию.
 * var students = new[]
 * {
 *       new {Name = "Bob", Grade = 85},
 *       new {Name = "Charlie", Grade = 90},
 *       new {Name = "Alice", Grade = 76}
 * };
 * var sortedGrades = student.OrderByDescending(s => s.Grade);
 * Charlie(90), Bob(85), Alice(76)
 * Для многоуровневой сортировки используется ThenBy:
 * var sortedGrades = student.OrderByDescending(s => s.Grade)
 *                          .ThenBy(s => s.Name);
 * Сортирует сначала по оценкам, а уже потом по имени.
 * 4. GroupBy - группировка. Позволяет группировать последовательность по ключу.
 * var students = new[]
 * {
 *   new { Name = "Bob", Group = "1"},
 *   new {Name = "Charlie", Group = "1"},
 *   new {Name = "Alice", Group = "2"},
 *   new {Name = "John", Group = "3"},
 *   new {Name = "Anny", Group = "3"},
 * }
 * var groups = students.GroupBy(s => s.Group);
 * groups - Dictionary<string.string[]>
 * foreach(var group in groups)
 * {
 *  Console.WriteLine($"Group: {group.key} has {group.Count()} ppl");
 * }
 * 5. Join - Соединение. выполняет соединение двух коллекций по ключам.
 * var customers = new[]
 * {
 *   new {Id = 1, Name = "Alice"},
 *   new {Id = 2, Name = "Bob"},
 * };
 * var orders = new[]
 * {
 *   new {Id = 101, CustomerId = 1, Total = 200m},
 *   new {Id = 102, CustomerId = 1, Total = 250m},
 *   new {Id = 103, CustomerId = 2, Total = 223m},
 *   new {Id = 104, CustomerId = 2, Total = 2000m},
 *   new {Id = 105, CustomerId = 1, Total = 15m},
 * };
 * Нужно преобразовать так, чтоб получить имя заказчика, id заказа и итоговая стоимость
 * var joined = customers.Join(
 *              Orders,
 *              c => c.Id,
 *              o => o.CustomerId, 
 *              (c,o) => new {c.Name, o.Id, o.Total });
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */