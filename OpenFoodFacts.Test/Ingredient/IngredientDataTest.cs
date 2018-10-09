using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenFoodFacts.Ingredient;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFoodFacts.Test.Ingredient
{
    [TestClass]
    public class IngredientDataTest
    {
        private JObject completeJsonData;
        private JObject incompleteJsonData;

        [TestInitialize]
        public void Initialization()
        {
            completeJsonData = new JObject();
            completeJsonData["id"] = "a_test_id_42";
            completeJsonData["text"] = "lorem ipsum dolor sit amet";
            incompleteJsonData = new JObject(completeJsonData);
            completeJsonData["rank"] = 42;
            completeJsonData["percent"] = 42.42f;
        }

        [TestMethod]
        public void IngredientDataSerializationTest()
        {
            var complete = new IngredientData
            {
                Id = "a_test_id_42",
                Text = "lorem ipsum dolor sit amet",
                Rank = 42,
                Percent = 42.42f,
            };
            var json = JsonConvert.SerializeObject(complete);
            json.Should().Be(completeJsonData.ToString(Formatting.None));

            var incomplete = new IngredientData
            {
                Id = "a_test_id_42",
                Text = "lorem ipsum dolor sit amet",
            };
            json = JsonConvert.SerializeObject(incomplete);
            var incompleteJsonStr = incompleteJsonData.ToString(Formatting.None);
            var i = incompleteJsonStr.LastIndexOf('}');
            incompleteJsonStr = incompleteJsonStr.Remove(i, 1);
            json.StartsWith(incompleteJsonStr).Should().Be(true);
        }

        [TestMethod]
        public void IngredientDataDeserializationTest()
        {
            var obj = JsonConvert.DeserializeObject<IngredientData>(completeJsonData.ToString());
            obj.Id.Should().Be(completeJsonData["id"].ToString());
            obj.Text.Should().Be(completeJsonData["text"].ToString());
            obj.Rank.Should().Be(completeJsonData["rank"].ToObject<int>());
            obj.Percent.Should().Be(completeJsonData["percent"].ToObject<float>());

            obj = JsonConvert.DeserializeObject<IngredientData>(incompleteJsonData.ToString());
            obj.Id.Should().Be(completeJsonData["id"].ToString());
            obj.Text.Should().Be(completeJsonData["text"].ToString());
            obj.Rank.Should().BeNull();
            obj.Percent.Should().BeNull();
        }
    }
}
