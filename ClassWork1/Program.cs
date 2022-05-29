using System;

namespace HomeWork1
{
    internal class Program
    {
        static void Main()
        {
            //S1
            S11();
            S12();
            S13();
            S14();
            S15();
            S16();
            S17();
            S18();
            S19();
            S110();
            S111();
            S112();
            S113();
            //S2
            S21();
            S22();
            S23();
            S24();
            S25();
            S26();
            S27();
            S28();
            S29();
            S210();
            S211();
            S212();
            S213();
            S214();
            S214A();
            S215();
            S216();
            S217();
            S218();
            S219();
            S220();
            S221();
            S222();
            S223();
            S224();
            S225();
            S226();
            S227();
            S228();
            //S3
            S31();
            S32();
            S33();
            S34();
            S35();
            Console.ReadKey();
            //Дорогой студент, списывающий или интересующийся, этот код может показать достаточно глупым, однако
            //я не редактировал его начиная с первого семестра первого курса. Если Вы хотите смотреть на красивый 
            //код, то Вам явно не в этот репозиторий)
            //Этот код не модифицировался по одной простой причине. Если я его перепишу, то код не будет похож на
            //код студента первого семестра первого курса.

            //Удачи, студент!
        }

        #region S1 Простейшие алгоритмы
        public static void S11()
        {
            Console.WriteLine("Задание номер 1: {0:C2}", 1.23456789);
        }

        public static void S12()
        {
            Console.WriteLine("Задание номер 2: {0:C1}", Math.E);
        }

