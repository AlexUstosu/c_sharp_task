//using System;
//using System.Collections.Generic;
//using static System.Console;

//namespace SimpleProject
//{
//    public delegate void ExamDelegate(string t);
//    class Student
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime BirthDate { get; set; }
//        public void Exam(string task)
//        {
//            WriteLine($"Student {LastName} solved the { task}");
//        }
//    }
//    class Teacher
//    {
//        public event ExamDelegate examEvent;
//        public void Exam(string task)
//        {
//            if (examEvent != null)
//            {
//                examEvent(task);
//            }
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Student> group = new List<Student> {
//                 new Student {
//                 FirstName = "John",
//                 LastName = "Miller",
//                 BirthDate = new DateTime(1997,3,12)
//                 },
//                 new Student {
//                 FirstName = "Candice",
//                 LastName = "Leman",
//                 BirthDate = new DateTime(1998,7,22)
//                 },
//                 new Student {
//                 FirstName = "Joey",
//                 LastName = "Finch",
//                 BirthDate = new DateTime(1996,11,30)
//                 },
//                 new Student {
//                 FirstName = "Nicole",
//                 LastName = "Taylor",
//                 BirthDate = new DateTime(1996,5,10)
//                 }
//            };
//            Teacher teacher = new Teacher();
//            foreach (Student item in group)
//            {
//                teacher.examEvent += item.Exam;
//            }
//            teacher.Exam("Task");
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using static System.Console;

//namespace SimpleProject
//{
//    class ExamEventArgs : EventArgs
//    {
//        public string Task { get; set; }
//    }
//    class Student
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime BirthDate { get; set; }
//        public void Exam(object sender, ExamEventArgs e)
//        {
//            WriteLine($"Student {LastName} solved the {e.Task}");
//        }
//    }
//    class Teacher
//    {
//        public EventHandler<ExamEventArgs> examEvent;
//        public void Exam(ExamEventArgs task)
//        {
//            if (examEvent != null)
//            {
//                examEvent(this, task);
//            }
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Student student = new Student {
//                 FirstName = "John",
//                 LastName = "Miller",
//                 BirthDate = new DateTime(1997,3,12)

//            };
//            Teacher teacher = new Teacher();


//            teacher.examEvent += student.Exam;

//            ExamEventArgs eventArgs = new ExamEventArgs { Task = "Task" };
//            teacher.examEvent -= student.Exam;

//            teacher.examEvent = student.Exam;

//            teacher.Exam(eventArgs);
//        }
//    }
//}

using SimpleProject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace SimpleProject
{
    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public void Exam(string task)
        {
            WriteLine($"Student {LastName} solved the {task}");
        }
    }
    class Teacher
    {
        SortedList<int, ExamDelegate> _sortedEvents = new SortedList<int, ExamDelegate>();
        Random _rand = new Random();

        public event ExamDelegate examEvent
        {
            add
            {
                for (int key; ;)
                {
                    key = _rand.Next();
                    if (!_sortedEvents.ContainsKey(key))
                    {
                        _sortedEvents.Add(key, value);
                        break;
                    }
                }
            }
            remove
            {
                _sortedEvents.RemoveAt(_sortedEvents.IndexOfValue(value));
            }
        }
        public void Exam(string task)
        {
            foreach (int item in _sortedEvents.Keys)
            {
                if (_sortedEvents[item] != null)
                {
                    _sortedEvents[item](task);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> group = new List<Student> {
                 new Student {
                 FirstName = "John",
                 LastName = "Miller",
                 BirthDate = new DateTime(1997,3,12)
                 },
                 new Student {
                 FirstName = "Candice",
                 LastName = "Leman",
                 BirthDate = new DateTime(1998,7,22)
                 },
                 new Student {
                 FirstName = "Joey",
                 LastName = "Finch",
                 BirthDate = new DateTime(1996,11,30)
                 },
                 new Student {
                 FirstName = "Nicole",
                 LastName = "Taylor",
                 BirthDate = new DateTime(1996,5,10)
                 }
            };
            Teacher teacher = new Teacher();
            foreach (Student item in group)
            {
                teacher.examEvent += item.Exam;
            }
            Student student = new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1998, 10, 12)
            };
            teacher.examEvent += student.Exam;
            teacher.Exam("Task #1");
            WriteLine();
            teacher.examEvent -= student.Exam;
            teacher.Exam("Task #2");
        }
    }
}