﻿using System.Collections.Generic;
using Wr.Umbraco.CampaignPhoneManager.Models;
using Wr.Umbraco.CampaignPhoneManager.Providers.Storage;
using static Wr.Umbraco.CampaignPhoneManager.Helpers.ENums;

namespace Wr.Umbraco.CampaignPhoneManager.Criteria
{
    public class ReferrerCriteria : ICampaignPhoneManagerCriteria
    {
        //private IRepository _repository;
        private readonly CriteriaParameterHolder _criteriaParameters;

        public ReferrerCriteria () { }

        /*public ReferrerCriteria(CriteriaParameterHolder criteriaParameters)
        {
            _criteriaParameters = criteriaParameters;
            _repository = new XPathRepository();
        }

        public ReferrerCriteria(CriteriaParameterHolder criteriaParameters, IRepository repository)
        {
            _criteriaParameters = criteriaParameters;
            _repository = repository;
        }*/

        public List<CampaignDetail> GetMatchingRecordsFromPhoneManager(CriteriaParameterHolder _criteriaParameters, IRepository _repository)
        {
            var safeReferrer = _criteriaParameters.RequestInfo_NotIncludingQueryStrings.Referrer.ToSafeString(ProviderType.Referrer);
            if (!string.IsNullOrEmpty(safeReferrer))
            {
                return _repository.GetMatchingCriteriaRecords_Referrer(AppConstants.UmbracoDocTypeAliases.CampaignPhoneManagerModel_CampaignDetail.Referrer, safeReferrer);
            }

            return new List<CampaignDetail>();
        }
    }
}