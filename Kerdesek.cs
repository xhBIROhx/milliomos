namespace MyApp
{
    public class Kerdesek
    {
        public static List<Kerdes> sorkerdesBeolvasas() {
            List<Kerdes> ret = [];
            
            foreach (var line in File.ReadLines("sorkerdes.txt"))
            {
                string[] parts = line.Split(';');
                Kerdes kerdes = new Kerdes(
                    parts[0],
                    [
                        parts[1],
                        parts[2],
                        parts[3],
                        parts[4],
                    ],
                    parts[5],
                    parts[6]
                );
                ret.Add(kerdes);
            }

            return ret;
        }
        static void kerdesBeolvasas()
        {
            
        }
    }
}