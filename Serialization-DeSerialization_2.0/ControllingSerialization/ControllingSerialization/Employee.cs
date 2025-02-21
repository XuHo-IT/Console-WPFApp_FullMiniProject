using System.Text.Json;
using System.Text.Json.Serialization;

public class Employee
{
    public Employee() { }
    public Employee(decimal initialSalary)
    {
        Salary = initialSalary;
    }
    [JsonPropertyName("FullName")]
    public string Name { get; set; }
    [JsonIgnore]
    public string Email { get; set; }
    [JsonInclude]
    public decimal Salary;
}