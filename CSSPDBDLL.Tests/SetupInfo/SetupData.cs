using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Tests.SetupInfo
{
    public class SetupData
    {
        public List<CultureInfo> cultureListGood { get; set; }
        //public List<CultureInfo> cultureListBad { get; set; }
        public List<ContactModel> contactModelListGood { get; set; }
        public List<ContactModel> contactModelListBad { get; set; }
        public double R { get; set; }
        public List<double> StatData { get; set; }
        public List<double> StatDataP90 { get; set; }
        public List<Coord> coordList { get; set; }
        public SetupData()
        {
            cultureListGood = new List<CultureInfo>() { new CultureInfo("en-CA"), new CultureInfo("fr-CA") };
            //cultureListBad = new List<CultureInfo>() { new CultureInfo("en-GB"), new CultureInfo("FR-FR") };
            contactModelListGood = new List<ContactModel>()
            {
                new ContactModel() { ContactTVItemID = 2, ContactID = 1, LoginEmail = "charles.leblanc2@canada.ca", FirstName = "Charles", Initial = "G", LastName = "LeBlanc", WebName = "Chalres", IsAdmin = true, Disabled = false, EmailValidated = true },
                new ContactModel() { ContactTVItemID = 3, ContactID = 2, LoginEmail = "Test.User1@canada.ca",  FirstName = "Test", Initial = "", LastName = "User1", WebName = "User1", IsAdmin = false, Disabled = false, EmailValidated = true },
                new ContactModel() { ContactTVItemID = 4, ContactID = 3, LoginEmail = "Test.User2@canada.ca", FirstName = "Test", Initial = "", LastName = "User2", WebName = "User2", IsAdmin = false, Disabled = false, EmailValidated = false },
                new ContactModel() { ContactTVItemID = 4, ContactID = 3, LoginEmail = "DoesNotExist@canada.ca", FirstName = "Test", Initial = "", LastName = "User2", WebName = "User2", IsAdmin = false, Disabled = false, EmailValidated = false },
            };
            contactModelListBad = new List<ContactModel>()
            {
                new ContactModel() { LoginEmail = "BAdcharles.leblanc2@canada.ca", FirstName = "Charles", Initial = "G", LastName = "LeBlanc", WebName = "Chalres", IsAdmin = false, Disabled = false, EmailValidated = false },
            };
            R = 6378137.0;
            StatData = new List<double>()
            {
                12, 23, 2, 5, 7, 8, 223, 1600, 489, 34, 2, 1, 1, 1, 1, 888
            };
            StatDataP90 = new List<double>()
            {
                 13, 23, 22, 240, 11, 11, 33, 110, 23, 9, 540, 70, 23, 23, 13, 79, 130, 49, 33, 70, 14, 46, 920, 240, 1.9, 23, 170, 33, 11, 1700
            };
            coordList = new List<Coord>()
            {
                new Coord() { Lat = (float)47.65235110437133, Lng = (float)-64.61593817186726 },
                new Coord() { Lat = (float)47.64230461851978, Lng = (float)-64.69717914537091 },
                new Coord() { Lat = (float)47.5711504048336, Lng = (float)-64.74559162671262 },
                new Coord() { Lat = (float)47.48996640803745, Lng = (float)-64.75412203511117 },
                new Coord() { Lat = (float)47.44491300447684, Lng = (float)-64.64021761683195 },
                new Coord() { Lat = (float)47.46310310263369, Lng = (float)-64.52747568232635 },
                new Coord() { Lat = (float)47.61057955460339, Lng = (float)-64.51503060684613 },
                new Coord() { Lat = (float)47.65235110437133, Lng = (float)-64.61593817186726 },
            };
        }
    }
}
