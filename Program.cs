using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace GalaxySmash
{
    static class Program
    {
        static void Main()
        {
            Log.LogSource = "GalaxySmash";

            SettingsLocal.Load(SettingsLocal.SettingsLoadBehavior.CreateNewIfMissing, "settings.xml");

            SettingsLocal.EnsureSettingExists("CurrentUniverseID", "0");
            SettingsLocal.EnsureSettingExists("NextUniqueGalaxyID", "1");
            SettingsLocal.EnsureSettingExists("NextUniqueUniverseID", "1");

            SettingsLocal.EnsureSettingExists("GridSizeUniverse0", "40");
            SettingsLocal.EnsureSettingExists("Universe0GalaxyID", "0");
            SettingsLocal.EnsureSettingExists("UniverseID", "0");

            SettingsLocal.EnsureSettingExists("Galaxy0NumberOfStars", "10000");
            SettingsLocal.EnsureSettingExists("Galaxy0DistributionIterations", "100");
            
            SettingsLocal.EnsureSettingExists("Galaxy0PositionX", "0");
            SettingsLocal.EnsureSettingExists("Galaxy0PositionY", "0");
            SettingsLocal.EnsureSettingExists("Galaxy0PositionZ", "0");

            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewX", "10");
            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewY", "12");
            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewZ", "13");

            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewLowX", "1.0");
            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewLowY", "1.0");
            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewLowZ", "1.05");

            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewHighX", "1.15");
            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewHighY", "1.1");
            SettingsLocal.EnsureSettingExists("Galaxy0ChanceSkewHighZ", "1.15");

            SettingsLocal.EnsureSettingExists("RenderSectorGeometry", false.ToString());
            SettingsLocal.EnsureSettingExists("RenderStars", true.ToString());
            SettingsLocal.EnsureSettingExists("RenderVelocityVectors", false.ToString());
            SettingsLocal.EnsureSettingExists("CalculationMode", "SimpleApproximated");

            SettingsLocal.EnsureSettingExists("Galaxy0StarMass", "10");
            SettingsLocal.EnsureSettingExists("Galaxy0StarVelocity", "0.01");
            SettingsLocal.EnsureSettingExists("Galaxy0SupermassiveBlackHoleSolarMasses", "100");
            SettingsLocal.EnsureSettingExists("Galaxy0StarColor", Color.White.ToArgb().ToString());

            SettingsLocal.EnsureSettingExists("StarBufferSize", "100000");
            SettingsLocal.EnsureSettingExists("MaxProcessingThreadCount", "6");

            SettingsLocal.EnsureSettingExists("MaxStarsPerSector", "10000");
            
            SettingsLocal.Save();

            using (Form1 mainWindow = new Form1())
            {
                Application.Run(mainWindow);
            }
        }
    }
}
