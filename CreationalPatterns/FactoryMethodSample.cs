using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExamples.CreationalPatterns
{

    public class FactoryMethodCreate
    {

        //This structural code demonstrates the Factory method offering great flexibility in creating different objects.
        //The Abstract class may provide a default object, but each subclass can instantiate an extended version of the object.

        public static void Create()
        {

            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[0].TypeId = 1;
            creators[0].CreatorName = "A type";


            creators[1] = new ConcreteCreatorB();
            creators[1].TypeId = 2;
            creators[1].CreatorName = "B type";


            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                //Console.WriteLine("Created {0}", product.GetType().Name);
                Console.WriteLine("Created Creator {0} Product {1} ", creator.CreatorName, product.ProductName);
            }
        }


    }


    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    abstract class Product
    {
        public string? ProductName { get; set; }
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductA : Product
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductB : Product
    {
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Creator
    {
        public int TypeId { get; set; }
        public string? CreatorName { get; set; }

        public abstract Product FactoryMethod();
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA() { ProductName = "TypeA"};
        }
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB() { ProductName = "TypeB" }; 
        }
    }


}
