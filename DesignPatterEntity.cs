using System.Net.Mime;

namespace DesignPatternExamples
{
    public class DesignPatterEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TypeName { get; set; }

        public string? Description { get; set; }

    }

    public class DesignPatterList
    {

        public static List<DesignPatterEntity> GetList()
        {
            int index = 1;
            const string BehavioralPatterns = "Behavioral Patterns"; 

            List<DesignPatterEntity> myList = new List<DesignPatterEntity>() {
                    new DesignPatterEntity() {TypeName = "Creational Patterns",  Id = index, Name = "Abstract Method"}, //1
                    new DesignPatterEntity() {TypeName = "Creational Patterns", Id = ++index, Name = "Builder"},
                    new DesignPatterEntity() {TypeName = "Creational Patterns", Id = ++index, Name = "Factory Method"},
                    new DesignPatterEntity() {TypeName = "Creational Patterns", Id = ++index, Name = "Prototype"},
                    new DesignPatterEntity() {TypeName = "Creational Patterns", Id = ++index, Name = "Singleton"},

                    new DesignPatterEntity() {TypeName = "Structural Patterns", Id = ++index, Name = "Adapter"},//6
                    new DesignPatterEntity() {TypeName = "Structural Patterns", Id = ++index, Name = "Bridge"},
                    new DesignPatterEntity() {TypeName = "Structural Patterns", Id = ++index, Name = "Composite"},//8
                    new DesignPatterEntity() {TypeName = "Structural Patterns", Id = ++index, Name = "Decorator"}, //9
                    new DesignPatterEntity() {TypeName = "Structural Patterns", Id = ++index, Name = "Facade"},
                    new DesignPatterEntity() {TypeName = "Structural Patterns", Id = ++index, Name = "Flyweight"},
                    new DesignPatterEntity() {TypeName = "Structural Patterns", Id = ++index, Name = "Proxy"},

                     
                    new DesignPatterEntity() {TypeName = BehavioralPatterns, Id = ++index, Name = "Command"}, //13
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Interpreter"},
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Iterator"},
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Mediator"},
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Memento"},
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Observer"},
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "State"},
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Strategy"}, //20
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Template"},
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "Visitor" },
                    new DesignPatterEntity() {TypeName = "Behavioral Patterns", Id = ++index, Name = "CorWithStrategy"} //23

            };

            return myList;
        }


        public static void WriteList(List<DesignPatterEntity> myPatterns)
        {
            foreach (var myPattern in myPatterns)
            {
                Console.WriteLine(myPattern.Id + " " + myPattern.Name);
            }
        }

    }

}
