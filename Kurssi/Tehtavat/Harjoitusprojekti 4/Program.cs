namespace Harjoitusprojekti4
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Luo historia ja lataa tiedosto
            // GameHistory history = new GameHistory("history.txt");
            // history.Load();

            // TODO: Kysy pelaajan nimi ja luo Player try/catchilla
            // try { ... } catch (ArgumentException e) { ... }

            // TODO: Luo pelaajan rivi ja voittorivi
            // LotteryRow myRow = new LotteryRow();
            // LotteryRow winningRow = new LotteryRow();

            // TODO: Laske osumat
            // int hits = CountHits(myRow, winningRow);

            // TODO: Lisää tulos historiaan ja tallenna
            // history.AddLine(...);
            // history.Save();

            // TODO: Tulosta lopuksi historia
            // history.Print();
        }

        // Apumetodi osumien laskuun (ei LINQiä)
        static int CountHits(LotteryRow myRow, LotteryRow winningRow)
        {
            int hits = 0;

            foreach (int number in myRow.Numbers())
            {
                if (winningRow.ContainsNumber(number))
                {
                    hits++;
                }
            }

            return hits;
        }
    }
}
