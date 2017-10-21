// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.Paladins.Models
{
    using Newtonsoft.Json;
    using System.Linq;
    using HiRezApi.Common.Models;

    public partial class Champions : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Champions class.
        /// </summary>
        public Champions()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Champions class.
        /// </summary>
        public Champions(string retMsg, string ability1 = default(string), string ability2 = default(string), string ability3 = default(string), string ability4 = default(string), string ability5 = default(string), int abilityId1 = default(int), int abilityId2 = default(int), int abilityId3 = default(int), int abilityId4 = default(int), int abilityId5 = default(int), Ability ability1Def = default(Ability), Ability ability2Def = default(Ability), Ability ability3Def = default(Ability), Ability ability4Def = default(Ability), Ability ability5Def = default(Ability), string championAbility1URL = default(string), string championAbility2URL = default(string), string championAbility3URL = default(string), string championAbility4URL = default(string), string championAbility5URL = default(string), string championCardURL = default(string), string championIconURL = default(string), string cons = default(string), int health = default(int), string lore = default(string), string name = default(string), string onFreeRotation = default(string), string pantheon = default(string), string pros = default(string), string roles = default(string), int speed = default(int), string title = default(string), string type = default(string), string abilityDescription1 = default(string), string abilityDescription2 = default(string), string abilityDescription3 = default(string), string abilityDescription4 = default(string), string abilityDescription5 = default(string), int id = default(int), string latestChampion = default(string))
            : base(retMsg)
        {
            Ability1 = ability1;
            Ability2 = ability2;
            Ability3 = ability3;
            Ability4 = ability4;
            Ability5 = ability5;
            AbilityId1 = abilityId1;
            AbilityId2 = abilityId2;
            AbilityId3 = abilityId3;
            AbilityId4 = abilityId4;
            AbilityId5 = abilityId5;
            Ability1Def = ability1Def;
            Ability2Def = ability2Def;
            Ability3Def = ability3Def;
            Ability4Def = ability4Def;
            Ability5Def = ability5Def;
            ChampionAbility1URL = championAbility1URL;
            ChampionAbility2URL = championAbility2URL;
            ChampionAbility3URL = championAbility3URL;
            ChampionAbility4URL = championAbility4URL;
            ChampionAbility5URL = championAbility5URL;
            ChampionCardURL = championCardURL;
            ChampionIconURL = championIconURL;
            Cons = cons;
            Health = health;
            Lore = lore;
            Name = name;
            OnFreeRotation = onFreeRotation;
            Pantheon = pantheon;
            Pros = pros;
            Roles = roles;
            Speed = speed;
            Title = title;
            Type = type;
            AbilityDescription1 = abilityDescription1;
            AbilityDescription2 = abilityDescription2;
            AbilityDescription3 = abilityDescription3;
            AbilityDescription4 = abilityDescription4;
            AbilityDescription5 = abilityDescription5;
            Id = id;
            LatestChampion = latestChampion;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability1")]
        public string Ability1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability2")]
        public string Ability2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability3")]
        public string Ability3 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability4")]
        public string Ability4 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability5")]
        public string Ability5 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AbilityId1")]
        public int AbilityId1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AbilityId2")]
        public int AbilityId2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AbilityId3")]
        public int AbilityId3 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AbilityId4")]
        public int AbilityId4 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AbilityId5")]
        public int AbilityId5 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability_1")]
        public Ability Ability1Def { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability_2")]
        public Ability Ability2Def { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability_3")]
        public Ability Ability3Def { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability_4")]
        public Ability Ability4Def { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ability_5")]
        public Ability Ability5Def { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChampionAbility1_URL")]
        public string ChampionAbility1URL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChampionAbility2_URL")]
        public string ChampionAbility2URL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChampionAbility3_URL")]
        public string ChampionAbility3URL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChampionAbility4_URL")]
        public string ChampionAbility4URL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChampionAbility5_URL")]
        public string ChampionAbility5URL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChampionCard_URL")]
        public string ChampionCardURL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ChampionIcon_URL")]
        public string ChampionIconURL { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Cons")]
        public string Cons { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Health")]
        public int Health { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Lore")]
        public string Lore { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OnFreeRotation")]
        public string OnFreeRotation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Pantheon")]
        public string Pantheon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Pros")]
        public string Pros { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Roles")]
        public string Roles { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Speed")]
        public int Speed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abilityDescription1")]
        public string AbilityDescription1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abilityDescription2")]
        public string AbilityDescription2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abilityDescription3")]
        public string AbilityDescription3 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abilityDescription4")]
        public string AbilityDescription4 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abilityDescription5")]
        public string AbilityDescription5 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "latestChampion")]
        public string LatestChampion { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}