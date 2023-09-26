using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Demo_JsonSerializationBehavior
{
    public class Employee {
        public Employee(){ }
        public Employee(decimal initialSalary) {
             Salary = initialSalary;
        }
        [JsonPropertyName("FullName")]
        public string Name { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonInclude]
        public decimal Salary;
    }//end Employee
    //-----------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            var emp1 = new Employee(100.5M);
            emp1.Name = "Jack";
            emp1.Email = "jack@gmail.com";
            var option = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine("****Serialize*****");
            string jsonData = JsonSerializer.Serialize(emp1, option);
            Console.WriteLine(jsonData);
            Console.WriteLine("****Deserialize*****");
            var emp2 = JsonSerializer.Deserialize<Employee>(jsonData);
            Console.WriteLine($"Name:{emp2.Name}, Salary:{emp2.Salary}");
            Console.ReadLine();
        }
    }
}
