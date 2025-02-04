﻿using Newtonsoft.Json;

namespace GetAddress
{
    public class AddWebhook
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class AddSuggestLimitReachedWebhook : AddWebhook
    {

    }

    public class AddTrackWebhook : AddWebhook
    {

    }

    public class AddExpiredWebhook : AddWebhook
    {

    }

    public class AddDailyLimitReachedWebhook: AddWebhook
    {

    }
    public class AddMonthlyReserveReachedWebhook : AddWebhook
    {

    }

    public class AddPaymentFailedWebhook : AddWebhook
    {

    }
}
