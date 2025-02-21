using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string json = @"
        {
            ""FullName"":""Mark"", // FullName
            ""Email"":""Mark@gmail.com"", // Email
            ""Salary"":1000 // Salary
        }";

        var option = new JsonSerializerOptions()
        {
            WriteIndented = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        var emp = JsonSerializer.Deserialize<Employee>(json, option);
        Console.WriteLine($"Name:{emp.Name}, Email:{emp.Email}, Salary:{emp.Salary}");
        Console.ReadLine();
    }
}