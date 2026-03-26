namespace Harjoitusprojekti4
{
    using System;
    class Player
    {
        public string Name { get; }
        public LotteryRow MyRow { get; }

        public Player(string name, LotteryRow myRow)
        {
            // TODO: Validointi + ArgumentException
            // - name ei saa olla null/tyhjä
            // - name max 40 merkkiä
            // - myRow ei saa olla null

            if (name == null || name.Trim() == "")
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            if (name.Length > 40)
            {
                throw new ArgumentException("Name is too long (max 40).");
            }

            if (myRow == null)
            {
                throw new ArgumentException("LotteryRow cannot be null.");
            }

            Name = name;
            MyRow = myRow;
        }

        public override string ToString()
        {
            return Name + " | Row: " + MyRow.ToString();
        }
    }
}
