using System.Dynamic;

namespace MyApp
{
    public class Kerdes
    {
        private int szint;
        private string kerdesSzoveg;
        private string[] valaszok = new string[4];
        private char helyesValaszKod;
        private string kategoria;

        public Kerdes(int szint, string kerdesSzoveg, string[] valaszok, char helyesValaszKod, string kategoria)
        {
            this.szint = szint;
            this.kerdesSzoveg = kerdesSzoveg;
            this.valaszok = valaszok;
            this.helyesValaszKod = helyesValaszKod;
            this.kategoria = kategoria;
        }

        public int Szint { get => szint; set => szint = value; }
        public string KerdesSzoveg { get => kerdesSzoveg; set => kerdesSzoveg = value; }
        public string[] Valaszok { get => valaszok; set => valaszok = value; }
        public char HelyesValaszKod { get => helyesValaszKod; set => helyesValaszKod = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
    }
}