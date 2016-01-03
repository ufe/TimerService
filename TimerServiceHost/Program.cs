namespace TimerServiceHost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Configuration;

    /// <summary>
    /// Just host my service in a console application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:10002/TimerService/");

            // Step 2 Create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(UF.Training.TimerService.TimerService), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(UF.Training.TimerService.ITimerService), new BasicHttpBinding(), "TimerService");

                // Step 4 Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 Start the service.
                selfHost.Open();
                Console.WriteLine($"The service is running at {baseAddress}");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }


            //ServiceHost svcHost = null;
            //try
            //{
            //    svcHost = new ServiceHost(typeof(UF.Training.TimerService.TimerService));
            //    svcHost.Open(); Console.WriteLine("\n\nService is Running  at following address");

            //    var settings = ConfigurationManager.GetSection("system.serviceModel/services/service/");

            //    // TODO: URL schould not be hard coded, but taken from App.config. UF 26.12.2015
            //    Console.WriteLine("\nhttp://localhost:8733/Design_Time_Addresses/TimerService/Service1/");
            //}
            //catch (Exception ex)
            //{
            //    svcHost = null;
            //    Console.WriteLine("Service can not be started \n\nError Message [" + ex.Message + "]");
            //}
            //if (svcHost != null)
            //{
            //    Console.WriteLine("\nPress any key to close the Service");
            //    Console.ReadKey();
            //    svcHost.Close();
            //    svcHost = null;
            //}
        }
    }
}