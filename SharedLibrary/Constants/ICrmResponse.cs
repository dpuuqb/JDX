using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Constants
{
    public interface ICrmResponse{}

    internal class CreateOutputParameters : ICrmResponse
    {
        internal Guid Id;
    }

    internal class UpdateOutputParameters : ICrmResponse { }

    internal class DeleteOutputParameters : ICrmResponse { }

    internal class RetrieveOutputParameters : ICrmResponse
    {
        internal Entity Entity;
    }

    internal class RetrieveMultipleOutputParameters : ICrmResponse
    {
        internal EntityCollection EntityCollection;
    }

    internal class AssociateOutputParameters : ICrmResponse { }

    internal class DisassociateOutputParameters : ICrmResponse { }

    internal class SetStateOutputParameters : ICrmResponse { }
}
