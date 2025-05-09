namespace MyApp
{
    public class Kerdesek
    {
       static void Beolvasas() {
            foreach (var line in File.ReadLines("kerdes.txt"))
            {
                foreach (var item in line.Split(';'))
                {
                    System.Console.WriteLine(item);
                }
            }
       }
    }
}