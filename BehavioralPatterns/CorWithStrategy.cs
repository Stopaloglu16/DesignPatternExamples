using Microsoft.Extensions.Logging;
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
        //private readonly ILogger<CorWithStrategy> _logger;

        //public CorWithStrategy(ILogger<CorWithStrategy> logger)
        //{
        //    _logger = logger;
        //}

        public static void Create(ILogger<CorWithStrategy> _logger) 
        {

           //var logger = LoggerFactory.Create().CreateLogger<CorWithStrategy>();

            OrderModel OrderModel = new OrderModel();
            OrderModel.UserID = 1;
            OrderModel.FullAddress = "11 road AB1 3DC";


            IStoreProcessStrategy firstProcess = new CheckPayment();

            _logger.LogInformation("Started");

            while (firstProcess.NextProcess != null) 
            {
                _logger.LogInformation(DateTime.Now.TimeOfDay +  firstProcess.NextProcess?.ToString() ?? "");

                if (firstProcess.Run(OrderModel))
                {
                    firstProcess = firstProcess.NextProcess;
                }
                else
                {
                    Console.WriteLine("Oups!, issue");
                    break;
                }
            }

            Console.WriteLine(OrderModel.IsPaid);
            Console.WriteLine(OrderModel.IsPrepared);
            Console.WriteLine(OrderModel.IsCooked);
            Console.WriteLine(OrderModel.IsPacked);
            Console.WriteLine(OrderModel.IsOutOfDelivery);
        }
    }


    public interface IStoreProcessStrategy
    {
        public bool Run(OrderModel model);
        public IStoreProcessStrategy NextProcess { get; set; }
    }

    public class StoreProcessStrategy
    {
        public IStoreProcessStrategy NextProcess { get; set; }
    }

    public class OrderModel
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
            NextProcess = new CheckPrepared();
        }

        public bool Run(OrderModel model)
        {
            model.IsPaid = true;
            return true;
        }
    }

    public class CheckPrepared : StoreProcessStrategy, IStoreProcessStrategy
    {
        public CheckPrepared()
        {
            NextProcess = new CheckCooked();
        }

        public bool Run(OrderModel model)
        {
            Thread.Sleep(1000);
            model.IsPrepared = true;
            return true;
        }
    }


    public class CheckCooked : StoreProcessStrategy, IStoreProcessStrategy
    {
        public CheckCooked()
        {
            NextProcess = new CheckPacked();
        }


        public bool Run(OrderModel model)
        {
            Thread.Sleep(5000);
            model.IsCooked = true;
            return true;
        }
    }

    public class CheckPacked : StoreProcessStrategy, IStoreProcessStrategy
    {
        public CheckPacked()
        {
            NextProcess = new CheckOutOfDelivery();
        }

        public bool Run(OrderModel model)
        {
            Thread.Sleep(1000);
            model.IsPacked = true;
            return true;
        }
    }


    public class CheckOutOfDelivery : StoreProcessStrategy, IStoreProcessStrategy
    {
        public CheckOutOfDelivery()
        {
            NextProcess = new CheckCompleted();
        }

        public bool Run(OrderModel model)
        {
            Thread.Sleep(7000);
            model.IsOutOfDelivery = true;
            return true;
        }
    }

    public class CheckCompleted : StoreProcessStrategy, IStoreProcessStrategy
    {
        public CheckCompleted()
        {
            NextProcess = null;
        }

        public bool Run(OrderModel model)
        {
            Thread.Sleep(1000);
            return true;
        }
    }
}
