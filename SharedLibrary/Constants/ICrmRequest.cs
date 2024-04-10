using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Constants
{
    public interface ICrmRequest{}
    internal class CreateInputParameters : ICrmRequest
    {
        internal Entity Target;
    }
    internal class UpdateInputParameters : ICrmRequest
    {
        internal Entity Target;
    }
    internal class DeleteInputParameters : ICrmRequest
    {
        internal EntityReference Target;
    }
    internal class RetrieveInputParameters : ICrmRequest
    {
        internal EntityReference Target;
        internal ColumnSet ColumnSet;
        internal RelationshipQueryCollection RelatedEntitiesQuery;
    }
    internal class RetrieveMultipleInputParameters : ICrmRequest
    {
        internal QueryBase Query;
    }

    internal class AssociateInputParameters : ICrmRequest
    {
        internal EntityReference Target;
        internal Relationship Relationship;
        internal EntityReferenceCollection RelatedEntities;
    }
    internal class DisassociateInputParameters : ICrmRequest
    {
        internal EntityReference Target;
        internal Relationship Relationship;
        internal EntityReferenceCollection RelatedEntities;
    }

    internal class SetStateInputParameters : ICrmRequest
    {
        internal EntityReference EntityMoniker;
        internal OptionSetValue State;
        internal OptionSetValue Status;
    }

}
