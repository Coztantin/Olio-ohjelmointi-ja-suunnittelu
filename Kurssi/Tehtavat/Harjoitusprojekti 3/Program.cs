using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Harjoitusprojekti3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Event> events = new List<Event>();

            // TODO: Lisää tapahtumia listaan (käytä IsValidEventId ennen lisäystä)
            events.Add(new Event("EVT-2026-003", "Math Exam",
                new DateTime(2026, 5, 20, 9, 0, 0),
                120,
                EventType.Exam,
                EventStatus.Planned));

            events.Add(new Event("EVT-2026-001", "C# Lecture",
                new DateTime(2026, 4, 10, 10, 0, 0),
                90,
                EventType.Lecture,
                EventStatus.Confirmed));

            events.Add(new Event("EVT-2026-002", "Workshop: Git",
                new DateTime(2026, 4, 10, 9, 0, 0),
                180,
                EventType.Workshop,
                EventStatus.Planned));

            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-004",
                "Understanding Time",
                new DateTime(2026, 4, 11, 12, 0, 0),
                90,
                EventType.Lecture,
                EventStatus.Confirmed)
                );

            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2025-1",
                "Test Not Working",
                new DateTime(2026, 11, 11, 11, 0, 0),
                110,
                EventType.Meeting,
                EventStatus.Confirmed)
                );

            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-005",
                "Writing Exam",
                new DateTime(2026, 4, 11, 13, 0, 0),
                120,
                EventType.Exam,
                EventStatus.Confirmed)
                );

            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-006",
                "Lunch with Mayor",
                new DateTime(2026, 4, 12, 11, 30, 0),
                60,
                EventType.Meeting,
                EventStatus.Confirmed)
                );

            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-007",
                "Police Hearing",
                new DateTime(2026, 4, 12, 14, 0, 0),
                120,
                EventType.Meeting,
                EventStatus.Confirmed)
                );
            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-008",
                "World Domination",
                new DateTime(2026, 4, 13, 15, 45, 29),
                180,
                EventType.Workshop,
                EventStatus.Planned)
                );
            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-009",
                "Social Chemistry",
                new DateTime(2026, 3, 21, 10, 00, 00),
                90,
                EventType.Lecture,
                EventStatus.Planned)
                );
            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-010",
                "Start GYM",
                new DateTime(2026, 4, 1, 8, 00, 00),
                120,
                EventType.Workshop,
                EventStatus.Planned)
                );
            AddEvent(events, new Event(                   //Testilisäys, jotta voidaan nähdä toimiiko tämä...
                "EVT-2026-011",
                "Get Friends",
                new DateTime(2026, 4, 1, 8, 00, 00),
                120,
                EventType.Meeting,
                EventStatus.Planned)
                );

            Console.WriteLine("Events before sorting:");

            PrintAll(events);

            // TODO: Järjestä tapahtumat (Sort) - DONE
            // Lisätty lisää tapahtumia ja todettu, toimii. esim Kaksi viimeistä eventtiä...
            events.Sort();

            Console.WriteLine("\nEvents after sorting:");
            PrintAll(events);

            Console.WriteLine("\nOnly lectures:");
            PrintByType(events, EventType.Lecture);

            Console.WriteLine("\nOnly workshops:");
            PrintByType(events, EventType.Workshop);

            Console.WriteLine("\nOnly exams:");
            PrintByType(events, EventType.Exam);

            Console.WriteLine("\nOnly meetings:");
            PrintByType(events, EventType.Meeting);

            Console.WriteLine("\nOnly planned events:");
            PrintByStatus(events, EventStatus.Planned);

            Console.WriteLine("\nOnly confirmed events:");
            PrintByStatus(events, EventStatus.Confirmed);

            Console.WriteLine("\nOnly cancelled events:");
            PrintByStatus(events, EventStatus.Cancelled);

            Console.WriteLine("\nCancelling EVT-2026-002:");
            CancelEventById(events, "EVT-2026-002");

            Console.WriteLine("\nCancelling EVT-2026-010:");
            CancelEventById(events, "EVT-2026-010");

            Console.WriteLine("\nEvents after cancellation:");
            PrintAll(events);
        }

        // ---------- METODIT ----------

        // Metodi, joka tarkistaa ennen lisäystä onko Id formaatti sopiva.
        public static void AddEvent(List<Event> events, Event lisattava)
        {
            if (IsValidEventId(lisattava.Id))
            {
                events.Add(lisattava);
                Console.WriteLine($"{lisattava.Id} added to calendar.");
            }
            else
            {
                Console.WriteLine("Wrong Id format. Please use EVT-YYYY-NNN format for Id.");
            }

        }

        static bool IsValidEventId(string id)  //Tarkistaa onko Id kunnossa...
        {
            // EVT-YYYY-NNN
            string pattern = @"^EVT-[0-9]{4}-[0-9]{3}$";
            return Regex.IsMatch(id, pattern);
        }

        // Tulostaa kaikki tapahtumat. Lisätty otsikointi
        static void PrintAll(List<Event> events)
        {
            Event.Headers();    //Otsikointi
            foreach (Event ev in events)                            // Jokaista tapahtumaa kohti listassa käydään läpi ja
            {                                                       // Tarkistetaan status. Statuksille on annettu oma väri
                Console.ResetColor();  // palautetaan väri          // luettavuuden parantamiseksi.
                if (ev.Status == EventStatus.Planned)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;    // vaihdetaan tulostuksen väri
                    Console.WriteLine(ev);

                }
                if (ev.Status == EventStatus.Confirmed)
                {
                    Console.WriteLine(ev);
                }
                if (ev.Status == EventStatus.Cancelled)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // vaihdetaan tulostuksen väri
                    Console.WriteLine(ev);
                }
                Console.ResetColor();                               // palautetaan väri 
            }
        }
        //Tulostaa kaikki tapahtumat, mitkä on merkattu tiettyyn tyyppiin.
        static void PrintByType(List<Event> events, EventType type)
        {
            Event.Headers();
            foreach (Event ev in events)
            {
                if (ev.Type == type)
                {
                    Console.WriteLine(ev);
                }
            }
        }
        //Tulostaa kaikki tapahtumat, joiden status on tietty.
        static void PrintByStatus(List<Event> events, EventStatus status)
        {
            Event.Headers();
            int count = 0;
            foreach (Event ev in events)
            {
                if (ev.Status == status)
                {
                    Console.WriteLine(ev);
                    count += 1;
                }

            }
            if (count == 0)
            {
                Console.WriteLine($"No {status} events...");
            }
        }

        static void CancelEventById(List<Event> events, string id)
        {
            if (!IsValidEventId(id))
            {
                Console.WriteLine("Invalid ID format");
                return;
            }

            bool found = false;   //jotta voidaan todeta, ettei ole löytynyt

            foreach (Event ev in events)
            {
                if (ev.Id == id)
                {
                    ev.Status = EventStatus.Cancelled;      //Muutetaan status toiseen
                    found = true;                           //perutetaan "ei löytynyt" tuloste
                }
            }

            if (!found)
            {
                Console.WriteLine("Event not found");
            }


        }
    }
}
