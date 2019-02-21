using System;


namespace ConsoleApp3
{
    class program
    {
        static void Main(string[] args)
        {

        }
    }


    class CountrySide
    {
        // Create the LinkedList to reflect the Map in the PowerPoint Instructions
        Village Maeland;
        Village Helmholtz;
        Village Alst;
        Village Wessig;
        Village Badden;
        Village Uster;
        Village Schvenig;
        public void Travelvillages(Village currentvillage)
        {
            try
            {
                if (currentvillage.isAstrildgeHere)
                {
                    Console.WriteLine("i found dear Astridge in {0}", currentvillage.VillageName);
                    Console.WriteLine("feeling happy");
                    return;
                }
                Travelvillages(currentvillage.west);
                Travelvillages(currentvillage.east);


            }
            catch (NullReferenceException one) { }
        }

            public void Run()
            {
                Alst = new Village("Alst", false);
                Schvenig = new Village("Schveing", false);
                Wessig = new Village("Wessig", true);
                Alst.distanceToeastVillage = 14;
                Alst.distanceTowesttVillage = 19;
                Alst.west = Schvenig;
                Alst.east = Wessig;

                Schvenig.west = null;
                Schvenig.east = null;

                Wessig.west = null;
                Wessig.east = null;
                this.Travelvillages(Alst);
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

        public Village west;
        public Village east;
        public string VillageName;
        public int distanceToeastVillage;
        public int distanceTowesttVillage;
        public int distanceToPreviousVillage;
        public bool isAstrildgeHere;
    }
}
        

