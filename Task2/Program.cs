class Namespace
{
    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.Write("Введите тип сортировки - 1 (А-Я) / 2 (Я-А): ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2) throw new FormatException();

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }

    class Program
    {
        static string[] LastNames = { "Юдин", "Иванов", "Артамонова", "Семенов", "Петрова" };

        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += ShowArray;

            try
            {
                numberReader.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение...");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введено неприлично большое значение...");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static void ShowArray(int number)
        {
            Array.Sort(LastNames);
            if (number == 2) Array.Reverse(LastNames);

            Console.WriteLine("Мы отсортировали список по вашему требованию:");
            foreach (string name in LastNames) Console.WriteLine(name);
        }
    }
}