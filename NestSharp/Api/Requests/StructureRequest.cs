using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NestSharp.Api.Requests
{
    public class StructureRequest
    {
        /// <summary>
        /// Gets or sets the unique structure identifier
        /// </summary>
        [JsonIgnore]
        public string StructureId { get; set; }

        /// <summary>
        /// Gets or sets the structure state
        /// </summary>
        [JsonProperty("away")]
        internal string AwayString { get; set; }

        /// <summary>
        /// Gets the structure state
        /// </summary>
        [JsonIgnore]
        public AwayState? Away
        {
            get
            {
                switch (AwayString)
                {
                    case "away":
                        return AwayState.Away;
                    case "auto-away":
                        return AwayState.AutoAway;
                    case "home":
                    default:
                        return AwayState.Home;
                }
            }
            set
            {
                switch (value)
                {
                    case AwayState.Away:
                        AwayString = "away";
                        break;
                    case AwayState.AutoAway:
                        AwayString = "auto-away";
                        break;
                    case AwayState.Home:
                    default:
                        AwayString = "home";
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the estimated arrival window
        /// </summary>
        public Eta Eta { get; set; }
    }
}
