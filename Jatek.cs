
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace MyApp
{
    public class Jatek
    {
        static Random random = new Random();
        static List<Kerdes> osszesKerdes = Kerdesek.kerdesBeolvasas();
        static List<Sorkerdes> SorKerdesek = Kerdesek.sorkerdesBeolvasas();
        static List<(int,string)> segitsegek = [(1,"Felező"),(2,"Közönség"),(3,"Telefon")];
        public static void jatek()
        {
            if (!sorkerdes()) {
                System.Console.WriteLine("Sajnos nem jutottál be a játékba.");
                return;
            }
            int guarantee = 0;
            for (int i = 1; i <=15; i++) {
                switch (i) {
                    case 5+1:
                        guarantee = 100_000;
                        break;
                    case 10+1:
                        guarantee = 100_000;
                        break;
                }

                Console.Clear();
                System.Console.Write("Ha most elsétálsz "+ PriceIndex(i-1) +" Ft-ot kaphatsz.\nAbba akarod hagyni (y/n)? ");
                string ans = Console.ReadLine();
                Console.Clear();
                string[] leave = ["y","i","yes","igen"];
                if (leave.Contains(ans.ToLower())) { // ha nemet mond, akkor csak megyünk tovább, és ha bármi mást akkor gondolom tovább akar menni
                        guarantee = PriceIndex(i-1);
                        break;
                }

                System.Console.WriteLine("Eddigi garantált nyereményed: " + guarantee + " Ft");
                System.Console.WriteLine("Ez a kérdés "+ PriceIndex(i) +" Ft-ot ér.\n");
                if (!kerdes(i)) { break; }
            }

            System.Console.WriteLine("A játék véget ért. " + guarantee + " Ft-ot nyertél.");
        }

        static int PriceIndex(int i) {
            return i switch
            {
                0 => 0,
                1 => 5_000,
                2 => 10_000,
                3 => 20_000,
                4 => 50_000,
                5 => 100_000,
                6 => 200_000,
                7 => 300_000,
                8 => 500_000,
                9 => 800_000,
                10 => 1_000_000,
                11 => 2_000_000,
                12 => 5_000_000,
                13 => 10_000_000,
                14 => 20_000_000,
                15 => 40_000_000,
                _ => -1, //kell a debuggernek 
            };
        }

        static bool kerdes(int i) {
            List<Kerdes> kerdesek = [];
            foreach (var Kerdes in osszesKerdes)
            {
                if (Kerdes.Szint == i) {
                    kerdesek.Add(Kerdes);
                }
            }
            Kerdes kerdes = kerdesek[random.Next(kerdesek.Count)];

            Console.WriteLine(kerdes.KerdesSzoveg +"\nA.) "+ kerdes.Valaszok[0] +"\nB.) "+ kerdes.Valaszok[1] +"\nC.) "+ kerdes.Valaszok[2] +"\nD.) "+ kerdes.Valaszok[3]);
            if (segitsegek.Count != 0) {
                System.Console.WriteLine("S.) Segítség");
            }
            System.Console.Write("Válaszod: ");
            //Console.Write(kerdes.HelyesValaszKod); //TODO
            string ans = Console.ReadLine();

            if ("s" == ans.ToLower() && segitsegek.Count != 0) {
                int segitseg = Segitseg();
                int helyes = kerdes.HelyesValaszKod switch {
                    'A' => 0,
                    'B' => 1,
                    'C' => 2,
                    'D' => 3,
                    _ => -1 //soha nem fog megtörténni
                };

                Console.Clear();
                System.Console.WriteLine(kerdes.KerdesSzoveg);
                switch (segitseg) {
                    case 1://Felező
                        
                        int helytelen = helyes;
                        while (helytelen == helyes) {
                            helytelen = random.Next(4);
                        }
                        if (helyes < helytelen) {
                            Console.WriteLine("A.) "+kerdes.Valaszok[helyes]+ "\nB.) "+ kerdes.Valaszok[helytelen]);
                            kerdes.HelyesValaszKod = 'A';
                        }else {
                            Console.WriteLine("A.) "+kerdes.Valaszok[helytelen]+ "\nB.) "+ kerdes.Valaszok[helyes]);
                            kerdes.HelyesValaszKod = 'B';
                        }

                        break;
                    case 2: //Közönség

                        int[] per = [0,0,0,0];
                        for (int t = 0; t< 100; t++) {
                            int roll = random.Next(6);
                            if (roll >= 4) {
                                per[helyes]++;
                            }else{
                                per[roll]++;
                            }
                        }

                        Console.WriteLine("A.) "+ kerdes.Valaszok[0] +" " +per[0]+ "%\nB.) "+ kerdes.Valaszok[1] +" " +per[1]+ "%\nC.) "+ kerdes.Valaszok[2] +" " +per[2]+ "%\nD.) "+ kerdes.Valaszok[3] +" " +per[3]+ "%");

                        break;
                    case 3: //Telefon, de nagyon okos a barátod
                        
                        kerdes.Valaszok[helyes] += " <- Ez a helyes szerinte";
                        Console.Write("A.) "+ kerdes.Valaszok[0] +"\nB.) "+ kerdes.Valaszok[1] +"\nC.) "+ kerdes.Valaszok[2] +"\nD.) "+ kerdes.Valaszok[3] +"\nS.) Segítség\nVálaszod: ");
            
                        break;
                    default: // soha nem fog megtörténni
                        break;
                }
                Console.Write("Válaszod: ");
                //Console.Write(kerdes.HelyesValaszKod); //TODO
                ans = Console.ReadLine();
            }

            //System.Console.WriteLine(kerdes.HelyesValaszKod.ToLower() == ans.ToLower());
            bool ret = kerdes.HelyesValaszKod.ToString().ToLower().ToCharArray()[0] == ans.ToLower().ToCharArray()[0];
            if (!ret) {
                Console.WriteLine("A helyes válasz " +kerdes.HelyesValaszKod+ " volt.");
            }
            return ret;
        }

        static int Segitseg() {
            System.Console.WriteLine("Melyik segítséget akarod felhasználni?");

            for (int i = 0; i < segitsegek.Count; i++) {
                Console.WriteLine(i+1+".) "+ segitsegek[i].Item2);
            }
            Console.Write("Választásod: ");
            string ans = Console.ReadLine();
            int j = Int32.Parse(ans)-1;

            int ret = segitsegek[j].Item1;
            segitsegek.RemoveAt(j);
            return ret;
        }

        static bool sorkerdes()
        {
            Sorkerdes kerdes = SorKerdesek[random.Next(SorKerdesek.Count)];

            Console.Write(kerdes.KerdesSzoveg +"\nA.) "+ kerdes.Valaszok[0] +"\nB.) "+ kerdes.Valaszok[1] +"\nC.) "+ kerdes.Valaszok[2] +"\nD.) "+ kerdes.Valaszok[3] +"\nSorrendbe tett válaszod: ");
            //Console.Write(kerdes.HelyesValaszKod); //TODO
            string ans = Console.ReadLine();

            //System.Console.WriteLine(kerdes.HelyesValaszKod.ToLower() == ans.ToLower());
            bool ret = kerdes.HelyesValaszKod.ToLower() == ans.ToLower();
            if (!ret) {
                Console.WriteLine("A helyes válasz " +kerdes.HelyesValaszKod+ " volt.");
            }
            return ret;
        }
    }
}