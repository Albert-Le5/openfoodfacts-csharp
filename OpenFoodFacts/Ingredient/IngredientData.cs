using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFoodFacts.Ingredient
{
    [JsonObject()]
    public class IngredientData
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "rank")]
        public int? Rank { get; set; }
        [JsonProperty(PropertyName = "percent")]
        public float? Percent { get; set; }
    }
}
