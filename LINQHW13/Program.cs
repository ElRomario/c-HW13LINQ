using System;
using System.Collections.Generic;
using System.Linq;
/*C# 13 (25 октября 2023)
LINQ to Objects
Срок: к следующему занятию, понедельнику 30 октября

У студента есть имя, фамилия, город, группа и оценка. С помощью запросов LINQ:

1. Распечатайте информацию обо всех студентах.

2. Распечатайте информацию о студентах из определённого города. Отсортируйте по фамилии, во вторую очередь по имени.

3. Распечатайте только имена студентов, отсортированные по алфавиту.

4. Распечатайте топ-3 студентов по успеваемости.

5. Посчитайте всеобщий средний балл.

6. Распечатайте средний балл студентов в каждом городе. Используйте GroupBy.

7. Составьте словарь, где ключ — имя студента, а значение — объект класса студент.

8. Проверьте, верно ли, что у всех студентов оценка 7 и больше.
*/
namespace LINQHW13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
               new ("Zetgey", "Viktorovich", "Moscow", "BPE113", 10),
               new ("Berasim", "Petrovich", "Petrozavodsk", "BIPA228", 6),
               new ("Hella", "Fella", "Petrozavodsk", "BPE113", 9),
               new ("Viktor", "Viktorovich", "Moscow", "BPE113", 7),
               new ("Aetgey", "Viktorovich", "Moscow", "BPE113", 3)
            };

            Console.WriteLine("--ALL STUDENTS INFO--");

            foreach(Student stud in students)
            {
                Console.WriteLine(stud);
            }
            IEnumerable<Student> newEnum =  students
                                     .Where(s => s.City == "Moscow")
                                     .OrderBy(s => s.SurName)
                                     .ThenBy(s => s.Name);

            Console.WriteLine("--STUDENTS FROM MOSCOW--");
            foreach(Student stud in newEnum)
            {
                Console.WriteLine(stud);
            }

            newEnum = students
                      .OrderBy(s => s.Name);

            Console.WriteLine("--ORDERED BY NAME--");
            foreach(Student stud in newEnum)
            {
                Console.WriteLine(stud);
            }
            newEnum = students
                      .OrderByDescending(s => s.Grade)
                      .Take(3);
            Console.WriteLine("--TOP 3--");

            foreach (Student stud in newEnum)
            {
                Console.WriteLine(stud);
            }

            double averageGrade = students
                      .Average(s => s.Grade);

            Console.WriteLine($"AVERAGE GRAD: {averageGrade}");

        // var используется, потому что возвращаемый Селектом тип может быть определён компилятором 
        //VVVV   
          var averageGradeByCity = students
                                                .GroupBy(s => s.City)
                                                .Select(g => new
                                                {
                                                    City = g.Key,
                                                    averageGradeByCity = g.Average(s => s.Grade)
                                                }      );

            Console.WriteLine("--AVERAGE GRADE BY CITY--");
            foreach (var student in averageGradeByCity)
            {
                Console.WriteLine($"City {student.City}, Average grade: {student.averageGradeByCity}");
            }

            Dictionary<string, Student> studentDict = students.ToDictionary(student => student.Name, student => student);

            Console.WriteLine("--STUDENT DICTIONARY--");
            foreach(var element in studentDict)
            {
                Console.WriteLine($"  Key: {element.Key},\n  Value: {element.Value}");
            }

            bool allStudentsPassed = students.All(student => student.Grade >= 7);

            string output = allStudentsPassed == true ? "All students have passed" : "Not all students have passed";

            Console.WriteLine(output);
            

            






            
            
        }
    }
}
