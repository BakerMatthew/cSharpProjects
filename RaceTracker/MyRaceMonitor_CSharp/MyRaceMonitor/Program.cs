using System;
using AppLayer;

namespace MyRaceMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SimulatorController controller = new SimulatorController();
            controller.Setup();
            controller.Run();
        }
    }
}
