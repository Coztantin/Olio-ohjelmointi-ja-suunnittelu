using System;

namespace Harjoitusprojekti3
{
    class Event : IComparable<Event>
    {
        public string Id;
        public string Title;
        public DateTime Start;
        public int DurationMinutes;
        public EventType Type;
        public EventStatus Status;

        public Event(string id, string title, DateTime start,
                     int durationMinutes, EventType type, EventStatus status)
        {
            Id = id;
            Title = title;
            Start = start;
            DurationMinutes = durationMinutes;
            Type = type;
            Status = status;
        }

        public int CompareTo(Event other)
        {
            // TODO:
            // 1) Järjestä Start-ajan mukaan
            // 2) Jos sama Start, järjestä Title aakkosjärjestykseen

            int timeCompare = this.Start.CompareTo(other.Start);
            if (timeCompare != 0)
            {
                return timeCompare;
            }

            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return Id + " | " + Title +
                   " | " + Start +
                   " | " + DurationMinutes + " min" +
                   " | " + Type +
                   " | " + Status;
        }
    }
}