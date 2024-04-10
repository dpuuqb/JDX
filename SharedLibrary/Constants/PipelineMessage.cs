using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Constants
{
    internal class PipelineMessage
    {
        public const string Create = "Create";
        public const string Retrieve = "Retrieve";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string RetrieveMultiple = "RetrieveMultiple";
        public const string Associate = "Associate";
        public const string Disassociate = "Disassociate";
        public const string SetState = "SetState";
    }
}
