// See https://aka.ms/new-console-template for more information
using DesignPatternExamples.CreationalPatterns;
using DesignPatternExamples.StructuralPatterns;

Console.WriteLine("Welcome to desing patters");
Console.WriteLine(new String('-', 30));

var myPatterns = DesignPatternExamples.DesignPatterList.GetList();


DesignPatternExamples.DesignPatterList.WriteList(myPatterns);


while (true)
{

    var myEntry = Console.ReadLine();

    if (int.TryParse(myEntry, out int value))
    {

        switch (Convert.ToInt32(myEntry))
        {
            case 1:
                AbstractFactoryCreate.Create();
                break;
            case 2:
                BuilderCreate.Create(); 
                break;
            case 3:
                FactoryMethodCreate.Create();
                break;
            case 4:
                PrototypeSampleCreate.Create();
                break;
            case 5:
                SingletonSampleCreate.Create();
                break;

            case 6:
                AdapterSample.Create();
                break;
            case 7:
                BridgeSample.Create();
                break;
            case 8:
                CompositeSample.Create();
                break;
            case 9:
                DecoratorSample.Create();
                break;
            case 10:
                FacadeSample.Create();
                break;
            case 11:
                FlyweightSample.Create();
                break;



            case 0:
                break;

            default:
                Console.WriteLine("unknown");
                break;
        }

        if (Convert.ToInt32(myEntry) == 0) break;

    }
    else
    {
        Console.Clear();

        DesignPatternExamples.DesignPatterList.WriteList(myPatterns);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("============Pls choose your design to run!============");
        Console.ForegroundColor = ConsoleColor.White;

    }
}

