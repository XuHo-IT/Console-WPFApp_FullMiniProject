using System.Text.Json;
using System.Text.Json.Serialization;

public class Employee
{
    [JsonPropertyName("FullName")]
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}