using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_of_Duty_HQ.Services
{
    public class Steam
    {
        string steamPath = Program.Configuration["AppSettings:SteamPath"];

        public void StartCoD(int steamID)
        {
            Process.Start($"{steamPath}\\steam.exe", $"steam://rungameid/{steamID}");
        }
    }
}
