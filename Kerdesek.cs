namespace MyApp
{
    public class Kerdesek
    {
        public static List<Sorkerdes> sorkerdesBeolvasas() {
            List<Sorkerdes> ret = [];

            foreach (var line in File.ReadLines("sorkerdes.txt"))
            {
                string[] parts = line.Split(';');
                Sorkerdes kerdes = new Sorkerdes(
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
        public static List<Kerdes> kerdesBeolvasas()
        {
            List<Kerdes> ret = [];

            foreach (var line in File.ReadLines("kerdes.txt"))
            {
                string[] parts = line.Split(';');
                Kerdes kerdes = new Kerdes(
                    int.Parse(parts[0]),
                    parts[1],
                    [
                        parts[2],
                        parts[3],
                        parts[4],
                        parts[5],
                    ],
                    parts[6].ToCharArray()[0],
                    parts[7]
                );
                ret.Add(kerdes);
            }

            return ret;
        }
    }
}