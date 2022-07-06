using IntoOOP.Text;

Console.Write("Укажите путь к файлу с именами и эмейл адресами: ");
var source = Console.ReadLine();
Console.Write("Укажите путь к файлу для записи эмейл адресов: ");
var dest = Console.ReadLine();
Console.WriteLine();

try
{
    TextHandler.WriteAllEmails(source, dest);
    Console.WriteLine("Файл успешно записан.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey(true);