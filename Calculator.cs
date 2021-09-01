using System;


namespace Solbeg_Console_Calculator
{
    public class Calculator
    {
        public string Check(string[] expression)
        {
            if (expression.Length < 3)
                return "Неверынй формат ввода";

            if (!Double.TryParse(expression[0], out double digit_1))
                return "Неверный формат первого числа";
            if (!Double.TryParse(expression[2], out double digit_2))
                return "Неверный формат второго числа";

            return (expression[1]) switch
            {
                "+" => "ok",
                "-" => "ok",
                "*" => "ok",
                "/" => "ok",
                _ => "Неверный формат операции",
            };
        }

        public double Calculate(double digit_1, double digit_2, string op)
        {
            return op switch
            {
                "+" => digit_1 + digit_2,
                "*" => digit_1 * digit_2,
                "/" => digit_1 / digit_2,
                "-" => digit_1 - digit_2,
                _ => 0,
            };
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Введите выражение в формате \"число операция число\" \nДля очистки консоли введите \"clear\"");
                string expression = Console.ReadLine();
                if (expression == "clear")
                {
                    Console.Clear();
                    continue;
                }

                var arr = expression.Split(' ');
                string chek = Check(arr);
                if (chek != "ok")
                {
                    Console.WriteLine(chek);
                    continue;
                }
                var digit_1 = Convert.ToDouble(arr[0]);
                var digit_2 = Convert.ToDouble(arr[2]);
                var op = arr[1];

                var answer = Calculate(digit_1, digit_2, op);
                Console.WriteLine(answer);

                Console.WriteLine("Продолжить? \nДля продолжения введите \"yes\"");
                string response = Console.ReadLine();
                if (response != "yes")
                    break;
            }
        }
    }
}
