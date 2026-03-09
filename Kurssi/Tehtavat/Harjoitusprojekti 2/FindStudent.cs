public abstract class FindStudent
{
    public void FindStudent(List<Student> students, object operation)
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
}