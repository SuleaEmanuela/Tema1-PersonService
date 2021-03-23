using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonService.DataAcces
{
    public class PersonsOperations
    {
        private readonly string filePath = "./Resources/people.txt";

        public bool AddPerson(Person person)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(person.Name);
                sw.WriteLine(person.Gender);
                sw.WriteLine(person.Age);
                sw.WriteLine(person.ID);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return true;

        }
        public List<Person> GetPeople()
        {
            var people = new List<Person>();
            string line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(' ');
                    people.Add(new Person() { Name = words[0], Gender = words[1], Age = Int32.Parse(words[2]),ID=words[3] });
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return people;
        }
    }
}
