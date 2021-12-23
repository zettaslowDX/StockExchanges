﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiStocksLib
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class BestMatch
    {
        [JsonProperty("1. symbol")]
        public string Symbol { get; set; }

        [Display(Name="Nombre")]
        [JsonProperty("2. name")]
        public string Name { get; set; }

        [JsonProperty("3. type")]
        public string Type { get; set; }

        [JsonProperty("4. region")]
        public string Region { get; set; }

        [JsonProperty("5. marketOpen")]
        public string MarketOpen { get; set; }

        [JsonProperty("6. marketClose")]
        public string MarketClose { get; set; }

        [JsonProperty("7. timezone")]
        public string Timezone { get; set; }

        [JsonProperty("8. currency")]
        public string Currency { get; set; }

        [JsonProperty("9. matchScore")]
        public string MatchScore { get; set; }
    }

    public class RootBestMatches
    {
        public List<BestMatch> bestMatches { get; set; }

        [JsonProperty("Error Message")]
        public string Error { get; set; }

        public bool IsError => Error != null;
    }
}
