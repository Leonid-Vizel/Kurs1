using System;
using System.Drawing;
using System.Text;
using System.Threading;

namespace ClassWork4
{
    class Program
    {
        private static Random rnd = null;
        private static int[] array = null;
        private static int temp = 0;
        private static ManualResetEvent mre; //Специальное событие, которое я использую для ожмдания завершения программы в другом потоке
        static void Main(string[] args)
        {
            mre = new ManualResetEvent(false);
            rnd = new Random(DateTime.Now.Millisecond);
            array = new int[20];
            Num1();
            Num2();
            Num3();
            Num4();
            Num5();
            mre.WaitOne();
            Console.ReadKey();
        }

        private static void Num1()
        {

            double[] multipliers = new double[3]; //множители(коэффициенты)
            try
            {
                Console.WriteLine("Введите коэффициент A:");
                multipliers[0] = double.Parse(Console.ReadLine().Replace(".", ","));
                Console.WriteLine("Введите коэффициент B:");
                multipliers[1] = double.Parse(Console.ReadLine().Replace(".", ","));
                Console.WriteLine("Введите коэффициент C:");
                multipliers[2] = double.Parse(Console.ReadLine().Replace(".", ","));
            }
            catch
            {
                Console.WriteLine("Ошибка ввода попробуйте снова!");
                Num1();
                return;
            }
            Equasion(multipliers);
        }

        private static void Equasion(double[] multipliers)
        {
            double diskr = multipliers[1] * multipliers[1] - 4 * multipliers[0] * multipliers[2]; ; //Дескриминант
            double[] answers = new double[2];
            if (diskr < 0)
            {
                Console.WriteLine("Дискриминант равен нулю!!");
                return;
            }
            answers[0] = (-multipliers[1] + Math.Sqrt(diskr)) / (2 * multipliers[0]);
            answers[1] = (-multipliers[1] - Math.Sqrt(diskr)) / (2 * multipliers[0]);
            Console.WriteLine($"Ваши ответы: {answers[0]} {answers[1]}");
        }

