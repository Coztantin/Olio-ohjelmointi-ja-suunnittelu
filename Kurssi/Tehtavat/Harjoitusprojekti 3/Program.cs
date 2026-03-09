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

            Console.WriteLine("Events before sorting:");
            PrintAll(events);

            // TODO: Järjestä tapahtumat (Sort)
            events.Sort();

            Console.WriteLine("\nEvents after sorting:");
            PrintAll(events);

            Console.WriteLine("\nOnly lectures:");
            PrintByType(events, EventType.Lecture);

            Console.WriteLine("\nCancelling EVT-2026-002:");
            CancelEventById(events, "EVT-2026-002");

            Console.WriteLine("\nEvents after cancellation:");
            PrintAll(events);
        }

        // ---------- METODIT ----------

        static bool IsValidEventId(string id)
        {
            // EVT-YYYY-NNN
            string pattern = @"^EVT-[0-9]{4}-[0-9]{3}$";
            return Regex.IsMatch(id, pattern);
        }

        static void PrintAll(List<Event> events)
        {
            foreach (Event ev in events)
            {
                Console.WriteLine(ev);
            }
        }

        static void PrintByType(List<Event> events, EventType type)
        {
            foreach (Event ev in events)
            {
                if (ev.Type == type)
                {
                    Console.WriteLine(ev);
                }
            }
        }

        static void PrintByStatus(List<Event> events, EventStatus status)
        {
            foreach (Event ev in events)
            {
                if (ev.Status == status)
                {
                    Console.WriteLine(ev);
                }
            }
        }

        static void CancelEventById(List<Event> events, string id)
        {
            if (!IsValidEventId(id))
            {
                Console.WriteLine("Invalid ID format");
                return;
            }

            bool found = false;

            foreach (Event ev in events)
            {
                if (ev.Id == id)
                {
                    ev.Status = EventStatus.Cancelled;
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Event not found");
            }
        }
    }
}