        public static void S13()
        {
            try
            {
                Console.Write("Задание 3: Введите число: ");
                Console.WriteLine($"Вы ввели число: {decimal.Parse(Console.ReadLine())}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }
        public static void S14()
        {
            try
            {
                Console.Write("Задание 4: Введите число: ");
                Console.WriteLine($"{decimal.Parse(Console.ReadLine())} - Вот такое число Вы ввели");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }
        public static void S15()
        {
            Console.WriteLine("Задание 5: 1 13 49");
        }
        public static void S16()
        {
            Console.WriteLine("Задание 6: 7  15  100");
        }
        public static void S17()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Console.WriteLine($"Задание 7: {rnd.Next()} {rnd.Next()} {rnd.Next()}");
        }
        public static void S18()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Console.WriteLine($"Задание 8: {rnd.Next()} {rnd.Next()} {rnd.Next()} {rnd.Next()}");
        }
        public static void S19()
        {
            Console.WriteLine("Задание 9: 50\n10");
        }

        public static void S110()
        {
            Console.WriteLine("Задание 10: 5\n10\n21");
        }

        public static void S111()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Console.WriteLine($"Задание 11: {rnd.Next()}\n{rnd.Next()}\n{rnd.Next()}\n{rnd.Next()}");
        }

        public static void S112()
        {
            Console.WriteLine($"Задание 12: 5 10\n7 см");
        }

        public static void S113()
        {
            Console.WriteLine($"Задание 13: 2 кг\n13 17");
        }
        #endregion

        #region S2 Вычисления по известным формулам
        public static void S21()
        {
            try
            {
                Console.Write("Задание 2.1-a: Введите число: ");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine($"7x2+3x+6 = {7 * Math.Pow(x, 2) + 3 * x + 6}");

                Console.Write("Задание 2.1-б: Введите число: ");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine($"12a2+7a+12 = {12 * Math.Pow(x, 2) + 7 * x + 12}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S22()
        {
            try
            {
                Console.Write("Задание 2.2: Введите сторону квадрата: ");
                Console.WriteLine($"Периметр: {double.Parse(Console.ReadLine()) * 4}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S23()
        {
            try
            {
                Console.Write("Задание 2.3: Введите радиус: ");
                Console.WriteLine($"Диаметр: {double.Parse(Console.ReadLine()) * 2}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S24()
        {
            try
            {
                Console.Write("Задание 2.4: Введите высоту: ");
                Console.WriteLine($"Расстояние: {Math.Sqrt(Math.Pow(double.Parse(Console.ReadLine()) + 6350, 2) - Math.Pow(6350, 2))}");
                //??
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S25()
        {
            try
            {
                Console.Write("Задание 2.5: Введите ребро куба: ");
                double rebro = double.Parse(Console.ReadLine());
                Console.WriteLine($"Объём: {rebro * rebro * rebro}; Боковая поверхность: {rebro * rebro * 6}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S26()
        {
            try
            {
                Console.Write("Задание 2.6: Введите радиус: ");
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine($"Длина: {Math.Round(2 * Math.PI * radius)}; Объём: {Math.Round(Math.PI * radius * radius)}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S27()
        {
            try
            {
                Console.Write("Задание 2.7: Введите первое число: ");
                double num1 = double.Parse(Console.ReadLine());
                Console.Write("Введите второе число: ");
                double num2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"Ср. Арифм: {(num1 + num2) / 2}; Ср. Геом: {Math.Sqrt(num1 * num2)}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S28()
        {
            try
            {
                Console.Write("Задание 2.8: Введите массу: ");
                double mass = double.Parse(Console.ReadLine());
                Console.Write("Введите объём: ");
                double V = double.Parse(Console.ReadLine());
                Console.WriteLine($"Плотность: {mass / V} кг/м^3");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S29()
        {
            try
            {
                Console.Write("Задание 2.9: Введите кол-во человек в стране: ");
                double people = double.Parse(Console.ReadLine());
                Console.Write("Введите площадь: ");
                double S = double.Parse(Console.ReadLine());
                Console.WriteLine($"Плотность населения: {Math.Round(people / S)} человек/км^2");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S210()
        {
            try
            {
                Console.Write("Задание 2.10: Введите коэф. A(!=0): ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введите коэф. B: ");
                double b = double.Parse(Console.ReadLine());
                if (a == 0)
                {
                    Console.WriteLine("А не может быть равен 0 по условию");
                }
                else Console.WriteLine($"x = {-b / a}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S211()
        {
            try
            {
                Console.Write("Задание 2.11: Введите один катет труегольника: ");
                double kat1 = double.Parse(Console.ReadLine());
                Console.Write("Введите другой катет труегольника: ");
                double kat2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"Гипотенуза этого треуголька равна {Math.Sqrt(Math.Pow(kat1, 2) + Math.Pow(kat2, 2))}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S212()
        {
            try
            {
                Console.Write("Задание 2.12: Введите внешний радиус кольца: ");
                double rOut = double.Parse(Console.ReadLine());
                Console.Write("Введите внутренний радиус кольца: ");
                double rIn = double.Parse(Console.ReadLine());
                Console.WriteLine($"Площадь кольца равна {Math.PI * (Math.Pow(rOut, 2) - Math.Pow(rIn, 2))}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S213()
        {
            try
            {
                Console.Write("Задание 2.13: Введите один катет труегольника: ");
                double kat1 = double.Parse(Console.ReadLine());
                Console.Write("Введите другой катет труегольника: ");
                double kat2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"Периметр этого треуголька равен {kat1 + kat2 + Math.Sqrt(Math.Pow(kat1, 2) + Math.Pow(kat2, 2))}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S214()
        {
            try
            {
                Console.Write("Задание 2.14: Введите высоту трапеции: ");
                double height = double.Parse(Console.ReadLine());
                Console.Write("Введите меньшее из оснований: ");
                double osn1 = double.Parse(Console.ReadLine());
                Console.Write("Введите большее из оснований: ");
                double osn2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"Периметр: {osn1 + osn2 + Math.Sqrt(Math.Pow(osn2 - osn1, 2) + Math.Pow(height, 2))}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S214A()
        {
            try
            {
                Console.Write("Задание 2.14A: Введите длину: ");
                double dlin = double.Parse(Console.ReadLine());
                Console.Write("Введите ширину: ");
                double shir = double.Parse(Console.ReadLine());
                Console.WriteLine($"Периметр:{2 * (dlin + shir)}]\nДиагональ:{Math.Sqrt(Math.Pow(shir, 2) + Math.Pow(dlin, 2))}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S215()
        {
            try
            {
                Console.Write("Задание 2.15: Введите первое число: ");
                double num1 = double.Parse(Console.ReadLine());
                Console.Write("Введите второе число: ");
                double num2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"Сумма:{num1 + num2}\nРазность:{num1 - num2}\nПроизведение:{num1 * num2}\nЧастное:{num1 / num2}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S216()
        {
            try
            {
                Console.WriteLine("Задание 2.16: Введите три измерения прямоугольного параллелеипеда: ");
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine($"Объём:{length * width * height}; Площадь боковой поверхности: {2 * (-width * length + length * height + width * height)}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S217()
        {
            try
            {
                Console.WriteLine("Задание 2.17: Введите координаты первой точки: ");
                double x1 = double.Parse(Console.ReadLine());
                double y1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите координаты второй точки: ");
                double x2 = double.Parse(Console.ReadLine());
                double y2 = double.Parse(Console.ReadLine());
                Console.WriteLine($"Расстояние:{Math.Sqrt(Math.Pow(x1 - x2, 2) - Math.Pow(y1 - y2, 2))}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S218()
        {
            try
            {
                Console.WriteLine("Задание 2.18: Введите большее основание трапеции: ");
                double ground1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите меньшее основание трапеции: ");
                double ground2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите высоту трапеции: ");
                double height = double.Parse(Console.ReadLine());
                //найдём боковые стороны
                double side = Math.Sqrt(Math.Pow(height, 2) + Math.Pow(ground1 - ground2, 2));

                Console.WriteLine($"Периметр: {ground2 + ground1 + 2 * side}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S219()
        {
            try
            {
                Console.WriteLine("Задание 2.19: Введите большее основание трапеции: ");
                double ground1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите меньшее основание трапеции: ");
                double ground2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите угол при большем основании(в радианах): ");
                double edge = double.Parse(Console.ReadLine());
                //найдём высоту
                double height = Math.Tan(edge) * (ground1 - ground2);
                Console.WriteLine($"Площадь: {((ground2 + ground1) / 2) * height}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S220()
        {
            try
            {
                Console.WriteLine("Задание 2.20: Введите координаты первой вершины треугольника: ");
                double x1 = double.Parse(Console.ReadLine());
                double y1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите координаты первой вершины треугольника: ");
                double x2 = double.Parse(Console.ReadLine());
                double y2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите координаты первой вершины треугольника: ");
                double x3 = double.Parse(Console.ReadLine());
                double y3 = double.Parse(Console.ReadLine());
                //найдём длины сторон
                double distance1 = Math.Sqrt(Math.Pow(x1 - x2, 2) - Math.Pow(y1 - y2, 2));
                double distance2 = Math.Sqrt(Math.Pow(x1 - x3, 2) - Math.Pow(y1 - y3, 2));
                double distance3 = Math.Sqrt(Math.Pow(x3 - x2, 2) - Math.Pow(y3 - y2, 2));
                //найдём полупериметр
                double p = (distance1 + distance2 + distance3) / 2;
                Console.WriteLine($"Периметр: {distance1 + distance2 + distance3} Площадь: {Math.Sqrt(p * (p - distance1) * (p - distance2) * (p - distance3))}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S221()
        {
            try
            {
                Console.WriteLine("Задание 2.20: Введите координаты первой вершины прямоугольника: ");
                double x1 = double.Parse(Console.ReadLine());
                double y1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите координаты второй вершины прямоугольника: ");
                double x2 = double.Parse(Console.ReadLine());
                double y2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите координаты третьей вершины прямоугольника: ");
                double x3 = double.Parse(Console.ReadLine());
                double y3 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите координаты четвёртой вершины прямоугольника: ");
                double x4 = double.Parse(Console.ReadLine());
                double y4 = double.Parse(Console.ReadLine());
                //найдём длины сторон
                double distance1 = Math.Sqrt(Math.Pow(x1 - x2, 2) - Math.Pow(y1 - y2, 2));
                double distance2 = Math.Sqrt(Math.Pow(x1 - x4, 2) - Math.Pow(y1 - y4, 2));
                Console.WriteLine($"Площадь: {distance1 * distance2}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S222()
        {
            try
            {
                Console.WriteLine("Задание 2.22: Введите стоимость 1  кг конфет: ");
                double candyPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите стоимость 1  кг печенья: ");
                double cookiePrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите стоимость 1  кг яблок: ");
                double applePrice = double.Parse(Console.ReadLine());
                //найдём длины сторон
                Random rnd = new Random(DateTime.Now.Millisecond);
                Console.WriteLine($"Итог: {rnd.Next(1, 30) * candyPrice + rnd.Next(1, 30) * cookiePrice + rnd.Next(1, 30) * applePrice}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S223()
        {
            try
            {
                Console.WriteLine("Задание 2.23: Введите стоимость 1 монитора: ");
                double monitorPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите стоимость 1 системного блока: ");
                double pcPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите стоимость 1 клавиатуры: ");
                double keyboardBprice = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите стоимость 1 клавиатуры: ");
                double mousePrice = double.Parse(Console.ReadLine());
                Random rnd = new Random(DateTime.Now.Millisecond);
                Console.WriteLine($"3 Компьютера: {3 * (monitorPrice + pcPrice + keyboardBprice + mousePrice)}");
                Console.WriteLine($"N Компьютеров: {rnd.Next(1, 100) * (monitorPrice + pcPrice + keyboardBprice + mousePrice)}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S224()
        {
            try
            {
                Console.WriteLine("Задание 2.24: Введите возраст Тани: ");
                double Tanya = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите возраст Мити: ");
                double Mitia = double.Parse(Console.ReadLine());
                double srznach = (Tanya + Mitia) / 2;
                Console.WriteLine($"Среднее арифметическое: {srznach}");
                Console.WriteLine($"Разница с Таней: {Math.Abs(srznach - Tanya)}");
                Console.WriteLine($"Разница с Митей: {Math.Abs(srznach - Mitia)}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S225()
        {
            try
            {
                Console.WriteLine("Задание 2.25: Введите сокрость первого автомобиля: ");
                double V1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите сокрость второго автомобиля: ");
                double V2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите расстояние: ");
                double distance = double.Parse(Console.ReadLine());
                Console.WriteLine($"Они встретяться через {distance / (V1 + V2)}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S226()
        {
            try
            {
                Console.WriteLine("Задание 2.26: Введите сокрость первого автомобиля: ");
                double V1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите сокрость второго автомобиля: ");
                double V2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите расстояние: ");
                double distance = double.Parse(Console.ReadLine());
                Console.WriteLine($"Они встретяться через {distance / (V1 - V2)}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S227()
        {
            try
            {
                Console.WriteLine("Задание 2.27: Введите температуру в цельсиях: ");
                double temperature = double.Parse(Console.ReadLine());
                Console.WriteLine($"Фаренгейт: {temperature * 1.8 + 32}\nКальвин: {temperature + 273.15}");
            }
            catch
            {
                Console.WriteLine("Ошибка чтения числа");
            }
        }

        public static void S228() => Console.WriteLine($"Задание 2.28: \"450 градусов по Фаренгейту\" = \"{450 * 1.8 + 32} градусов по Цельсию\"");
        #endregion

        #region S3 Вычисления по известным формулам
        public static void S31()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            double a = rnd.Next();
            double b = rnd.Next();
            Console.WriteLine($"Задание 3.1: Первоначальные значения({a};{b})");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Задание 3.1: Конечные значения({a};{b})");
        }

        public static void S32()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            double first = rnd.Next();
            double second = rnd.Next();
            double third = rnd.Next();
            Console.WriteLine($"Задание 3.2-a: Первоначальные значения({first};{second};{third})");
            double temp1, temp2; //переменные для временных значений
            temp1 = second;
            temp2 = first;
            second = third;
            first = temp1;
            third = temp2;
            Console.WriteLine($"Задание 3.2-a: Конечные значения({first};{second};{third})");
            first = rnd.Next();
            second = rnd.Next();
            third = rnd.Next();
            Console.WriteLine($"Задание 3.2-b: Первоначальные значения({first};{second};{third})");
            temp1 = second;
            temp2 = third;
            second = first;
            third = temp1;
            first = temp2;
            Console.WriteLine($"Задание 3.2-b: Конечные значения({first};{second};{third})");
        }

        public static void S33()
        {
            Console.WriteLine("Задание 3.3: Примем а=2");
            double otvet = 2;
            otvet *= otvet; // операция 1
            otvet *= otvet; // операция 2
            Console.WriteLine($"Задание 3.3-a: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1
            otvet *= 2;     // операция 2
            otvet *= otvet; // операция 3
            Console.WriteLine($"Задание 3.3-б: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1 (4)
            otvet *= otvet; // операция 2
            otvet *= 4;     // операция 3
            otvet *= 2;     // операция 4
            Console.WriteLine($"Задание 3.3-в: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1 (4)
            otvet *= otvet; // операция 2 (16)
            otvet *= 16;    // операция 3
            Console.WriteLine($"Задание 3.3-г: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1 (4)
            otvet *= otvet; // операция 2 (16)
            otvet *= otvet; // операция 3
            otvet *= 2;     // операция 4
            Console.WriteLine($"Задание 3.3-д: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1 (4)
            otvet *= otvet; // операция 2 (16)
            otvet *= otvet; // операция 3
            otvet *= 4;     // операция 4
            Console.WriteLine($"Задание 3.3-е: {otvet}");
        }

        public static void S34()
        {
            Console.WriteLine("Задание 3.4: Примем а=2");
            double otvet = 2;
            otvet *= otvet; // операция 1
            otvet *= 2;     // операция 2 (Здесь а3)
            otvet *= 4;     // операция 3
            otvet *= otvet; // операция 4 (Здесь а10)
            Console.WriteLine($"Задание 3.4-a: {otvet}");
            otvet = 2;
            otvet *= otvet;  // операция 1
            otvet *= otvet;  // операция 2 (Здесь а4)
            otvet *= otvet;  // операция 3
            otvet *= otvet;  // операция 4
            otvet *= 16;     // операция 5 (Здесь а20)
            Console.WriteLine($"Задание 3.4-б: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1
            otvet *= 2;     // операция 2
            otvet *= 4;     // операция 3 (Здесь а5)
            otvet *= otvet; // операция 4
            otvet *= 8;     // операция 5 (Здесь а13)
            Console.WriteLine($"Задание 3.4-в: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1
            otvet *= otvet; // операция 2
            otvet *= 2;     // операция 3 (Здесь а5)
            otvet *= otvet; // операция 4
            otvet *= 32;     // операция 5
            otvet *= 16;     // операция 6 (Здесь а19)
                             //За 5 не получилось :SADFACE:
            Console.WriteLine($"Задание 3.4-г: {otvet}");
            otvet = 2;
            otvet *= otvet; // операция 1 (Здесь а2)
            otvet *= otvet; // операция 2
            otvet *= 2;     // операция 3 (Здесь а5)
            otvet *= otvet; // операция 4
            otvet *= 32;    // операция 5
            otvet *= 4;     // операция 6 (Здесь а17)
            Console.WriteLine($"Задание 3.4-д: {otvet}");
            otvet = 2;
            otvet *= otvet;  // операция 1
            otvet *= otvet;  // операция 2 (Здесь а4)
            otvet *= otvet;  // операция 3
            otvet *= 16;     // операция 4 (Здесь а12)
            otvet *= otvet;  // операция 5
            otvet *= 16;     // операция 6 (Здесь a28)
            Console.WriteLine($"Задание 3.4-е: {otvet}");
        }

        public static void S35()
        {
            int input = 1010;
            string result = string.Empty;
            while (input > 0)
            {
                result += input % 8;
                input /= 8;
            }
            //Перевод в 8-ричную систему
            Console.WriteLine(result);
        }
        #endregion
    }
}
