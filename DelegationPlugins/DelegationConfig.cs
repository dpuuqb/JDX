using System.Runtime.Serialization;
namespace DelegationPlugins
{

    [DataContract]
    public class DelegationConfig
    {
        [DataMember]
        public string ProcessLog;

        [DataMember]
        public string Teams;

    }
}
