using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExamples.BehavioralPatterns
{

    //Chain og Responsibility with Strategy pattern
    public class CorWithStrategy
    {
        public static void Create()
        {

            RequestModel requestModel = new RequestModel();
            requestModel.UserID = 1;
            requestModel.FullAddress = "11 road AB1 3DC";


            IStoreProcessStrategy firstProcess = new CheckPayment();

            while (firstProcess.NextRule != null) 
            {

                if(firstProcess.Run(requestModel))
                {
                    firstProcess = firstProcess.NextRule;
                }
                else
                {
                    Console.WriteLine("Oups!, issue");
                    break;
                }
            }

            Console.WriteLine(requestModel.IsPaid);
            Console.WriteLine(requestModel.IsPrepared);
            Console.WriteLine(requestModel.IsCooked);
            Console.WriteLine(requestModel.IsOutOfDelivery);


        }

    }


    public interface IStoreProcessStrategy
    {
        public bool Run(RequestModel model);
        public IStoreProcessStrategy NextRule { get; set; }
    }

    public class StoreProcessStrategy
    {
        public IStoreProcessStrategy NextProcess { get; set; }
    }

    public class RequestModel
    {

        public int UserID { get; set; }
        public string FullAddress { get; set; }
        public bool IsPaid { get; set; } = false;
        public bool IsPrepared { get; set; } = false;
        public bool IsCooked { get; set; } = false;
        public bool IsPacked { get; set; } = false;
        public bool IsOutOfDelivery { get; set; } = false;
    }


    public class CheckPayment : StoreProcessStrategy, IStoreProcessStrategy
    {
        public CheckPayment()
        {
            NextRule = new CheckPrepared();
        }

        public IStoreProcessStrategy NextRule { get; set; }

        public bool Run(RequestModel model)
        {
            model.IsPaid = true;
            return true;
        }
    }

    public class CheckPrepared : StoreProcessStrategy, IStoreProcessStrategy
    {
        //public CheckPayment()
        //{
        //    NextRule = nextRule;
        //}

        public IStoreProcessStrategy NextRule {get; set; }

        public bool Run(RequestModel model)
        {
            throw new NotImplementedException();
        }
    }


    public class CheckOutOfDelivery : StoreProcessStrategy, IStoreProcessStrategy
    {
        public CheckOutOfDelivery()
        {
            NextRule = null;
        }

        public IStoreProcessStrategy NextRule { get; set; }

        public bool Run(RequestModel model)
        {
            throw new NotImplementedException();
        }
    }


}
