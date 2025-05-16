 
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
            List<Kerdes> SorKerdesek = Kerdesek.sorkerdesBeolvasas();
            return true;
        }
    }
}