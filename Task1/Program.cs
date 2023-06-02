namespace ProException
{
    public class ExceptionNon50 : Exception
    {
        public ExceptionNon50() { }
        public ExceptionNon50(string message)
        {
            Console.WriteLine(message == "" ? "Не нужно было вводить 50!.." : message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = { new ExceptionNon50(), new DivideByZeroException(), new OverflowException(), new FormatException(), new FileNotFoundException() };

            Console.Write("Введите число от 1 до 100, но не 50: ");
            string s = string.Empty;
            s = Console.ReadLine();
            try
            {
                int number = 0;
                number = Convert.ToInt32(s);
                if (number == 50) { throw new ExceptionNon50(""); }
                if (number == 0) { throw exceptions[1]; }
                int result = 240 / number;

                Console.Write("Угадайте путь к файлу: ");
                string filePath = string.Empty;
                filePath = Console.ReadLine();
                if (!File.Exists(filePath)) throw exceptions[4];
                else Console.WriteLine("Файл нашелся!");
            }
            catch (Exception e) when (e is ExceptionNon50)
            {
            }
            catch (Exception e) when (e is DivideByZeroException)
            {
                Console.WriteLine(string.Concat(e.Message, @"\\\ Мы же делим тут, а вы со своим нулем!"));
            }
            catch (Exception e) when (e is OverflowException)
            {
                Console.WriteLine(string.Concat(e.Message, @"\\\ Ой, не влезло"));
            }
            catch (Exception e) when (e is FormatException)
            {
                Console.WriteLine(string.Concat(e.Message, @"\\\ Форматом поломал систему"));
            }
            catch (Exception e) when (e is FileNotFoundException)
            {
                Console.WriteLine(string.Concat(e.Message, @"\\\ А файла то и нет"));
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}