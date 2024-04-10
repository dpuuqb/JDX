using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DelegationPlugins
{
    [DataContract]
    internal class DelegationConfig
    {
        [DataMember]
        public string ProcessLog;

        [DataMember]
        public string Teams;

        [DataMember]
        public string Roles;

    }
}
