using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KodomoClaims
{
    class KomodoClaimApp
    {
        static void Main(string[] args)
        {
            ClaimsUI claimApp = new ClaimsUI();
            claimApp.Run();
            //double value = 234.66;

            //// displays $
            //Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture));
            //Console.WriteLine(value.ToString("C5", CultureInfo.CurrentCulture));
            //Console.ReadLine();
        }
    }
}
