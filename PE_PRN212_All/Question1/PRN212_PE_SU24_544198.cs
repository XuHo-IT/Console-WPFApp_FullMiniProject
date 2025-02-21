using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class PRN212_PE_SU24_544198
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Dob { get; set; }
            public string Major { get; set; }

            public Student(int id, string name, DateTime dob, string major)
            {
                Id = id;
                Name = name;
                Dob = dob;
                Major = major;
            }

            public override string ToString()
            {
                return $"{Id} - {Name} - {Dob.ToLongDateString()} - {Major}";
            }

            public override bool Equals(object obj)
            {
                if (obj is Student student)
                {
                    return Id == student.Id;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
        }
        public class Group<T> where T : Student
        {
            public string GroupName { get; set; }
            private List<T> students;

            public Group(string groupName)
            {
                GroupName = groupName;
                students = new List<T>();
            }

            public void Add(T student)
            {
                students.Add(student);
            }

            public void Remove(T student)
            {
                students.Remove(student);
            }

            public void Show(Action<T> displayMethod)
            {
                foreach (var student in students)
                {
                    displayMethod(student);
                }
            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Requirement 1:");
            Student s = new Student(1, "Nguyen Van A", new DateTime(1999, 10, 20), "SE");
            Console.WriteLine("You have entered:");
            Console.WriteLine(s);

            Console.WriteLine(Environment.NewLine + "---------------");
            Console.WriteLine("Requirement 2:");
            Group<Student> group = new Group<Student>("SE1824");

            group.Add(new Student(2, "Nguyen Van B", new DateTime(1999, 10, 20), "SE"));
            group.Add(new Student(3, "Nguyen Van C", new DateTime(1989, 11, 15), "IA"));
            group.Add(new Student(4, "Nguyen Van D", new DateTime(2000, 4, 2), "GD"));
            Console.WriteLine($"Group SE1824 has 3 student, List of students");
            group.Show(DisplaysFullInfoOfStudent);

            Console.WriteLine(Environment.NewLine + "---------------");
            Console.WriteLine("Requirement 3:");
            Student removeStudent = new Student(3, "Nguyen Van C", new DateTime(1989, 11, 15), "IA");
            group.Remove(removeStudent);
            Console.WriteLine($"Group SE1824 has 2 student, List of students");
            group.Show(DisplaysFullInfoOfStudent);

            Console.WriteLine(Environment.NewLine + "---------------");
            Console.WriteLine("Requirement 4:");
            Console.WriteLine($"Group SE1824 has 2 student, List of students");
            group.Show(DisplaysBriefInfoOfStudent);
        }

        private static void DisplaysFullInfoOfStudent(Student student)
        {
            Console.WriteLine($"{student.Id} - {student.Name} - {student.Dob.ToLongDateString()} - {student.Major}");
        }

        private static void DisplaysBriefInfoOfStudent(Student student)
        {
            Console.WriteLine($"{student.Id} - {student.Name}");
        }
    }
}
