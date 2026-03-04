using System;
using System.Collections.Generic;

    class Student
    {
        public string Name;
        public int Age;
        public string DegreeProgram;

        public Student(string name, int age, string degreeProgram)
        {
            Name = name;
            Age = age;
            DegreeProgram = degreeProgram;
        }

        public override string ToString()
        {
            return Name + ", " + Age + " years, Program: " + DegreeProgram;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            // TODO: Add initial students here

            PrintAllStudents(students);

            // TODO: Test methods here
        }

        static void AddStudent(List<Student> students, Student student)
        {
            // TODO
        }

        static void FindStudentByName(List<Student> students, string name)
        {
            // TODO
        }

        static void PrintStudentsOlderThan(List<Student> students, int age)
        {
            // TODO
        }

        static void PrintStudentsByProgram(List<Student> students, string program)
        {
            // TODO
        }

        static void PrintAllStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

