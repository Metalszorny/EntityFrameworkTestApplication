using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using EF_PoC_BusinessLogic;

namespace EF_PoC_Server
{
    /// <summary>
    /// Interaction logic for Program.
    /// </summary>
    class Program
    {
        #region Methods

        static void Main()
        {
            #region CheckDatabaseExistance

            // Connect to the BusinessLogic.
            Customers businessLogic = new Customers();

            // Check if database exists.
            switch (businessLogic.DbExists())
            {
                case "ok":
                    Console.WriteLine("Database added.");
                    break;
                case "exists":
                    Console.WriteLine("Database exists.");
                    break;
                case "no":
                case "error":
                    Console.WriteLine("Database failed.");
                    break;
            }

            // Add seed data.
            if (businessLogic.AddSeed())
            {
                Console.WriteLine("Seed added.");
            }
            else
            {
                Console.WriteLine("Seed failed.");
            }

            #endregion CheckDatabaseExistance

            // Configure a serviceHost.
            string address = "net.tcp://localhost/EFPoCAppService";
            Uri baseAddress = new Uri(address);
            ServiceHost serviceHost = new ServiceHost(typeof(ServerM), baseAddress);

            try
            {
                // Bind a serviceHost.
                NetTcpBinding tcpb = new NetTcpBinding();
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                serviceHost.Description.Behaviors.Add(behavior);

                // Open a serviceHost.
                serviceHost.AddServiceEndpoint(typeof(EF_PoC_Customer.IServerM), tcpb, address);
                serviceHost.Open();

                // The server started.
                Console.WriteLine("Server started at: " + address + " address. \nPress ENTER to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                // Show exception and abort the serviceHost.
                Console.WriteLine(ex.ToString());
                serviceHost.Abort();
                Console.ReadLine();
            }

            // Close the serviceHost.
            serviceHost.Close();
        }

        #endregion Methods
    }
}
