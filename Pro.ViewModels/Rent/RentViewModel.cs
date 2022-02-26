using Pro.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.ViewModels.Rent
{
   public class RentViewModel
    {
        public string JaktionNumber { get; set; }
        public string FormNumber { get; set; }
        public int RentId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public string Tazkira { get; set; }
        public string AccountBrashna { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }

        public int Phone { get; set; }

  
        public string IncomeMonth { get; set; }

        public string TypeIncome { get; set; }
        public string RentType { get; set; }

        public string Province { get; set; }
        public string Village { get; set; }
        public string Ghozar { get; set; }
        public string HouseNumber { get; set; }

        public int CountLiveINFamily { get; set; }
        public string LiveINFamilyInfo { get; set; }
        public string ProvinceLive { get; set; }
        public string VillageLive { get; set; }
        public string PhoneLive { get; set; }
        public string GhozarLive { get; set; }
        public string CountryLive { get; set; }

        public string LiveWF { get; set; }

        public int LiveWFAge { get; set; }

        public string EType { get; set; }

        public string EMCount { get; set; }

        public string UseGenerator { get; set; }

        public string CapacityG { get; set; }
        public string HourUG { get; set; }

        public string WhenUG { get; set; }

        public double ExpenseG { get; set; }

        public string SourceE { get; set; }

        public string SourceEType { get; set; }


        public int Room { get; set; }
        public int Floor { get; set; }
        public int WC { get; set; }
        public int Kichen { get; set; }

        public string TypeHome { get; set; }

        public double AreaBuilding { get; set; }
        public double Land { get; set; }



        public string AirCandition { get; set; }

        public string[] UseTypeWarming { get; set; }

        public string HourOnStove { get; set; }

        public string TradeHome { get; set; }

        public string TypeTrade { get; set; }

        public string TradeName { get; set; }

        public int TradeYear { get; set; }

        public int StaffCount { get; set; }


        public string BillRecive { get; set; }

        public string BillDayDaily { get; set; }

        public string GhastVar { get; set; }

        public double ExpenseOld { get; set; }

        public string PayOnTime { get; set; }

        public string EAlltime { get; set; }
        public int EHour { get; set; }

        public string WantEAT { get; set; }


        public string PayForEAT { get; set; }

        public string BSolor { get; set; }

        public string SolorAmountAssets { get; set; }

        public string[] Language { get; set; }


        public string EmailAddress { get; set; }


        public string WayContact { get; set; }

        public string Rezayat { get; set; }

        public string Suggestion { get; set; }

        public List<RentPowerMeter> PowerMeters { get; set; }
        public List<RentResident> Residents { get; set; }
        public List<RentEEquipmentH> EEquipmentHs { get; set; }
        public List<RentEquipmentCom> EEquipmentComs { get; set; }

    }
}
