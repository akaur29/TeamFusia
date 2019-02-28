using System;
using System.IO;
using System.Collections.Generic;

class JournalEntry
{
    public JournalEntry(string note, int dist)
    {
        // TO DO: Complete this section 
        villageName = note; distanceTraveled = dist;
        HowFarToGetBack = distanceTraveled;
    }

    public int HowFarToGetBack = 0;
    private string villageName;
    private int distanceTraveled;
    public int getDistanceWalked() { return distanceTraveled; }
    public string getVillageName() { return villageName; }
}

class Hugi
{
    private static JournalEntry je;
    public static bool FoundAstrilde = false;
    public static List<JournalEntry> HugiJournal = new List<JournalEntry>();

    public static int CalculateDistanceWalked()
    {
        int DistanceWalked = 0;
        foreach (var je in HugiJournal)
        {
            Console.WriteLine(" {0}  --   {1} * --- {2} ", je.getDistanceWalked(), je.getVillageName(), je.HowFarToGetBack);
            DistanceWalked += je.getDistanceWalked() + je.HowFarToGetBack;
        }
        return DistanceWalked;
    }
}

class CountrySide
{
    static void Main()
    {
        CountrySide a = new CountrySide();
        a.Run();
        a.Announcement();
    }

    // Create the LinkedList to reflect the Map in the PowerPoint Instructions
    Village Maeland;
    Village Helmholtz;
    Village Alst;
    Village Wessig;
    Village Badden;
    Village Uster;
    Village Schvenig;

    public void TraverseVillages(Village CurrentVillage)
    {
        if (Hugi.FoundAstrilde) return;
        // Here Hugi records his travels, as any Norse Hero will do:

        Hugi.HugiJournal.Add(new JournalEntry(CurrentVillage.VillageName, CurrentVillage.distanceFromPreviousVillage));
        Console.WriteLine("I am travelled to village {0}", CurrentVillage.VillageName);

        try
        {
            if (CurrentVillage.isAstrildgeHere)
            {
                Console.WriteLine("I found Dear Astrildge in {0}", CurrentVillage.VillageName);
                Console.WriteLine("** FEELING HAPPY!!! **");
                Console.WriteLine("Astrilde, I walked {0} to kms find you. Will you marry me?", Hugi.CalculateDistanceWalked());
                Console.ReadLine();
                Hugi.FoundAstrilde = true;
            }
            TraverseVillages(CurrentVillage.west);
            TraverseVillages(CurrentVillage.east);
        }
        // TO DO: Complete this section 
        catch (Exception nre)
        {
        }
    }

    public void Run()
    {
        Alst = new Village("Alst", false);
        Schvenig = new Village("Schvenig", false);
        Wessig = new Village("Wessig", false);
        Maeland = new Village("Maeland", false);
        Helmholtz = new Village("Helmholtz", false);
        Uster = new Village("Uster", false);
        Badden = new Village("Badden", true);

        Alst.VillageSetup(0, Schvenig, Wessig);
        Schvenig.VillageSetup(14, Maeland, Helmholtz);
        Wessig.VillageSetup(19, Uster, Badden);
        Maeland.VillageSetup(9, null, null);
        Helmholtz.VillageSetup(28, null, null);
        Uster.VillageSetup(28, null, null);
        Badden.VillageSetup(11, null, null);

        this.TraverseVillages(Alst);
    }
    public void Announcement()
    {
        try
        {
            using (StreamReader sr = new StreamReader("am.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    Console.ReadLine();
                }

            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}

class Village
{
    public Village(string _villageName, bool _isAHere)
    {
        isAstrildgeHere = _isAHere;
        VillageName = _villageName;
    }

    public void VillageSetup(int _prevVillageDist, Village _westVillage, Village _eastVillage)
    {
        east = _eastVillage;
        west = _westVillage;
        distanceFromPreviousVillage = _prevVillageDist;
    }

    public Village west;
    public Village east;
    public string VillageName;
    public int distanceFromPreviousVillage;
    public bool isAstrildgeHere;
}
