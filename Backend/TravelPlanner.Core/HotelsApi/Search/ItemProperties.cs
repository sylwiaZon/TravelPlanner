﻿using Newtonsoft.Json;

namespace TravelPlanner.Core.HotelsApi.Search
{
    public class ItemProperties
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("entities")]
        public ItemEntities[] Entities { get; set; }
    }
}
