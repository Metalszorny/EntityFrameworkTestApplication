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

		/// <summary>
        /// The main entry point for the application.
        /// </summary>
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
            ServiceHost serviceHost = new ServiceHost(typeof(ServerM), new Uri(address));

            try
            {
                // Bind a serviceHost.
                serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior());

                // Open a serviceHost.
                serviceHost.AddServiceEndpoint(typeof(EF_PoC_Customer.IServerM), new NetTcpBinding(), address);
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
