namespace CW_Internal_Hack.Config
{
    internal class Config
    {
        internal class Aimbot
        {
            // Features | Aimbot.cs
            internal static bool AimbotEnabled = true;
            internal static int smooth = 5; // Smooth that gets used to move your mouse. If you make it smaller it will be more snapy.
        }

        internal class Visual
        {
            // Features | Chams.cs
            internal static bool Chams = false; // By time creates lag spikes. Missing thing: I have to clear the objects.
            // Features | DistanceESP.cs
            internal static bool DistanceESP = true;
            // Features | HealthESP.cs
            internal static bool HealthESP = false;
            // Features | BoxESP.cs
            internal static bool BoxESP = true;
            // Features | Snaplines.cs
            internal static bool Snaplines = true;

        }

        internal class Misc
        {
            // Features | Environment.cs
            internal static bool RemovePlants = false;
        }
    }
}
