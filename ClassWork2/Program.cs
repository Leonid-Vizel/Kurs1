using System;

namespace ClassWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            Num1();
            Num2();
            Num3();
            Num4();
            Num5();
            Num6();
            Num7();
            Console.ReadKey();
        }

        private static void Num1()
        {
            Console.WriteLine("Задание №1");
            Console.WriteLine($"BYTE - {byte.MaxValue} - {byte.MinValue}");
            Console.WriteLine($"SBYTE - {sbyte.MaxValue} - {sbyte.MinValue}");
            Console.WriteLine($"INT32 - {int.MaxValue} - {int.MinValue}");
            Console.WriteLine($"UNSIGNED INT32 - {uint.MaxValue} - {uint.MinValue}");
            Console.WriteLine($"INT64 - {long.MaxValue} - {long.MinValue}");
            Console.WriteLine($"UNSIGNED INT64 - {ulong.MaxValue} - {ulong.MinValue}");
            Console.WriteLine($"INT16 - {short.MaxValue} - {short.MinValue}");
            Console.WriteLine($"UNSIGNED INT16 - {ushort.MaxValue} - {ushort.MinValue}");
            Console.WriteLine($"FLOAT - {float.MaxValue} - {float.MinValue}");
            Console.WriteLine($"DOUBLE - {double.MaxValue} - {double.MinValue}");
            Console.WriteLine($"DECIMAL - {decimal.MaxValue} - {decimal.MinValue}");
        }

        private static void Num2()
        {
            string name, city;
            byte age;
            int code;
            try
            {
                Console.Write("Задание №2: Введите имя: ");
                name = Console.ReadLine();
                Console.Write("Введите город: ");
                city = Console.ReadLine();
                Console.Write("Введите возраст: ");
                age = byte.Parse(Console.ReadLine());
                Console.Write("Введите PIN-CODE: ");
                code = int.Parse(Console.ReadLine());
                Console.WriteLine($"Name:{name} City:{city} Age:{age}y/o Pin:{code}");
            }
            catch
            {
                Console.WriteLine("Ошибка ввода!");
            }
        }

        private static void Num3()
        {
            Console.Write("Задание №3: Введите строку: ");
            string input = Console.ReadLine();
            string output = string.Empty;
            foreach (char c in input)
            {
                if (c.ToString().ToUpper() == c.ToString())
                    output += c.ToString().ToLower();
                else output += c.ToString().ToUpper();
            }
            Console.WriteLine($"Результат:{output}");
        }

        private static void Num4()
        {
            Console.Write("Задание №4: Введите строку: ");
            string input = Console.ReadLine();
            Console.Write("Введите подстрку: ");
            string subinput = Console.ReadLine();
            Console.WriteLine((input.Length - input.Replace(subinput, "").Length) / subinput.Length);
        }

        private static void Num5()
        {
            try
            {
                Console.Write("Задание №5: Введите скорость в км/ч: ");
                Console.WriteLine($"Скорость таракана в см/с составляет {double.Parse(Console.ReadLine()) * 27.7778D}");
            }
            catch
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        private static void Num6()
        {
            try
            {
                Console.Write("Задание №6: Введите возраст сына: ");
                byte son = byte.Parse(Console.ReadLine());
                Console.Write("Введите возраст отца: ");
                byte father = byte.Parse(Console.ReadLine());
                int result = father - 2 * son;
                if (result > 0)
                {
                    Console.WriteLine($"Возвраст сына будет в 2 раза больше возраста отца через {result} лет(год)");
                }
                else if (result < 0)
                {
                    Console.WriteLine($"Возвраст сына был в 2 раза больше возраста отца {result} лет(год) назад");
                }
                else Console.WriteLine($"Возвраст сына уже в 2 раза больше возраста отца");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        private static void Num7()
        {
            int normPrice = 0, salePrice = 0, holidayPrice = 0;
            try
            {
                Console.Write("Задание №7: Введите стандартную цену: ");
                normPrice = int.Parse(Console.ReadLine());
                Console.Write("Введите процент скидки: ");
                salePrice = int.Parse(Console.ReadLine());
                Console.Write("Введите стоимость отпуска: ");
                holidayPrice = int.Parse(Console.ReadLine());
                if (normPrice <= 0)
                {
                    Console.WriteLine("Стандартная цена меньше или равна нулю! Зачем экономить, когда можно забрать бесплатно?");
                    Console.Write("Введите стандартную цену: ");
                    normPrice = int.Parse(Console.ReadLine());
                }
                if (salePrice <= 0)
                {
                    Console.WriteLine("Кажется в этом DutyFree какие-то странные скидки, нам не на чем экономить!");
                    Console.Write("Введите процент скидки: ");
                    salePrice = int.Parse(Console.ReadLine());
                }
                if (holidayPrice <= 0)
                {
                    Console.WriteLine("Зачем экономить, когда отдых бесплатный?");
                    Console.Write("Введите стоимость отпуска: ");
                    holidayPrice = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"При таких условиях Вам потребуется купить {Math.Round((double)holidayPrice / (normPrice * salePrice / 100))} бутылок виски.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
        }
    }
}
