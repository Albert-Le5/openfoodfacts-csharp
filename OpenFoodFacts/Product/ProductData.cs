using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenFoodFacts.Ingredient;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFoodFacts.Product
{
    [JsonObject()]
    public class ProductData
    {
        #region IDs
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        #endregion IDs

        #region Brands
        [JsonProperty(PropertyName = "Brands")]
        public string Brands { get; set; }
        [JsonProperty(PropertyName = "brands_tags")]
        public List<string> BrandsTags { get; set; }
        #endregion Brands

        #region Names
        [JsonProperty(PropertyName = "generic_name")]
        public string GenericName { get; set; }
        [JsonProperty(PropertyName = "generic_name_en")]
        public string GenericNameEn { get; set; }
        #endregion Names

        #region  TimeStamps 
        [JsonProperty(PropertyName = "created_t")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedTime { get; set; }
        [JsonProperty(PropertyName = "last_image_t")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastImageTime { get; set; }
        [JsonProperty(PropertyName = "last_modified_t")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastModifiedTime { get; set; }
        [JsonProperty(PropertyName = "completed_t")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CompletedTime { get; set; }
        #endregion Timestamps

        #region URLs
        [JsonProperty(PropertyName = "image_front_smallURL")]
        public string ImageFrontSmallURL { get; set; }
        [JsonProperty(PropertyName = "image_front_thumb_url")]
        public string ImageFrontThumbURL { get; set; }
        [JsonProperty(PropertyName = "image_front_url")]
        public string ImageFrontURL { get; set; }
        [JsonProperty(PropertyName = "image_ingredients_small_url")]
        public string ImageIngredientsSmallURL { get; set; }
        [JsonProperty(PropertyName = "image_ingredients_thumb_url")]
        public string ImageIngredientsThumbURL { get; set; }
        [JsonProperty(PropertyName = "image_ingredients_url")]
        public string ImageIngredientsURL { get; set; }
        [JsonProperty(PropertyName = "image_nutrition_small_url")]
        public string ImageNutritionSmallURL { get; set; }
        [JsonProperty(PropertyName = "image_nutrition_thumb_url")]
        public string ImageNutritionThumbURL { get; set; }
        [JsonProperty(PropertyName = "image_nutrition_url")]
        public string ImageNutritionURL { get; set; }
        [JsonProperty(PropertyName = "image_small_url")]
        public string ImageSmallURL { get; set; }
        [JsonProperty(PropertyName = "image_thumb_url")]
        public string ImageThumbURL { get; set; }
        [JsonProperty(PropertyName = "image_url")]
        public string ImageURL { get; set; }
        #endregion
       
        #region Contributors
        [JsonProperty(PropertyName = "creator")]
        public string Creator { get; set; }
        [JsonProperty(PropertyName = "checkers")]
        public List<string> Checkers { get; set; }
        [JsonProperty(PropertyName = "checkers_tags")]
        public List<string> CheckersTags { get; set; }
        [JsonProperty(PropertyName = "editors")]
        public List<string> Editors { get; set; }
        [JsonProperty(PropertyName = "editors_tags")]
        public List<string> EditorsTags { get; set; }
        [JsonProperty(PropertyName = "correctors")]
        public List<string> Correctors { get; set; }
        [JsonProperty(PropertyName = "correctors_tags")]
        public List<string> CorrectorsTags { get; set; }
        [JsonProperty(PropertyName = "informers")]
        public List<string> Informers { get; set; }
        [JsonProperty(PropertyName = "informers_tags")]
        public List<string> InformersTags { get; set; }
        [JsonProperty(PropertyName = "photographers")]
        public List<string> Photographers { get; set; }
        [JsonProperty(PropertyName = "photographers_tags")]
        public List<string> PhotographersTags { get; set; }
        [JsonProperty(PropertyName = "last_edit_dates_tags")]
        public List<string> LastEditDatesTags { get; set; }
        [JsonProperty(PropertyName = "last_editor")]
        public string LastEditor { get; set; }
        [JsonProperty(PropertyName = "last_image_dates_tags")]
        public List<string> LastImageDatesTags { get; set; }
        [JsonProperty(PropertyName = "last_modified_by")]
        public string LastModifiedBy { get; set; }
        #endregion Contributors
        
        #region Additives
        [JsonProperty(PropertyName = "additives")]
        public string Additives { get; set; }
        [JsonProperty(PropertyName = "additives_debug_tags")]
        public List<string> AdditivesDebugTags { get; set; }
        [JsonProperty(PropertyName = "additives_n")]
        public int AdditivesNumber { get; set; }
        [JsonProperty(PropertyName = "additives_old_n")]
        public int AdditivesOldNumber { get; set; }
        [JsonProperty(PropertyName = "additives_old_tags")]
        public List<string> AdditivesOldTags { get; set; }
        [JsonProperty(PropertyName = "additives_prev")]
        public string AdditivesPrev { get; set; }
        [JsonProperty(PropertyName = "additives_prev_n")]
        public int AdditivesPrevNumber { get; set; }
        [JsonProperty(PropertyName = "additives_prev_tags")]
        public List<string> AdditivesPrevTags { get; set; }
        [JsonProperty(PropertyName = "additives_tags")]
        public List<string> AdditivesTags { get; set; }
        [JsonProperty(PropertyName = "additives_tags_n")]
        public List<string> AdditivesTagsNumber { get; set; }
        #endregion Additives
        
        #region Allergens
        [JsonProperty(PropertyName = "allergens")]
        public string Allergens { get; set; }
        [JsonProperty(PropertyName = "allergens_hierarchy")]
        public List<string> AllergensHierarchy { get; set; }
        [JsonProperty(PropertyName = "allergens_tags")]
        public List<string> AllergensTags { get; set; }
        #endregion Allergens
        
        #region Categories
        [JsonProperty(PropertyName = "categories")]
        public string Categories { get; set; }
        [JsonProperty(PropertyName = "categories_debug_tags")]
        public List<string> CategoriesDebugTags { get; set; }
        [JsonProperty(PropertyName = "categories_hierarchy")]
        public List<string> CategoriesHierarchy { get; set; }
        [JsonProperty(PropertyName = "categories_prev_hierarchy")]
        public List<string> CategoriesPrevHierarchy { get; set; }
        [JsonProperty(PropertyName = "categories_prev_tags")]
        public List<string> CategoriesPrevTags { get; set; }
        [JsonProperty(PropertyName = "categories_tags")]
        public List<string> CategoriesTags { get; set; }
        #endregion Categories
        
        #region Misc
        [JsonProperty(PropertyName = "cities_tags")]
        public List<string> CitiesTags { get; set; }
        [JsonProperty(PropertyName = "codes_tags")]
        public List<string> CodesTags { get; set; }
        [JsonProperty(PropertyName = "complete")]
        public int Complete { get; set; }
        [JsonProperty(PropertyName = "countries")]
        public string Countries { get; set; }
        [JsonProperty(PropertyName = "countries_hierarchy")]
        public List<string> CountriesHierarchy { get; set; }
        [JsonProperty(PropertyName = "countries_tags")]
        public List<string> CountriesTags { get; set; }
        [JsonProperty(PropertyName = "emb_codes")]
        public string EmbCodes { get; set; }
        [JsonProperty(PropertyName = "emb_codes_20141016")]
        public string EmbCodes20141016 { get; set; }
        [JsonProperty(PropertyName = "emb_codes_orig")]
        public string EmbCodesOrig { get; set; }
        [JsonProperty(PropertyName = "emb_codes_tags")]
        public List<string> EmbCodesTags { get; set; }
        [JsonProperty(PropertyName = "entry_dates_tags")]
        public List<string> EntryDatesTags { get; set; }
        [JsonProperty(PropertyName = "expiration_date")]
        public string ExpirationDate { get; set; }
        #endregion Misc
        
        #region Ingredients
        [JsonProperty(PropertyName = "fruits-vegetables-nuts_100g_estimate")]
        public float FruitsVegetablesNuts100GEstimate { get; set; }
        [JsonProperty(PropertyName = "ingredients")]
        public List<IngredientData> Ingredients { get; set; }
        [JsonProperty(PropertyName = "ingredients_debug")]
        public List<string> IngredientsDebug { get; set; }
        [JsonProperty(PropertyName = "ingredients_from_or_that_may_be_from_palm_oil_n")]
        public int IngredientsFromOrThatMayBeFromPalmOilNumber { get; set; }
        [JsonProperty(PropertyName = "ingredients_from_palm_oil_n")]
        public int IngredientsFromPalmOilNumber { get; set; }
        [JsonProperty(PropertyName = "ingredients_from_palm_oil_tags")]
        public List<string> IngredientsFromPalmOilTags { get; set; }
        [JsonProperty(PropertyName = "ingredients_ids_debug")]
        public List<string> IngredientsIdsDebug { get; set; }
        [JsonProperty(PropertyName = "ingredients_n")]
        public string IngredientsN { get; set; }
        [JsonProperty(PropertyName = "ingredients_n_tags")]
        public List<string> IngredientsNTags { get; set; }
        [JsonProperty(PropertyName = "ingredients_tags")]
        public List<string> IngredientsTags { get; set; }
        [JsonProperty(PropertyName = "ingredients_text")]
        public string IngredientsText { get; set; }
        [JsonProperty(PropertyName = "ingredients_text_debug")]
        public string IngredientsTextDebug { get; set; }
        [JsonProperty(PropertyName = "ingredients_text_en")]
        public string IngredientsTextEn { get; set; }
        [JsonProperty(PropertyName = "ingredients_text_with_allergens")]
        public string IngredientsTextWithAllergens { get; set; }
        [JsonProperty(PropertyName = "ingredients_text_with_allergens_en")]
        public string IngredientsTextWithAllergensEn { get; set; }
        [JsonProperty(PropertyName = "ingredients_that_may_be_from_palm_oil_n")]
        public int IngredientsThatMayBeFromPalmOilNumber { get; set; }
        [JsonProperty(PropertyName = "ingredients_that_may_be_from_palm_oil_tags")]
        public List<string> IngredientsThatMayBeFromPalmOilTags { get; set; }
        [JsonProperty(PropertyName = "traces")]
        public string Traces { get; set; }
        [JsonProperty(PropertyName = "traces_hierarchy")]
        public List<string> TracesHierarchy { get; set; }
        [JsonProperty(PropertyName = "traces_tags")]
        public List<string> TracesTags { get; set; }
        #endregion Ingredients

        #region API
        [JsonProperty(PropertyName = "interface_version_created")]
        public string InterfaceVersionCreated { get; set; }
        [JsonProperty(PropertyName = "interface_version_modified")]
        public string InterfaceVersionModified { get; set; }
        [JsonProperty(PropertyName = "_keywords")]
        public List<string> Keywords { get; set; }
        [JsonProperty(PropertyName = "labels")]
        public string Labels { get; set; }
        [JsonProperty(PropertyName = "labels_debug_tags")]
        public List<string> LabelsDebugTags { get; set; }
        [JsonProperty(PropertyName = "labels_hierarchy")]
        public List<string> LabelsHierarchy { get; set; }
        [JsonProperty(PropertyName = "labels_prev_hierarchy")]
        public List<string> LabelsPrevHierarchy { get; set; }
        [JsonProperty(PropertyName = "labels_prev_tags")]
        public List<string> LabelsPrevTags { get; set; }
        [JsonProperty(PropertyName = "labels_tags")]
        public List<string> LabelsTags { get; set; }
        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }
        [JsonProperty(PropertyName = "languages")]
        public Dictionary<string, int> Languages { get; set; }
        [JsonProperty(PropertyName = "languages_codes")]
        public Dictionary<string, int> LanguagesCodes { get; set; }
        [JsonProperty(PropertyName = "languages_hierarchy")]
        public List<string> LanguagesHierarchy { get; set; }
        [JsonProperty(PropertyName = "languages_tags")]
        public List<string> LanguagesTags { get; set; }
        [JsonProperty(PropertyName = "lc")]
        public string Locale { get; set; }
        [JsonProperty(PropertyName = "max_imgid")]
        public string MaxImgId { get; set; }
        #endregion API
    
        #region Nutrients
        [JsonProperty(PropertyName = "new_additives_n")]
        public int NewAdditivesNumber { get; set; }
        [JsonProperty(PropertyName = "no_nutrition_data")]
        public string NoNutritionData { get; set; }
        [JsonProperty(PropertyName = "nutrient_levels")]
        public Dictionary<string, string> NutrientLevels { get; set; }
        [JsonProperty(PropertyName = "nutrient_levels_tags")]
        public List<string> NutrientLevelsTags { get; set; }
        [JsonProperty(PropertyName = "nutriments")]
        public Dictionary<string, string> Nutriments { get; set; }
        [JsonProperty(PropertyName = "nutrition_data_per")]
        public string NutritionDataPer { get; set; }
        [JsonProperty(PropertyName = "nutrition_grade_fr")]
        public string NutritionGradeFr { get; set; }
        [JsonProperty(PropertyName = "nutrition_grades")]
        public string NutritionGrades { get; set; }
        [JsonProperty(PropertyName = "nutrition_grades_tags")]
        public List<string> NutritionGradesTags { get; set; }
        [JsonProperty(PropertyName = "nutrition_score_debug")]
        public string NutritionScoreDebug { get; set; }
        #endregion Nutrients
    
        #region Product details
        [JsonProperty(PropertyName = "origins_tags")]
        public List<string> OriginTags { get; set; }
        [JsonProperty(PropertyName = "origins")]
        public string Origins { get; set; }
        [JsonProperty(PropertyName = "packaging")]
        public string Packaging { get; set; }
        [JsonProperty(PropertyName = "packaging_tags")]
        public List<string> PackagingTags { get; set; }
        [JsonProperty(PropertyName = "pnns_groups_1")]
        public string PnnsGroups1 { get; set; }
        [JsonProperty(PropertyName = "pnns_groups_1_tags")]
        public List<string> PnnsGroups1Tags { get; set; }
        [JsonProperty(PropertyName = "pnns_groups_2")]
        public string PnnsGroups2 { get; set; }
        [JsonProperty(PropertyName = "pnns_groups_2_tags")]
        public List<string> PnnsGroups2Tags { get; set; }
        [JsonProperty(PropertyName = "product_name")]
        public string ProductName { get; set; }
        [JsonProperty(PropertyName = "product_name_en")]
        public string ProductNameEn { get; set; }
        [JsonProperty(PropertyName = "purchase_places")]
        public string PurchasePlaces { get; set; }
        [JsonProperty(PropertyName = "purchase_places_tags")]
        public List<string> PurchasePlacesTags { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public string Quantity { get; set; }
        [JsonProperty(PropertyName = "rev")]
        public int Rev { get; set; }
        [JsonProperty(PropertyName = "scans_n")]
        public int ScansNumber { get; set; }
        [JsonProperty(PropertyName = "serving_quantity")]
        public float ServingQuantity { get; set; }
        [JsonProperty(PropertyName = "serving_size")]
        public string ServingSize { get; set; }
        [JsonProperty(PropertyName = "sortkey")]
        public int SortKey { get; set; }
        [JsonProperty(PropertyName = "states")]
        public string States { get; set; }
        [JsonProperty(PropertyName = "states_hierarchy")]
        public List<string> StatesHierarchy { get; set; }
        [JsonProperty(PropertyName = "states_tags")]
        public List<string> StatesTags { get; set; }
        [JsonProperty(PropertyName = "stores")]
        public string Stores { get; set; }
        [JsonProperty(PropertyName = "stores_tags")]
        public List<string> StoresTags { get; set; }
        [JsonProperty(PropertyName = "unique_scans_n")]
        public int UniqueScansNumber { get; set; }
        [JsonProperty(PropertyName = "unknown_nutrients_tags")]
        public List<string> UnknownNutrientsTags { get; set; }
        [JsonProperty(PropertyName = "update_key")]
        public string UpdateKey { get; set; }
        #endregion Product details
    
    }
}
