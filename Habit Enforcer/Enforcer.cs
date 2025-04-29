using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Habit_Enforcer
{
    public class Enforcer
    {
        private static readonly string[] blockedApps = [ "mspaint", "discord", "steam", "battle.net", "world of warcraft", "minecraft" ];

        public static void Enforce(List<String> habits)
        {
            Console.WriteLine("Enforcer is currently enforcing...");

            while (habits.Count > 0)
            {
                foreach (var app in blockedApps)
                {
                    KillApp(app);
                }
                Thread.Sleep(3000);
            }
            
            
        }

        public static void KillApp(string appName)
        {
            foreach (var process in Process.GetProcessesByName(appName))
            {
                try
                {
                    process.Kill();
                    Console.WriteLine($"Blocked and closed: {appName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error closing {appName}: {ex.Message}");
                }
            }
        }
    }
}
