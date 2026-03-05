using System;
using System.Collections.Generic;
using System.ComponentModel;

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
    // Lisätään muutama väli sinne sun tänne ja ylimääräisiä tulostuksia, jotta saadaan luettavampi terminaali...
    {   // tehdään opiskelijoista lista
        Console.WriteLine(""); //Luettavuutta

        List<Student> students = new List<Student>();
        // lisätään pohjalle muutama opiskelija
        students.Add(new Student("Anna", 20, "ICT"));
        students.Add(new Student("Mikko", 23, "Business"));
        students.Add(new Student("Liisa", 21, "ICT"));
        students.Add(new Student("Pekka", 25, "Engineering"));
        //Extraa testaukseen
        students.Add(new Student("Emma", 21, "Engineering"));
        students.Add(new Student("James", 19, "Medicine"));
        students.Add(new Student("Sarah", 22, "Law"));
        students.Add(new Student("David", 20, "Computer Science"));
        students.Add(new Student("Lisa", 23, "Psychology"));
        students.Add(new Student("Michael", 21, "Architecture"));
        students.Add(new Student("Jessica", 22, "Economics"));
        students.Add(new Student("Robert", 19, "Philosophy"));
        students.Add(new Student("Amanda", 24, "Physics"));
        students.Add(new Student("Chris", 20, "Chemistry"));
        students.Add(new Student("Rachel", 21, "Biology"));
        students.Add(new Student("Daniel", 23, "History"));
        students.Add(new Student("Lauren", 22, "Mathematics"));
        students.Add(new Student("Kevin", 20, "Art"));

        Console.WriteLine("Made a new list and added first batch of students.");
        Console.WriteLine(new string('-', 50)); //Luettavuutta
        PrintAllStudents(students);

        Console.WriteLine("Performing array of AddStudent() methods...");

        AddStudent(students, new Student("Kimmo", 36, "ICT"));
        AddStudent(students, new Student("Gimmoc", 136, "Necromancy"));
        //extraa testaukseen
        AddStudent(students, new Student("Kimmo", 36, "ICT"));
        AddStudent(students, new Student("Mara", 30, "Chemistry"));
        AddStudent(students, new Student("Make", 39, "Women Studies"));
        AddStudent(students, new Student("Pirjo", 39, "Women Studies"));
        AddStudent(students, new Student("Marjatta", 59, "Women Studies"));
        AddStudent(students, new Student("Väinö", 42, "Engineering"));
        AddStudent(students, new Student("Kimmo", 27, "ICT"));

        Console.WriteLine("AddStudent() methods Finished...");

        PrintAllStudents(students);

        Console.WriteLine("Proceeding to FindStudents methods...");
        Console.WriteLine("Starting array of FindStudentByName() methods...");

        FindStudentByName(students, "Kimmo");
        FindStudentByName(students, "Väinö");
        FindStudentByName(students, "Jarno");

        Console.WriteLine("FindStudents methods finished... Proceeding to array of PrintStudentsOlderThan() methods...");

        PrintStudentsOlderThan(students, 18);
        PrintStudentsOlderThan(students, 28);
        PrintStudentsOlderThan(students, 59);
        PrintStudentsOlderThan(students, 150);

        Console.WriteLine("PrintStudentsOlderThan() methods finished... Proceeding to array of PrintStudentsByProgram() methods...");
        
        PrintStudentsByProgram(students, "ICT");
        PrintStudentsByProgram(students, "Women Studies");
        PrintStudentsByProgram(students, "Elämämkoulu");

        Console.WriteLine("PrintStudentsByProgram() methods finished... End of Harjoitustehtävä 2.");
        // TODO: Test methods here

    

        
    }

    static void AddStudent(List<Student> students, Student student)
    {
        // TODO - DONE
        // lisätään jo tehtyyn listaan uusia opiskelijoita (mihin listaan, opiskelija)
        Console.WriteLine(""); //Luettavuutta
        Console.WriteLine("Adding student: " + student.Name + ", " + student.Age + ", " + student.DegreeProgram); //Ilmoitetaan ketä lisätään
        // tarkistetaan, onko listassa jo samantyyppinen opiskelija (hyvin kevyt tarkistus, ei hashausta)

        if (!students.Any(s => s.Name == student.Name && s.Age == student.Age && s.DegreeProgram == student.DegreeProgram))
        {
            students.Add(student);
            Console.WriteLine(student + " added.");
        }
        else Console.WriteLine(student + " already in student list");
        Console.WriteLine(""); //Luettavuutta
    }

    static void FindStudentByName(List<Student> students, string name)
    {
        // TODO - DONE
        // Etsitään listasta kyseinen opiskelija nimellä.
        Console.WriteLine(""); //Luettavuutta
        int count = 0;
        List<Student> foundStudents = new List<Student>(); //Tehdään uusi lista, johon kerätään kaikki löydetyt opiskelijat, jotta voidaan tulostaa ne myöhemmin
        foreach (Student student in students) //käydää lista läpi ja etsitään onko kyseistä nimeä listassa
        {
            if (student.Name == name)
            {
                count += 1;
                foundStudents.Add(student);
            }

        }
        if (count == 0) Console.WriteLine("No student found with name: " + name);
        if (count >= 1)
        {
            Console.WriteLine("Search completed. Found " + count + "/" + students.Count + " students matching name: " + name); //Ilmoitetaan montako opiskelijaa löytyi ja montako opiskelijaa listassa on yhteensä
            Console.WriteLine("Showing Results:");
            Console.WriteLine("");
            Headers();
            foreach (Student student in foundStudents)
            {
                PrintFormatting(student.Name, student.Age, student.DegreeProgram);
            }
        }
        Console.WriteLine(""); //Luettavuutta
    }

    static void PrintStudentsOlderThan(List<Student> students, int age)
    {
        // TODO - DONE
        // Samanlainen kuin edellinen, mutta etsitään kaikki opiskelijat, jotka ovat vanhempia kuin annettu ikä.
        Console.WriteLine(""); //Luettavuutta
        int count = 0;
        List<Student> foundStudents = new List<Student>(); //Tehdään uusi lista, johon kerätään kaikki löydetyt opiskelijat, jotta voidaan tulostaa ne myöhemmin
        foreach (Student student in students) //käydää lista läpi ja etsitään onko kyseistä nimeä listassa
        {
            if (student.Age > age)
            {
                count += 1;
                foundStudents.Add(student);
            }

        }
        if (count == 0) Console.WriteLine("No student is older than " + age);
        if (count >= 1)
        {
            Console.WriteLine("Search completed. Found " + count + "/" + students.Count + " older than " + age); //Ilmoitetaan montako opiskelijaa löytyi ja montako opiskelijaa listassa on yhteensä
            Console.WriteLine("Showing Results:");
            Console.WriteLine("");
            Headers();
            foreach (Student student in foundStudents)
            {
                PrintFormatting(student.Name, student.Age, student.DegreeProgram);
            }
        }
        Console.WriteLine(""); //Luettavuutta
    }

    static void PrintStudentsByProgram(List<Student> students, string program)
    {
        // TODO
        // Samanlainen kuin kaksi edellistä, mutta etsitään kaikki opiskelijoita, jotka ovat tietyssä ohjelmassa.
        Console.WriteLine(""); //Luettavuutta
        int count = 0;
        List<Student> foundStudents = new List<Student>(); //Tehdään uusi lista, johon kerätään kaikki löydetyt opiskelijat, jotta voidaan tulostaa ne myöhemmin
        foreach (Student student in students) //käydää lista läpi ja etsitään onko kyseistä nimeä listassa
        {
            if (student.DegreeProgram == program)
            {
                count += 1;
                foundStudents.Add(student);
            }

        }
        if (count == 0) Console.WriteLine("No student is enrolled to " + program);
        if (count >= 1)
        {
            Console.WriteLine("Search completed. Found " + count + "/" + students.Count + " enrolled with " + program); //Ilmoitetaan montako opiskelijaa löytyi ja montako opiskelijaa listassa on yhteensä
            Console.WriteLine("Showing Results:");
            Console.WriteLine("");
            Headers();
            foreach (Student student in foundStudents)
            {
                PrintFormatting(student.Name, student.Age, student.DegreeProgram);
            }
        }
        Console.WriteLine(""); //Luettavuutta
    }

    static void PrintAllStudents(List<Student> students)
    {
        //Lisäsin taulukkomuodon... tykkään kauniista riveistä ja sarakkeista... Ilmoitetaan myös, että tulostetaan kaikki opiskelijat
        Headers();

        foreach (Student student in students)
        {
            PrintFormatting(student.Name, student.Age, student.DegreeProgram);
        }
        Console.WriteLine("");
    }
    static void PrintFormatting(string name, int age, string program)
    //Taulukkomuotoilu metodi. suorittaa tulostuksen toivotulla tavalla, jotta taulukko on siisti
    {
        Console.WriteLine("{0,-20} {1,-10} {2,-20}",
            name,
            "| " + age,
            "| " + program);
    }
    static void Headers()
    {
        //Taulukkomuotoilu metodi. suorittaa tulostuksen toivotulla tavalla, jotta taulukko on siisti
        Console.WriteLine(""); //Luettavuutta
        Console.WriteLine("{0,-20} {1,-10} {2,-20}",
            "Name",
            "| " + "Age",
            "| " + "Degree/Program");
        Console.WriteLine(new string('-', 50));
    }
}

