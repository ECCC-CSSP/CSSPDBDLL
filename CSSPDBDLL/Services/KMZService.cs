using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class KMZService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public PolSourceSiteService _PolSourceSiteService { get; private set; }
        public InfrastructureService _InfrastructureService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }

        #endregion Properties

        #region Constructors
        public KMZService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _PolSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            _InfrastructureService = new InfrastructureService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        public string GetKML(int TVItemID)
        {
            return "";
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
