using DelegationPlugins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationPluginUnitTest
{
    public class DataBuilder: FakeXrmEasyPipelineTestsBase
    {

        public void IntialTextData()
        {
            DelegationReassignConfiguration config = new DelegationReassignConfiguration() { 
                EntityName = "jms_delegationtest"
            };
        }
    }
}
