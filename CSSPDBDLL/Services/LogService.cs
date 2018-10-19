using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPModelsDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using System.Reflection;

namespace CSSPDBDLL.Services
{
    public class LogService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LogService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public override string DoAddChanges()
        {
            return base.DoAddChanges();
        }
        public override string DoDeleteChanges()
        {
            return base.DoDeleteChanges();
        }
        public override string DoUpdateChanges()
        {
            return base.DoUpdateChanges();
        }
        public override string FieldCheckNotNullDateTime(DateTime? Value, string Res)
        {
            return base.FieldCheckNotNullDateTime(Value, Res);
        }

        // Check
        public string LogModelOK(LogModel logModel)
        {
            string retStr = FieldCheckNotEmptyAndMaxLengthString(logModel.TableName, ServiceRes.TableName, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(logModel.ID, ServiceRes.Id);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LogCommandOK(logModel.LogCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(logModel.Information, ServiceRes.Information, 1000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillLog(Log log, LogModel logModel, ContactOK contactOK)
        {
            log.LogID = logModel.LogID;
            log.TableName = logModel.TableName;
            log.ID = logModel.ID;
            log.LogCommand = (int)logModel.LogCommand;
            log.Information = logModel.Information;
            log.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                log.LastUpdateContactTVItemID = 2;
            }
            else
            {
                log.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }
            return "";
        }

        // Get
        public int GetLogModelCountDB()
        {
            int logModelCount = (from c in db.Logs
                                 select c).Count();
            return logModelCount;
        }
        public List<LogModel> GetLogModelListWithTableNameAndAfterLastUpdateDate_UTCDB(string TableName, DateTime LastUpdateDate_UTC)
        {
            List<LogModel> logModelList = (from c in db.Logs
                                           where c.TableName == TableName
                                           && c.LastUpdateDate_UTC > LastUpdateDate_UTC
                                           orderby c.LastUpdateDate_UTC descending
                                           select new LogModel
                                           {
                                               Error = "",
                                               LogID = c.LogID,
                                               TableName = c.TableName,
                                               ID = c.ID,
                                               LogCommand = (LogCommandEnum)c.LogCommand,
                                               Information = c.Information,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).ToList<LogModel>();

            return logModelList;
        }
        public List<LogModel> GetLogModelListWithLastUpdateContactTVItemIDAndAfterLastUpdateDate_UTCDB(int LastUpdateContactTVItemID, DateTime LastUpdateDate_UTC)
        {
            List<LogModel> logModelList = (from c in db.Logs
                                           where c.LastUpdateContactTVItemID == LastUpdateContactTVItemID
                                           && c.LastUpdateDate_UTC > LastUpdateDate_UTC
                                           orderby c.LastUpdateDate_UTC descending
                                           select new LogModel
                                           {
                                               Error = "",
                                               LogID = c.LogID,
                                               TableName = c.TableName,
                                               ID = c.ID,
                                               LogCommand = (LogCommandEnum)c.LogCommand,
                                               Information = c.Information,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).ToList<LogModel>();

            return logModelList;
        }
        public LogModel GetLogModelWithLogIDDB(int LogID)
        {
            LogModel logModel = (from c in db.Logs
                                 where c.LogID == LogID
                                 select new LogModel
                                 {
                                     Error = "",
                                     LogID = c.LogID,
                                     TableName = c.TableName,
                                     ID = c.ID,
                                     LogCommand = (LogCommandEnum)c.LogCommand,
                                     Information = c.Information,
                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                 }).FirstOrDefault<LogModel>();

            if (logModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Log, ServiceRes.LogID, LogID));
            }

            return logModel;
        }
        public Log GetLogWithLogIDDB(int LogID)
        {
            Log log = (from c in db.Logs
                       where c.LogID == LogID
                       select c).FirstOrDefault<Log>();
            return log;
        }

        // Helper
        public string GetInformation(object obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties().Where(c => !c.PropertyType.ToString().StartsWith("EdoodiaDBDLL") && !c.PropertyType.ToString().StartsWith("System.Collections")))
            {
                try
                {
                    sb.AppendLine(string.Format("{0}\t{1}",
                        propertyInfo.Name, propertyInfo.GetValue(obj, null)));
                }
                catch (Exception ex)
                {

                   
                }
            }

            return sb.ToString();
        }
        public LogModel ReturnError(string Error)
        {
            return new LogModel() { Error = Error };
        }
        // Post
        public LogModel PostAddLogDB(LogModel logModel)
        {
            string retStr = LogModelOK(logModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
            {
                // hard coded as the second item added to the DB should be the web site administrator
                // right after Root TVItem in TVItems
                contactOK = new ContactOK() { ContactID = 1, ContactTVItemID = 2, Error = "" };
            }

            Log logNew = new Log();
            retStr = FillLog(logNew, logModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Logs.Add(logNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }

            return GetLogModelWithLogIDDB(logNew.LogID);
        }
        public LogModel PostDeleteLogDB(int LogID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Log log = GetLogWithLogIDDB(LogID);
            if (log == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Log, ServiceRes.LogID, LogID.ToString()));

            using (TransactionScope ts = new TransactionScope())
            {
                db.Logs.Remove(log);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }

            return ReturnError("");
        }
        public LogModel PostAddLogForObj(string TableName, int ID, LogCommandEnum LogCommand, object obj)
        {
            LogModel logModelNew = new LogModel()
            {
                TableName = TableName,
                ID = ID,
                LogCommand = LogCommand,
                Information = GetInformation(obj),
            };

            LogModel logModelRet = PostAddLogDB(logModelNew);
            if (!string.IsNullOrWhiteSpace(logModelRet.Error))
                return ReturnError(logModelRet.Error);

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

