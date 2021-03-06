// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.RealmRoyale.Models
{
    using System;
    using HiRezApi.Common.Models;

    public partial class Match
    {
        /// <summary>
        /// Initializes a new instance of the Match class.
        /// </summary>
        public Match()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Match class.
        /// </summary>
        public Match(int assists = default(int), int classId = default(int), string className = default(string), int creeps = default(int), int damage = default(int), int damageDoneInHand = default(int), int damageMitigated = default(int), int damageTaken = default(int), int deaths = default(int), int gold = default(int), double healingBot = default(int), double healingPlayer = default(int), double healingPlayerSelf = default(int), int killingSpreeMax = default(int), int kills = default(int), string mapGame = default(string), DateTime dateTime = default(DateTime), int durationSecs = default(int), int id = default(int), int queueId = default(int), string queueName = default(string), int placement = default(int), int playerId = default(int), string region = default(string), int teamId = default(int), int timeInMatchMinutes = default(int), int timeInMatchSecs = default(int), int wardsMinesPlaced = default(int))
        {
            Assists = assists;
            ClassId = classId;
            ClassName = className;
            Creeps = creeps;
            Damage = damage;
            DamageDoneInHand = damageDoneInHand;
            DamageMitigated = damageMitigated;
            DamageTaken = damageTaken;
            Deaths = deaths;
            Gold = gold;
            HealingBot = healingBot;
            HealingPlayer = healingPlayer;
            HealingPlayerSelf = healingPlayerSelf;
            KillingSpreeMax = killingSpreeMax;
            Kills = kills;
            MapGame = mapGame;
            DateTime = dateTime;
            DurationSecs = durationSecs;
            Id = id;
            QueueId = queueId;
            QueueName = queueName;
            Placement = placement;
            PlayerId = playerId;
            Region = region;
            TeamId = teamId;
            TimeInMatchMinutes = timeInMatchMinutes;
            TimeInMatchSecs = timeInMatchSecs;
            WardsMinesPlaced = wardsMinesPlaced;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "assists")]
        public int Assists { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "class_id")]
        public int ClassId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "class_name")]
        public string ClassName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "creeps")]
        public int Creeps { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "damage")]
        public int Damage { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "damage_done_in_hand")]
        public int DamageDoneInHand { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "damage_mitigated")]
        public int DamageMitigated { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "damage_taken")]
        public int DamageTaken { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "deaths")]
        public int Deaths { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "gold")]
        public int Gold { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "healing_bot")]
        public double HealingBot { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "healing_player")]
        public double HealingPlayer { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "healing_player_self")]
        public double HealingPlayerSelf { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "killing_spree_max")]
        public int KillingSpreeMax { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "kills")]
        public int Kills { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "map_game")]
        public string MapGame { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_datetime")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_duration_secs")]
        public int DurationSecs { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_queue_id")]
        public int QueueId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_queue_name")]
        public string QueueName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "placement")]
        public int Placement { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "player_id")]
        public int PlayerId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "team_id")]
        public int TeamId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "time_in_match_minutes")]
        public int TimeInMatchMinutes { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "time_in_match_secs")]
        public int TimeInMatchSecs { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "wards_mines_placed")]
        public int WardsMinesPlaced { get; set; }
    }
}
