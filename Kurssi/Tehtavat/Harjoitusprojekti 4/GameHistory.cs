namespace Harjoitusprojekti4
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    class GameHistory
    {
        private string fileName;
        private List<string> lines;

        public GameHistory(string fileName)
        {
            this.fileName = fileName;
            lines = new List<string>();
        }

        public void AddLine(string line)
        {
            lines.Add(line);
        }

        public bool Load()
        {
            // TODO: Lue tiedosto File.ReadAllLines try/catchilla
            // - jos onnistuu: täytä lines ja return true
            // - jos epäonnistuu: tulosta virhe ja return false

            try
            {
                if (File.Exists(fileName))
                {
                    string[] fileLines = File.ReadAllLines(fileName);
                    lines.Clear();

                    foreach (string l in fileLines)
                    {
                        lines.Add(l);
                    }

                    return true;
                }

                // Tiedostoa ei ole -> ei virhe, mutta ei latausta
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Load error: " + e.Message);
                return false;
            }
        }

        public bool Save()
        {
            // TODO: Kirjoita tiedosto StreamWriterilla try/catchilla
            // - return true jos onnistuu, muuten false

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Save error: " + e.Message);
                return false;
            }
        }

        public void Print()
        {
            Console.WriteLine("---- GAME HISTORY ----");

            if (lines.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
