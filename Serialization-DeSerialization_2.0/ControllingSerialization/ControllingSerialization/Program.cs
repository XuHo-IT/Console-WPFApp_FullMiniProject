using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        var emp1 = new Employee(1000M) { Name = "Jack", Email = "jack@gmail.com" };
        var options = new JsonSerializerOptions { WriteIndented = true };
        Console.WriteLine("**** Serialize ****");
        string jsonData = JsonSerializer.Serialize(emp1, options);
        Console.WriteLine(jsonData);
        Console.WriteLine("**** Deserialize ****");
        var emp2 = JsonSerializer.Deserialize<Employee>(jsonData);
        Console.WriteLine($"Name: {emp2.Name}, Salary: {emp2.Salary}");
        Console.ReadLine();
    }
}