using System.Text.RegularExpressions;
using System.Globalization;
using IntoOOP;

const string header = "                     -= Калькулятор =-\n\n";
const string pattern09 = @"[-]{0,1}[0-9]{1,}";
const string numberPattern = pattern09 + @"([.]{1,1}[0-9]{1,})?";
const string doublePattern = @"^[\s]{0,}" + numberPattern + @"[\s]{0,}$";
const string ratioPattern = @"^[\s]{0,}" + pattern09 + @"[\s]{0,}/[\s]{0,}" + pattern09 + @"[\s]{0,}$";
const string complexPattern = @"^[\s]{0,}" + numberPattern + @"[\s]{0,}[+]{1,1}[\s]{0,}[i]{1,1}[\s]{0,}[*]{0,1}[\s]{0,}" + 
    numberPattern + @"[\s]{0,}$";

string[] operators = new string[] { "+", "-", "*", "/", "%", "==", "!=", ">", "<", ">=", "<=" };
char[] separators = new char[] { '+', 'i', '*', ' ' };
var opersStr = string.Join(", ", operators);

object[] objs = new object[2];
string oper = null!;
string error = null!;

while (true)
{
    for (int i = 0; i < 2; i++)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(header);

        if (objs[0] == null || i == 1)
        {
            Console.WriteLine(" * Рациональные числа указываются в формате 1/2, -4/1...");
            Console.WriteLine(" * Вещественые числа указываются в формате 0.1, -10.5...");
            Console.WriteLine(" * Комплексные числа указываются в формате 1 + i2, -0.1 + i * -0.3...\n");

            if (error != null)
            {
                Console.WriteLine("{0}\n", error);
                error = null!;
            } 
            else Console.WriteLine('\n');

            Console.WriteLine($"Укажите {(i == 0 ? "первый" : "второй")} операнд: \n");

            if (i == 1) Console.Write("{0}  {1}  ", objs[0], oper);
            var input = Console.ReadLine();
            try
            {
                objs[i] = GetOperand(input!);
            }
            catch
            {
                error = "Некорректный ввод. Повторите попытку...";
                i--; continue;
            }

            if (i == 0) { i--; continue; }
        }

        if (i == 0)
        {
            Console.WriteLine(" * Операторы: {0}\n\n\n", opersStr);
            if (error != null)
            {
                Console.WriteLine("{0}\n", error);
                error = null!;
            }
            else Console.WriteLine('\n');
            Console.WriteLine($"Укажите оператор: \n");
            Console.Write("{0}  ", objs[0]);
            oper = Console.ReadLine()!.Trim();
            if (!operators.Contains(oper)) 
            {
                error = "Некорректный ввод. Повторите попытку...";
                i--; continue; 
            }
        }
    }

    string result = string.Empty;

    if (objs[0].GetType() == typeof(Complex))
        result = GetResultComplex();
    else if (objs[0].GetType() == typeof(Ratio))
        result = GetResultRatio();
    else  result = GetResult();

    Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.WriteLine(header);
    Console.WriteLine();
    Console.WriteLine(" * Для выхода нажмите Esc...\n");
    Console.WriteLine(" * Чтобы продолжить, нажмите любую клавишу...\n\n\n");
    Console.Write("{0}  {1}  {2}  =  {3}", objs[0], oper, objs[1], result);

    objs[0] = null!;

    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
}

object GetOperand(string str)
{ 
    if (Regex.Match(str, doublePattern).Success)
        return double.Parse(str, CultureInfo.InvariantCulture);
    else if (Regex.Match(str, ratioPattern).Success)
    {
        var arr = str.Split('/', StringSplitOptions.RemoveEmptyEntries);
        return new Ratio(int.Parse(arr[0]), int.Parse(arr[1]));
    }
    else if (Regex.Match(str, complexPattern).Success)
    {
        var arr = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        return new Complex(double.Parse(arr[0], CultureInfo.InvariantCulture), 
            double.Parse(arr[1], CultureInfo.InvariantCulture));
    }

    throw new ArgumentException(nameof(str), "Некорректный формат строки.");
}

string GetResultComplex()
{
    Complex value = default;
    if (objs[1].GetType() == typeof(Complex)) value = (Complex)objs[1];
    else if (objs[1].GetType() == typeof(Ratio)) value = (Complex)(Ratio)objs[1];
    else value = (Complex)(double)objs[1];

    return CalcComplex((Complex)objs[0], value, oper);
}

string GetResultRatio()
{
    if (objs[1].GetType() == typeof(Complex))
        return CalcComplex((Complex)(Ratio)objs[0], (Complex)objs[1], oper);

    Ratio value = default!;
    if (objs[1].GetType() == typeof(Ratio)) value = (Ratio)objs[1];
    else value = (Ratio)(double)objs[1];

    return CalcRatio((Ratio)objs[0], value, oper);
}

string GetResult()
{
    if (objs[1].GetType() == typeof(Complex))
        return CalcComplex((Complex)(double)objs[0], (Complex)objs[1], oper);

    if (objs[1].GetType() == typeof(Ratio))
        return CalcRatio((Ratio)(double)objs[0], (Ratio)objs[1], oper);

    return Calc((double)objs[0], (double)objs[1], oper);
}

string CalcComplex(Complex left, Complex right, string oper) => oper switch
{
    "+" => (left + right).ToString(),
    "-" => (left - right).ToString(),
    "*" => (left * right).ToString(),
    "/" => right.R == 0 && right.I == 0 ? "Деление на 0 не возможно!" : (left / right).ToString(),
    "==" => (left == right).ToString(),
    "!=" => (left != right).ToString(),
    _ => $"Операция {oper} не возможна с типом Complex"
};

string CalcRatio(Ratio left, Ratio right, string oper) => oper switch
{
    "+" => (left + right).ToString(),
    "-" => (left - right).ToString(),
    "*" => (left * right).ToString(),
    "/" => right.P == 0 ? "Деление на 0 не возможно!" : (left / right).ToString(),
    "%" => right.P == 0 ? "Деление на 0 не возможно!" : (left % right).ToString(),
    "==" => (left == right).ToString(),
    "!=" => (left != right).ToString(),
    ">" => (left > right).ToString(),
    "<" => (left < right).ToString(),
    ">=" => (left >= right).ToString(),
    "<=" => (left <= right).ToString(),
    _ => $"Операция {oper} не возможна с типом Ratio"
};

string Calc(double left, double right, string oper) => oper switch
{
    "+" => (left + right).ToString(),
    "-" => (left - right).ToString(),
    "*" => (left * right).ToString(),
    "/" => right == 0 ? "Деление на 0 не возможно!" : (left / right).ToString(),
    "%" => right == 0 ? "Деление на 0 не возможно!" : (left % right).ToString(),
    "==" => (left == right).ToString(),
    "!=" => (left != right).ToString(),
    ">" => (left > right).ToString(),
    "<" => (left < right).ToString(),
    ">=" => (left >= right).ToString(),
    "<=" => (left <= right).ToString(),
    _ => $"Операция {oper} не возможна с типом double"
};



