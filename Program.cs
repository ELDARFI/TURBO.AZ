using System;
using System.IO;
using Scanerr;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TT_az
{
    [Serializable] [Obsolete] 
    internal class Program
    {
        #region Elaveler
        static string Filebrands = @"brands.dat";
        static string Filemodels = @"models.dat";
        static string Filecars = @"cars.dat";
        #endregion
        


        static void Main(string[] args)
        {
            #region zirzibil
            int markaid;
            int modelid;
            int carid;

            GenericStore<markas> Markas = LoadBrands(Filebrands);
            GenericStore<models> Models = LoadModels(Filemodels);
            GenericStore < cars > Cars = LoadCars(Filecars);
            #endregion

            l1:

            Fullmenuu:

            fullmenu();
            int fulmmenu = Convert.ToInt32(Console.ReadLine());
            int exit = 0;
            while (exit == 0)
            {
                switch (fulmmenu)
                {
                    //Brands menu
                    case 1:
                        {
                            Brandsmenudefault:
                            brandsmenu();
                            int brandssmenu = Convert.ToInt32(Console.ReadLine());
                            switch (brandssmenu)
                            {

                                case 1:     //brendleri gostermek ++
                                    {
                                        Console.Clear();
                                        Console.WriteLine("## List of Brands ##");

                                        foreach (var item in Markas)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine("Press the enter key to go to the Brands menu: ");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:     //brend elave etmek ++
                                    {
                                        markas m = new markas();
                                        Stepbrandadd:
                                        Console.Clear();
                                        Console.Write("Write the brand name kid: ");
                                        m.markaname = Console.ReadLine();
                                        Markas.Add(m);
                                        Console.Clear();
                                        Console.WriteLine("Adding is succeesfully!!!");
                                        Console.WriteLine("Press the enter key to go to the main menu");
                                        Console.ReadKey();
                                        
                                    }
                                    break;
                                case 3:     //brend duzelisi etmek 
                                    Console.Clear();


                                    Brandediting:
                                    foreach (var item in Markas)
                                    {
                                        Console.WriteLine($"Brand id: {item.markaid} || Brand name: {item.markaname}");
                                    }
                                    markaid = Scaner.ReadInteger("Enter the brand id: ");

                                    var foundMarka = Markas.Find(g => g.markaid == markaid);

                                    if (foundMarka == null)
                                    {
                                        Console.WriteLine("Choose from the list: ");
                                        goto Brandediting;
                                    }
                                    Console.Clear();
                                    foundMarka.markaname = Scaner.ReadString("Brand name: ");
                                    Console.Clear();
                                    Console.WriteLine("Editing was succefully!!!");
                                    Console.WriteLine("Press the enter key to go to the Brands menu");
                                    Console.ReadKey();
                                    break;
                                case 4:     //brend silmek ++
                                    {
                                            Console.Clear();
                                            Console.WriteLine("## List of Brands ##");

                                            foreach (var item in Markas)
                                            {
                                                Console.WriteLine(item);
                                            }
                                            Console.Write("Please, enter the ID for remove: ");
                                            int markaremove = Convert.ToInt32(Console.ReadLine());
                                            Markas.Remove(Markas.Find(g => g.markaid == markaremove));
                                            Console.Clear();
                                            Console.WriteLine("The brand was deleted!!!");
                                            Console.WriteLine("Press the enter key to go to the main menu");
                                            Console.ReadKey();
                                        
                                    }
                                    break;
                                case 5:     //yadda saxlamaq ++
                                    {
                                        Console.Clear();
                                        SaveBrands(Markas, Filebrands);
                                        Console.WriteLine("Saving successfully!!!");
                                        Console.WriteLine("Press the enter key to go to the main menu");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 6:     //yadda saxlamaq ve cixmaq ++
                                    {
                                        Console.Clear();
                                        SaveBrands(Markas, Filebrands);
                                        Console.WriteLine("Saving successfully!!!");
                                        Console.WriteLine("Press the enter key to exit from the menu");
                                        Console.ReadKey();
                                        exit++;
                                        Console.Clear();
                                    }
                                    break;
                                case 7:     //esas menuya qayitmaq  ++
                                    {
                                        goto Fullmenuu;
                                        Console.Clear();
                                    }
                                    break;
                               
                                default:
                                    Console.Clear();
                                    Console.WriteLine("please, enter correct number!!!");
                                    Console.WriteLine("Press the enter key to go to the Brands menu");
                                    Console.ReadKey();
                                    goto Brandsmenudefault;
                                    break;
                            }
                        }
                        break;
                    
                //Models Menu
                    case 2:
                        {
                            Modelsmenudefault:
                            modelsmenu();
                            int modelssmenu = Convert.ToInt32(Console.ReadLine());
                            switch (modelssmenu)
                            {
                                case 1:   //Model listi ++
                                    try
                                    {
                                        Console.Clear();

                                        Console.WriteLine("## List of Models ##");

                                        foreach (var item in Models)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine("Please, press the enter key to go to the Models menu:");
                                        Console.ReadKey();
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The list is empty!!!");
                                        Console.WriteLine("Please, add a new Model or Load model list!!!");
                                        Console.WriteLine("Press the enter key to go to the Models menu");
                                        Console.ReadKey();
                                        goto Modelsmenudefault;
                                    }
                                    break;
                                case 2:   //Model elave etmek
                                   Console.Clear();


                                    models m = new models();

                                    markaid = Scaner.ReadInteger("Brand id: ");

                                    Console.WriteLine("Id of the model: ");
                                    m.ModelID = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Name of the model: ");
                                    m.ModelName = Console.ReadLine();

                                    Console.WriteLine("Mark of the model: ");
                                    m.ModelMarkaId = Convert.ToInt32(Console.ReadLine()); ; ;



                                    Models.Add(m);
                                    Console.Clear();
                                    Console.WriteLine("Adding was succefully!!!");
                                    Console.WriteLine("Press the enter key to go to the Models menu");
                                    Console.ReadKey();
                                    break;
                                case 3:   //Model duzelisi
                                    Console.Clear();


                                Modelediting:
                                    foreach (var item in Models)
                                    {
                                        Console.WriteLine($"Model id: {item.ModelID} || Model name: {item.ModelName}");
                                    }
                                    modelid = Scaner.ReadInteger("Enter the model id: ");

                                    var foundModel = Models.Find(g => g.ModelID == modelid);

                                    if (foundModel == null)
                                    {

                                        Console.WriteLine("Choose from the list: ");


                                        goto Modelediting;
                                    }
                                    Console.Clear();
                                    foundModel.ModelName = Scaner.ReadString("Model name: ");
                                    Console.Clear();
                                    Console.WriteLine("Editing was succefully!!!");
                                    Console.WriteLine("Press the enter key to go to the Models menu");
                                    Console.ReadKey();
                                    
                                    break;
                                case 4:   //Model silmek  ++
                                    Console.Clear();

                                    Console.WriteLine("## List of Models ##");

                                    foreach (var item in Models)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.Write("Please, enter the model id for remove: ");
                                    int modelremove = Convert.ToInt32(Console.ReadLine());
                                    Models.Remove(Models.Find(g => g.ModelID == modelremove));
                                    Console.Clear();
                                    Console.WriteLine("The model was deleted!!!");
                                    Console.WriteLine("Press the enter key to go to the main menu");
                                    Console.ReadKey();
                                    break;
                                case 5: //save  ++
                                    Console.Clear();
                                    SaveModels(Models, Filemodels);
                                    Console.WriteLine("Saving successfully!!!");
                                    Console.WriteLine("Press the enter key to exit from the menu");
                                    Console.ReadKey();
                                    break;
                                case 6:  //save ve cixmaq  ++
                                    Console.Clear();
                                    SaveModels(Models, Filemodels);
                                    Console.WriteLine("Saving successfully!!!");
                                    Console.WriteLine("Press the enter key to exit from the menu");
                                    Console.ReadKey();
                                    exit++;
                                    Console.Clear();
                                    break;
                                case 7:   // esas menuya qayitmaq ++
                                    goto Fullmenuu;
                                    Console.Clear();
                                    break;
                               
                                default:
                                    Console.Clear();
                                    Console.WriteLine("pleas, enter correct number!!!");
                                    Console.WriteLine("Press the enter key to go to the Models menu");
                                    Console.ReadKey();
                                    goto Modelsmenudefault;
                                    break;
                            }
                        }
                        break;

                        //cars menu
                    case 3:
                        {
                            Carsmenudefault:
                            carsmenu();
                            int carssmenu = Convert.ToInt32(Console.ReadLine());
                            switch (carssmenu)
                            {

                                case 1:   //Car list ++


                                    try
                                    {
                                        Console.Clear();

                                        Console.WriteLine("## List of Cars ##");

                                        foreach (var item in Cars)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine("Please, press the enter key to go to the Cars menu:");
                                        Console.ReadKey();
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The list is empty!!!");
                                        Console.WriteLine("Please, add a new Car or Load car list!!!");
                                        Console.WriteLine("Press the enter key to go to the Cars menu");
                                        Console.ReadKey();
                                        goto Carsmenudefault;
                                    }
                                    break;
                                case 2:    //Car elave
                                    Console.Clear();

                                    cars ca = new cars();

                                    markaid = Scaner.ReadInteger("Enter the brand id: ");


                                    

                                    Console.WriteLine("Id of the car: ");
                                    ca.CarId = Convert.ToInt32(Console.ReadLine()); 

                                    Console.WriteLine("Name of the car: ");
                                    ca.CarName = Console.ReadLine();

                                    Console.WriteLine("Model id of the car: ");
                                    ca.CarModelId = Convert.ToInt32(Console.ReadLine()); ; ;

                                    Console.WriteLine("Marka id of the car: ");
                                    ca.CarMarkaId = Convert.ToInt32(Console.ReadLine()); ; ;

                                    Console.WriteLine("Year of the car: ");
                                    ca.CarYear = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Banner number of the car: ");
                                    ca.CarBanNo = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Motor id of the car: ");
                                    ca.CarMotor = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Transmission of the car: ");
                                    ca.CarTransmission = Console.ReadLine();

                                    Console.WriteLine("Color of the car: ");
                                    ca.CarColor = Console.ReadLine();

                                    Console.WriteLine("Price of the car: ");
                                    ca.CarPrice = Convert.ToInt32(Console.ReadLine());

                                    
                                    Console.Clear();
                                    Cars.Add(ca);
                                    Console.WriteLine("You are a greedy piece of shit");
                                    Console.WriteLine("Adding was succesfull!!!");
                                    Console.WriteLine("Press the enter key to go to the Models menu");
                                    Console.ReadKey();
                                    break; 
                                case 3:    //Car duzelish
                                    Console.Clear();
                                    Carediting:
                                    string prompt = @" 
                
    
    _________     _____ __________     .____    .___  ____________________
    \_   ___ \   /  _  \\______   \    |    |   |   |/   _____/\__    ___/
    /    \  \/  /  /_\  \|       _/    |    |   |   |\_____  \   |    |   
    \     \____/    |    \    |   \    |    |___|   |/        \  |    |   
     \______  /\____|__  /____|_  /    |_______ \___/_______  /  |____|   
            \/         \/       \/             \/           \/            
      
";
                                    Console.WriteLine(prompt);
                                    foreach (var item in Cars)
                                    {
                                        Console.WriteLine($"Car id: {item.CarId} || Car name: {item.CarName}");
                                    }
                                    carid = Scaner.ReadInteger("WELL...enter the id of the car to edit it...: ");
                                    Console.Clear();
                                    var foundcars = Cars.Find(g => g.CarId == carid);
                                    if (foundcars == null)
                                    {
                                        Console.WriteLine("CHOOSE WHAT YOU WANT!! HURRY UP!!: ");
                                        goto Carediting;
                                    }
                                    
                                    foundcars.CarName = Scaner.ReadString("Car name: ");
                                    Console.WriteLine();
                                    foundcars.CarYear = Scaner.ReadInteger("Car Year: ");
                                    Console.WriteLine();
                                    foundcars.CarBanNo = Scaner.ReadDouble("Car BanNo: ");
                                    Console.WriteLine();
                                    foundcars.CarMotor = Scaner.ReadDouble("Car Motor: ");
                                    Console.WriteLine();
                                    foundcars.CarTransmission = Scaner.ReadString("Car Transmission: ");
                                    Console.WriteLine();
                                    foundcars.CarColor = Scaner.ReadString("Car Colo: ");
                                    Console.WriteLine();
                                    foundcars.CarPrice = Scaner.ReadDouble("Car Price: ");
                                    Console.WriteLine();
                                    Console.Clear();
                                    Console.WriteLine("You successfully edited it!!");
                                    Console.WriteLine("Now press the enter key to go to the Cars menu");
                                    Console.ReadKey();
                                    break;
                                case 4:    //Car silmek  ++
                                    try
                                    {
                                        Console.Clear();

                                         prompt = @" 
                
    
    _________     _____ __________     .____    .___  ____________________
    \_   ___ \   /  _  \\______   \    |    |   |   |/   _____/\__    ___/
    /    \  \/  /  /_\  \|       _/    |    |   |   |\_____  \   |    |   
    \     \____/    |    \    |   \    |    |___|   |/        \  |    |   
     \______  /\____|__  /____|_  /    |_______ \___/_______  /  |____|   
            \/         \/       \/             \/           \/            
      
";
                                        Console.WriteLine(prompt);

                                        foreach (var item in Cars)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.Write("YOU WANT TO REMOVE THE CAR!? HOW COULD YOU!?... WELL ENTER THE ID NUMBER YOU SICK FUCK!!: ");
                                        int carremove = Convert.ToInt32(Console.ReadLine());
                                        Cars.Remove(Cars.Find(g => g.CarId == carremove));
                                        Console.Clear();
                                        Console.WriteLine("You deleted the car succesfully... AND YOU WILL NEVER SEE IT AGAIN!! HOW COULD YOU DO THAT?!?!");
                                        Console.WriteLine("NOW PRESS ENTER KEY TO GO BACK BEFORE I KILL YOU!!... You MURDERER!!");
                                        Console.ReadKey();
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("ARE YOU STUPID?! YOU DIDND ADD ANYTHING!! WHY ARE YOU PRESSING THIS BUTTON!?");
                                        Console.WriteLine("ADD SOMETHING TO LIST TO SEE THE LIST!!!!");
                                        Console.WriteLine("NOW PRESS ENTER KEY AND DO SOMETHING");
                                        Console.ReadKey();
                                        goto Carsmenudefault;
                                    }
                                    break;
                                case 5:    //save  
                                    Console.Clear();
                                    SaveCars(Cars, Filecars);
                                    Console.WriteLine("FILE SAVED SUCCESSFULLY!!");
                                    Console.WriteLine("NOW PRESS THE ENTER KEY TO GO BACK TO MAIN MENU AND TRY SOMETHING ELSE!!");
                                    Console.ReadKey();
                                    break;
                                case 6:    //save ve exit  
                                    Console.Clear();
                                    SaveCars(Cars, Filecars);
                                    Console.WriteLine("FINALLY YOU SAVED IT!!");
                                    Console.WriteLine("NOW YOU CAN PRESS ENTER KEY AND GO... WHY ARE YOU KEEP READING IT!? GO ALREADY!!");
                                    Console.ReadKey();
                                    exit++;
                                    Console.Clear();
                                    break;
                                case 7:    //GO TO MAIN MENU
                                    goto Fullmenuu;
                                    Console.Clear();
                                    break;
                              
                                default:
                                    Console.Clear();
                                    Console.WriteLine("ENTER CORRECT ALREADY!!!");
                                    Console.WriteLine("GO BAC NOW!!");
                                    Console.ReadKey();
                                    goto Carsmenudefault;
                                    break;
                            }
                        }
                        break;
                        //Exit the menu
                    case 4:
                        Console.Clear();
                        exit++;
                            break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You made a big mistake... ");
                        Console.WriteLine("TRY AGAIN!! NOW!!! PRESS ANY KEY TO GO BACK TO MAIN MENU ALREADY!!");
                        Console.ReadKey();
                        goto Fullmenuu;
                        break;
                }
            }















            #region Save and Loads

            [Obsolete]
            static void SaveBrands(GenericStore<markas> Markas, string Filebrands)
            {
                using (var fs = new FileStream(Filebrands, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, Markas);
                }
            }
            [Obsolete]

            static GenericStore<markas> LoadBrands(string Filebrands)
            {
                try
                {
                    using (var fs = new FileStream(Filebrands, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        return (GenericStore<markas>)bf.Deserialize(fs);
                    }
                }
                catch (Exception)
                {
                    return new GenericStore<markas>();
                }
            }
            [Obsolete]

            static void SaveModels(GenericStore<models> Models, string Filemodels)
            {
                using (var fs = new FileStream(Filemodels, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, Models);
                }
            }
            [Obsolete]

            static GenericStore<models> LoadModels(string Filemodels)
            {
                try
                {
                    using (var fs = new FileStream(Filemodels, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        return (GenericStore<models>)bf.Deserialize(fs);
                    }
                }
                catch (Exception)
                {
                    return new GenericStore<models>();
                }
            }
            [Obsolete]
            static void SaveCars(GenericStore<cars> Cars, string Filecars)
            {
                using (var fs = new FileStream(Filecars, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, Cars);
                }
            }
            [Obsolete]
            static GenericStore<cars> LoadCars(string Filecars)
            {
                try
                {
                    using (var fs = new FileStream(Filecars, FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        return (GenericStore<cars>)bf.Deserialize(fs);
                    }
                }
                catch (Exception)
                {
                    return new GenericStore<cars>();
                }
            }
            #endregion


            #region Main menu
            static void brandsmenu()
            {
                Console.Clear();
                string prompt = @" 
                
    ____________________    _____    _______  ________    _________        _____  ___________ _______   ____ ___ 
    \______   \______   \  /  _  \   \      \ \______ \  /   _____/       /     \ \_   _____/ \      \ |    |   \
     |    |  _/|       _/ /  /_\  \  /   |   \ |    |  \ \_____  \       /  \ /  \ |    __)_  /   |   \|    |   /
     |    |   \|    |   \/    |    \/    |    \|    `   \/        \     /    Y    \|        \/    |    \    |  / 
     |______  /|____|_  /\____|__  /\____|__  /_______  /_______  /     \____|__  /_______  /\____|__  /______/  
            \/        \/         \/         \/        \/        \/              \/        \/         \/          
";
                Console.WriteLine(prompt);
                Console.WriteLine("        1.B R A N D S:");
                Console.WriteLine("        2.A D D   N E W   B R A N D:");
                Console.WriteLine("        3.E D I T   B R A N D:");
                Console.WriteLine("        4.R E M O V E   B R A N D:");
                Console.WriteLine("        5.S A V E   A   B R A N D:");
                Console.WriteLine("        6.S A V E   A N D   E X I T:");
                Console.WriteLine("        7.M A I N   M E N U:");

                Console.Write("            Enter a number if you want to choose boy. Or... Are you scared?: ");




            }
            static void modelsmenu()
            {
                Console.Clear();
                string prompt = @"   
       _____   ________  ________  ___________.____       _________ 
      /     \  \_____  \ \______ \ \_   _____/|    |     /   _____/
     /  \ /  \  /   |   \ |    |  \ |    __)_ |    |     \_____  \ 
    /    Y    \/    |    \|    `   \|        \|    |___  /        \
    \____|__  /\_______  /_______  /_______  /|_______ \/_______  /
            \/         \/        \/        \/         \/        \/    

";
                Console.WriteLine(prompt);
                Console.WriteLine("1.M O D E L S:");
                Console.WriteLine("2.A D D   N E W   M O D E L:");
                Console.WriteLine("3.E D I T   M O D E L:");
                Console.WriteLine("4.R E M O V E   M O D E L:");
                Console.WriteLine("5.S A V E   M O D E L:");
                Console.WriteLine("6.S A V E   A N D   E X I T:");
                Console.WriteLine("7.M A I N   M E N U:");
                Console.Write("Aaaaaaand... Enter a number!!: ");

            }
            static void carsmenu()
            {
                Console.Clear();
                Console.WriteLine("1.C A R S:");
                Console.WriteLine("2.A D D   N E W   C A R:");
                Console.WriteLine("3.E D I T   C A R:");
                Console.WriteLine("4.R E M O V E   C A R:");
                Console.WriteLine("5.S A V E:");
                Console.WriteLine("6.S A V E   A N D   E X I T:");
                Console.WriteLine("7.G O   B A C K:");
                Console.Write("Would you press any numer?! Dont stare at me!!: ");

            }


            static void fullmenu()
            {

                Console.Clear();
                string prompt = @" 
                      __      _____________.____   _________  ________      _____  ___________._._.
                     /  \    /  \_   _____/|    |  \_   ___ \ \_____  \    /     \ \_   _____/| | |
                     \   \/\/   /|    __)_ |    |  /    \  \/  /   |   \  /  \ /  \ |    __)_ | | |
                      \        / |        \|    |__\     \____/    |    \/    Y    \|        \ \|\|
                       \__/\  / /_______  /|_______ \______  /\_______  /\____|__  /_______  / ____
                            \/          \/         \/      \/         \/         \/        \/  \/\/ ";
                Console.WriteLine(prompt);
                Console.WriteLine();
                Console.WriteLine("                                               1.B R A N D   M E N U:");
                Console.WriteLine("                                               2.M O D E L S   M E N U:");
                Console.WriteLine("                                               3.C A R   M E N U:");
                Console.WriteLine("                                               4.E X I T   M E N U:");
                Console.WriteLine();
                Console.Write("                                   HELLOOOOOOOOUUU BOY!! Enter the number you want: ");
            }
            #endregion
        }
    }
}
