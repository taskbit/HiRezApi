// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HiRezApi.Common.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Session : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Session class.
        /// </summary>
        public Session()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Session class.
        /// </summary>
        public Session(string retMsg, string sessionId = default(string), string timestamp = default(string))
            : base(retMsg)
        {
            SessionId = sessionId;
            Timestamp = timestamp;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

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
