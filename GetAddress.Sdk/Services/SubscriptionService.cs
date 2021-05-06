﻿using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class SubscriptionService : AdministrationService
    {
        private const string path = "v2/subscription";
        public SubscriptionService(string administrationKey, HttpClient httpClient = null) : base(administrationKey, httpClient)
        {

        }

        public async Task<Result<Subscription>> Get(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var requestUri = GetUri(path);

            var response = await HttpGet(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<Subscription>();
        }

        public async Task<Result<SuccessfulUnsubscribe>> Unsubscribe(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", "2020-09-09");

            var requestUri = GetUri(path, nameValueCollection: nameValues);

            var response = await HttpPut(requestUri, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            var result = await response.ToResult<SuccessfulUnsubscribe>();

            return result;
        }

        public async Task<Result<SuccessfulChangePlan>> ChangePlan(ChangePlanRequest request, AccessToken accessToken = default, 
            CancellationToken cancellationToken = default)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", "2020-09-09");

            var fullPath = path + "subscription/change-plan";

            var requestUri = GetUri(fullPath, nameValueCollection: nameValues);

            var content = request.ToHttpContent();

            var response = await HttpPut(requestUri, httpContent: content, administrationOrApiKey: AdministrationKey,
                token: accessToken, cancellationToken: cancellationToken);

            var result = await response.ToResult<SuccessfulChangePlan>();

            return result;
        }

    }
}
