using System;

using System.Text.Json;
using System.Text.Json.Serialization;
namespace Demo_JSON_SerializationOptions
{
    public class Employee{     
        [JsonPropertyName("FullName")]
        public string Name { get; set; }       
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public decimal Salary1 { get; init; }

        public decimal Salary2 { get;  }

    }//end Employee
    class Program{
        static void Main(string[] args){
            string json = @"{ 
                ""FullName"":""Mark"", // FullName     
                ""Email"":""Mark@gmail.com"", // Email    
                 ""Salary"":1000, // Salary    
            }";
            var option = new JsonSerializerOptions(){
                WriteIndented = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true  
            };
            var emp = JsonSerializer.Deserialize<Employee>(json, option);
            Console.WriteLine($"Name:{emp.Name}, Email:{emp.Email}," +
                $" Salary:{emp.Salary}");
            Console.ReadLine();
        }
    }//end Program
}
