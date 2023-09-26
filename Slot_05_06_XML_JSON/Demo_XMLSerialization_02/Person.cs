using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 //...
 using System.Xml.Serialization;
 namespace Demo_XMLSerialization_02 {
    public class Person{
        public Person() { }
        public Person(decimal initialSalary) => Salary = initialSalary;      
        public string FirstName { get; set; }       
        public string LastName { get; set; }       
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        //Salary property is not included
        protected decimal Salary { get; set; }
    }
 }
