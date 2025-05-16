 
namespace MyApp
{
    public class Jatek
    {
        public static void jatek()
        {
            if (!sorkerdes()) { return; }
            
        }

        static bool sorkerdes()
        {
            Random random = new Random();

            List<Sorkerdes> SorKerdesek = Kerdesek.sorkerdesBeolvasas();
            Sorkerdes kerdes = SorKerdesek[random.Next(SorKerdesek.Count)];

            Console.Write(kerdes.KerdesSzoveg +"\na.) "+ kerdes.Valaszok[0] +"\nb.) "+ kerdes.Valaszok[1] +"\nc.) "+ kerdes.Valaszok[2] +"\nd.) "+ kerdes.Valaszok[3] +"\nSorrendbe tett válaszod ("+kerdes.HelyesValaszKod+"): ");
            string ans = Console.ReadLine();

            System.Console.WriteLine(kerdes.HelyesValaszKod.ToLower() == ans.ToLower());
            return kerdes.HelyesValaszKod.ToLower() == ans.ToLower();
        }
    }
}