using IntoOOP.Text;
using IntoOOP.Text.Tests;

var test = new ReverseTest();
test.DoProcess();

while (true)
{
    Console.Write("Введите строку для разворота: ");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) return;
    var result = TextHandler.Reverse(input);
    Console.WriteLine($"Результат: {result}\n");
}