// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.Common.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Player : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        public Player()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        public Player(string retMsg, string createdDatetime = default(string), int id = default(int), string lastLoginDatetime = default(string), int leaves = default(int), int level = default(int), int losses = default(int), int masteryLevel = default(int), string name = default(string), string personalStatusMessage = default(string), RankedConquest rankedConquest = default(RankedConquest), string region = default(string), int teamId = default(int), string teamName = default(string), int tierConquest = default(int), int totalAchievements = default(int), int totalWorshippers = default(int), int wins = default(int))
            : base(retMsg)
        {
            CreatedDatetime = createdDatetime;
            Id = id;
            LastLoginDatetime = lastLoginDatetime;
            Leaves = leaves;
            Level = level;
            Losses = losses;
            MasteryLevel = masteryLevel;
            Name = name;
            PersonalStatusMessage = personalStatusMessage;
            RankedConquest = rankedConquest;
            Region = region;
            TeamId = teamId;
            TeamName = teamName;
            TierConquest = tierConquest;
            TotalAchievements = totalAchievements;
            TotalWorshippers = totalWorshippers;
            Wins = wins;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Created_Datetime")]
        public string CreatedDatetime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Last_Login_Datetime")]
        public string LastLoginDatetime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Leaves")]
        public int Leaves { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Level")]
        public int Level { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Losses")]
        public int Losses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MasteryLevel")]
        public int MasteryLevel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Personal_Status_Message")]
        public string PersonalStatusMessage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RankedConquest")]
        public RankedConquest RankedConquest { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Region")]
        public string Region { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TeamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Team_Name")]
        public string TeamName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Tier_Conquest")]
        public int TierConquest { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Total_Achievements")]
        public int TotalAchievements { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Total_Worshippers")]
        public int TotalWorshippers { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Wins")]
        public int Wins { get; set; }

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