        private static void Num2()
        {
            int[] indexs = new int[2];
            Console.WriteLine("Сгенерированные числа:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(51);
                Console.Write(array[i] + " ");
            }
            try
            {
                Console.WriteLine("\nВведите значения ячеек, которые вы хотите поменять местами:");
                indexs[0] = Array.IndexOf(array, int.Parse(Console.ReadLine().Replace(".", ",")));
                indexs[1] = Array.IndexOf(array, int.Parse(Console.ReadLine().Replace(".", ",")));
                if (indexs[0] == -1 || indexs[1] == -1) throw new Exception("в массиве нет такие чисел");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}. Поробуйте снова!");
                Num2();
                return;
            }
            temp = array[indexs[0]];
            array[indexs[0]] = array[indexs[1]];
            array[indexs[1]] = temp;
            Console.WriteLine("Изменённый массив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        private static void Num3()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            Console.WriteLine("\nСортировка по убыванию:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        private static void Num4()
        {
            long multy = 0;
            double average;
            Console.WriteLine($"\nСумма массива: {SumMethod(ref multy, out average, array)}");
            Console.WriteLine($"Произведение массива: {multy}");
            Console.WriteLine($"Среднее арифметическое массива: {average}");
        }

        private static int SumMethod(ref long multiply, out double arifm, params int[] input)
        {
            int sum = 0;
            multiply = 1;
            foreach (int i in input)
            {
                sum += i;
                multiply *= i;
            }
            arifm = (double)sum / input.Length;
            return sum;
        }

        private static void Num5()
        {
            Console.Write("Пожалуйста введите цифру от 0 до 9:");
            string userTyped = Console.ReadLine().ToLower();
            byte userRespond = 0;
            if (byte.TryParse(userTyped, out userRespond))
            {
                if (userRespond >= 0 && userRespond <= 9)
                {
                    switch (userRespond)
                    {
                        case 0:
                            //Чтобы ошибки пропали, надо ПКМ по ссылкам проекта. Далее в поле поиска (справа сверху)
                            //введите System.Drawing. После поиска выберите пакет System.Drawing и поставьте галочку слева от него
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("0.JPG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("1.JPG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("2.JPG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("3.PNG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("4.JPG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("5.PNG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("6.PNG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("7.PNG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("8.PNG")));
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("9.PNG")));
                            break;
                        case 1:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("1.JPG")));
                            break;
                        case 2:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("2.JPG")));
                            break;
                        case 3:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("3.PNG")));
                            break;
                        case 4:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("4.JPG")));
                            break;
                        case 5:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("5.PNG")));
                            break;
                        case 6:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("6.PNG")));
                            break;
                        case 7:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("7.PNG")));
                            break;
                        case 8:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("8.PNG")));
                            break;
                        case 9:
                            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("9.PNG")));
                            break;
                    }
                    Console.WriteLine("Вот ваша цифра");
                    mre.Set(); //Сообщаем событию, что можно переставать ждать и пора завершать работу
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Неправильно! Ожидайте 3 секунды и повторите ещё раз!");
                    System.Timers.Timer timer = new System.Timers.Timer(3000); //В конструкторе вводим кол-во миллисекунд ожидания (3000мс = 3с)
                    timer.Elapsed += OnElapsed; //Привязываем событие
                    timer.AutoReset = false; //выключаем автоматический рестарт таймера
                    timer.Start(); //Стартуем таймер
                }
            }
            else
            {
                mre.Set();
                if (userTyped.Equals("exit") || userTyped.Equals("закрыть"))
                {
                    Environment.Exit(0);
                }
                try
                {
                    throw new Exception("Ошибка, цифра слишком большая, слишком маленькая или Вы вовсе ввели не цифру!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Поймано исключение: {ex.Message}");
                }
            }
        }
        private static void OnElapsed(object obj, EventArgs e)
        {
            //object и EventArgs нужны для привязки содания обработчика события срабатывания Таймера
            Console.ResetColor(); //Возвращаем цвет в обычное состояние
            Console.Clear();
            Num5();
        }

        public static string GrayscaleImageToASCII(Image img)
        {
            StringBuilder builder = new StringBuilder();
            Bitmap bmp = null;

            try
            {
                // Create a bitmap from the image
                bmp = new Bitmap(img);

                // Loop through each pixel in the bitmap

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        // Get the color of the current pixel

                        Color col = bmp.GetPixel(x, y);

                        // To convert to grayscale, the easiest method is to add
                        // the R+G+B colors and divide by three to get the gray
                        // scaled color.

                        col = Color.FromArgb((col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3);

                        // Get the R(ed) value from the grayscale color,
                        // parse to an int. Will be between 0-255.

                        int rValue = int.Parse(col.R.ToString());

                        // Append the "color" using various darknesses of ASCII character.

                        builder.Append(getGrayShade(rValue));

                        // If we're at the width, insert a line break

                        if (x == bmp.Width - 1)
                            builder.Append("\n");
                    }
                }
                return builder.ToString();
            }
            catch (Exception exc)
            {
                return exc.ToString();
            }
            finally
            {
                bmp.Dispose();
            }
        }

        private static string getGrayShade(int redValue)
        {
            string asciival = " ";

            if (redValue >= 230)
            {
                asciival = WHITE;
            }
            else if (redValue >= 200)
            {
                asciival = LIGHTGRAY;
            }
            else if (redValue >= 180)
            {
                asciival = SLATEGRAY;
            }
            else if (redValue >= 160)
            {
                asciival = GRAY;
            }
            else if (redValue >= 130)
            {
                asciival = MEDIUM;
            }
            else if (redValue >= 100)
            {
                asciival = MEDIUMGRAY;
            }
            else if (redValue >= 70)
            {
                asciival = DARKGRAY;
            }
            else if (redValue >= 50)
            {
                asciival = CHARCOAL;
            }
            else
            {
                asciival = BLACK;
            }
            return asciival;
        }

        private const string BLACK = "@";
        private const string CHARCOAL = "#";
        private const string DARKGRAY = "8";
        private const string MEDIUMGRAY = "&";
        private const string MEDIUM = "o";
        private const string GRAY = ":";
        private const string SLATEGRAY = "*";
        private const string LIGHTGRAY = ".";
        private const string WHITE = " ";
    }
}
