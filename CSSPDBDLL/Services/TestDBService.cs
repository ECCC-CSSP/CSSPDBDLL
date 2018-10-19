using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using CSSPDBDLL.Services.Resources;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{

    public class TestDBService : BaseService
    {
        #region Variables public
        public int Count = 0;
        public DBTable dbTable;
        #endregion Variables public

        #region Constructors
        public TestDBService(LanguageEnum LanguageRequest, IPrincipal User, string TableName, string Plurial)
            : base(LanguageRequest, User)
        {
            this.dbTable = new DBTable() { TableName = TableName, Plurial = Plurial };
            if (!string.IsNullOrWhiteSpace(TableName))
            {
                FillCount();
            }
        }
        #endregion Constructors

        #region Functions public
        public string CompareDBAndList(List<string> TablesNameInDB, List<DBTable> AllTables)
        {
            for (int i = 0; i < AllTables.Count; i++)
            {
                if (AllTables[i].TableName + AllTables[i].Plurial != TablesNameInDB[i])
                {
                    return string.Format(ServiceRes.TableListNotEqual_And_, AllTables[i].TableName + AllTables[i].Plurial, TablesNameInDB[i]);
                }
            }
            return "";
        }
        public string CompareTableList(List<DBTable> AllTables, List<DBTable> AllTablesToDelete)
        {
            List<DBTable> orderedAllTables = (from c in AllTables orderby c.TableName select c).ToList<DBTable>();
            List<DBTable> orderedAllTablesToDelete = (from c in AllTablesToDelete orderby c.TableName select c).ToList<DBTable>();

            if (AllTables.Count != AllTablesToDelete.Count)
            {
                return string.Format(ServiceRes._CountAnd_CountNotEqual, "AllTables", "AllTablesToDelete");
            }

            int Count = orderedAllTables.Count;
            for (int i = 0; i < Count; i++)
            {
                if (orderedAllTables[i].TableName != orderedAllTablesToDelete[i].TableName)
                {
                    return string.Format(ServiceRes.CompareTableNotEqual_And_, orderedAllTables[i].TableName, orderedAllTablesToDelete[i].TableName);
                }
                if (orderedAllTables[i].Plurial != orderedAllTablesToDelete[i].Plurial)
                {
                    return string.Format(ServiceRes.CompareTablePlurialNotEqual_And_, orderedAllTables[i].TableName, orderedAllTablesToDelete[i].TableName);
                }
            }

            return "";
        }
        public string CSSPDBIsOK()
        {
            List<DBTable> AllTables = new List<DBTable>();
            FillTableNameList(AllTables);

            List<string> TablesNameInDB = new List<string>();
            FillDBTablesName(TablesNameInDB);

            string retStr = CompareDBAndList(TablesNameInDB, AllTables);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            List<DBTable> AllTablesToDelete = new List<DBTable>();
            FillTableNameToDeleteList(AllTablesToDelete);

            retStr = CompareTableList(AllTables, AllTablesToDelete);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";

        }
        public void FillDBTablesName(List<string> TablesNameInDB)
        {
            var ListOfTables = db.Database.SqlQuery(typeof(string), "SELECT name FROM sys.tables order by name");

            foreach (string s in ListOfTables)
            {
                TablesNameInDB.Add(s);
            }
        }
        public void FillTableNameList(List<DBTable> AllTables)
        {
            AllTables.Add(new DBTable() { TableName = "Address", Plurial = "es" });
            AllTables.Add(new DBTable() { TableName = "AppErrLog", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "AppTaskLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "AppTask", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "AspNetRole", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "AspNetUserClaim", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "AspNetUserLogin", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "AspNetUserRole", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "AspNetUser", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "BoxModelLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "BoxModelResult", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "BoxModel", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "ClimateDataValue", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "ClimateSite", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "ContactPreference", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "Contact", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "ContactShortcut", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "DocTemplate", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "Email", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "HydrometricDataValue", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "HydrometricSite", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "InfrastructureLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "Infrastructure", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "LabSheetDetail", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "LabSheet", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "LabSheetTubeMPNDetail", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "Log", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MapInfoPoint", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MapInfo", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MikeBoundaryCondition", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MikeScenario", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MikeSource", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MikeSourceStartEnd", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMLookupMPN", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "SamplingPlan", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "SamplingPlanSubsector", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "SamplingPlanSubsectorSite", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMRunLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMRun", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMSampleLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMSample", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMSite", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMSiteStartEndDate", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMSubsectorLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "MWQMSubsector", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "PolSourceObservationIssue", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "PolSourceObservation", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "PolSourceSite", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "RatingCurve", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "RatingCurveValue", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "ResetPassword", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "SpillLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "Spill", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "Tel", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TideDataValue", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TideLocation", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TideSite", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVFileLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVFile", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVItemLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVItemLink", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVItem", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVItemStat", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVItemUserAuthorization", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "TVTypeUserAuthorization", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "UseOfSite", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "VPAmbient", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "VPResult", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "VPScenarioLanguage", Plurial = "s" });
            AllTables.Add(new DBTable() { TableName = "VPScenario", Plurial = "s" });

        }
        public void FillTableNameToDeleteList(List<DBTable> AllTablesToDelete)
        {
            AllTablesToDelete.Add(new DBTable() { TableName = "Log", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AppErrLog", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AppTaskLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AppTask", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AspNetRole", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AspNetUserClaim", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AspNetUserLogin", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AspNetUserRole", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "BoxModelLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "BoxModelResult", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "BoxModel", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "UseOfSite", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "ClimateDataValue", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "ClimateSite", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "DocTemplate", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "Address", Plurial = "es" });
            AllTablesToDelete.Add(new DBTable() { TableName = "Email", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "Tel", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "RatingCurve", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "RatingCurveValue", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "HydrometricDataValue", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "HydrometricSite", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "InfrastructureLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "Infrastructure", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "LabSheetTubeMPNDetail", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "LabSheetDetail", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "LabSheet", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MapInfoPoint", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MapInfo", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MikeBoundaryCondition", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MikeSource", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MikeSourceStartEnd", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMLookupMPN", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "SamplingPlan", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "SamplingPlanSubsector", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "SamplingPlanSubsectorSite", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMRunLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMRun", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMSampleLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMSample", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMSiteStartEndDate", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMSite", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMSubsectorLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MWQMSubsector", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "PolSourceObservationIssue", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "PolSourceObservation", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "PolSourceSite", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "ResetPassword", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "SpillLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "Spill", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TideDataValue", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TideLocation", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TideSite", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVFileLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVFile", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVItemLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVItemLink", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVItemUserAuthorization", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVTypeUserAuthorization", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "VPAmbient", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "VPResult", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "VPScenarioLanguage", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "VPScenario", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "MikeScenario", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "ContactPreference", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "ContactShortcut", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "Contact", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "AspNetUser", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVItemStat", Plurial = "s" });
            AllTablesToDelete.Add(new DBTable() { TableName = "TVItem", Plurial = "s" });

        }
        public DBTable GetDBTable()
        {
            return this.dbTable;
        }
        #endregion Functions public

        #region Functions private
        private bool FillCount()
        {
            string sql = "SELECT Count(*) FROM [" + DBName + "].[dbo].[" + dbTable.TableName + dbTable.Plurial + "]";
            Count = db.Database.SqlQuery<int>(sql).FirstOrDefault<int>();

            if (Count == -1)
            {
                return false;
            }

            return true;
        }
        #endregion Functions private

    }
}
