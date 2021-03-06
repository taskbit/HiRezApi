// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace HiRezApi.RealmRoyale.Models
{
    using System;
    using HiRezApi.Common.Models;

    public partial class MatchDetails : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the MatchDetails class.
        /// </summary>
        public MatchDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MatchDetails class.
        /// </summary>
        public MatchDetails(string retMsg, int durationSecs = default(int), DateTime matchDatetime = default(DateTime), int matchId = default(int), int matchQueueId = default(int), string matchQueueName = default(string), string region = default(string), System.Collections.Generic.IList<Team> teams = default(System.Collections.Generic.IList<Team>))
            : base(retMsg)
        {
            DurationSecs = durationSecs;
            MatchDatetime = matchDatetime;
            MatchId = matchId;
            MatchQueueId = matchQueueId;
            MatchQueueName = matchQueueName;
            Region = region;
            Teams = teams;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "duration_secs")]
        public int DurationSecs { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_datetime")]
        public DateTime MatchDatetime { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_id")]
        public int MatchId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_queue_id")]
        public int MatchQueueId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "match_queue_name")]
        public string MatchQueueName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "teams")]
        public System.Collections.Generic.IList<Team> Teams { get; set; }

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
