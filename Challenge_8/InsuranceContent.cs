using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class InsuranceContent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DriverAge { get; set; }
        public int Swerve { get; set; }
        public int CloseAccident { get; set; }
        public int StopSign { get; set; }
        public int LateForWork { get; set; }
        public bool HadAccident { get; set; }
        public decimal Premium { get; set; }
        public InsuranceContent(string firstname, string lastname, int driverAge, int swerve, int closeAccident, int stopSign, int lateForWork, bool hadAccident, decimal premium)
        {
            FirstName = firstname;
            LastName = lastname;
            DriverAge = driverAge;
            Swerve = swerve;
            CloseAccident = closeAccident;
            StopSign = stopSign;
            LateForWork = lateForWork;
            HadAccident = hadAccident;
            Premium = premium;
        }
        public InsuranceContent()
        {
        }
    }
}
