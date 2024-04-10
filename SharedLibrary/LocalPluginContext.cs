using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;
using SharedLibrary.Constants;


namespace SharedLibrary
{
    public class LocalPluginContext:IDisposable
    {
        public IServiceProvider ServiceProvider
        {
            get;
        }

        public IOrganizationService OrganizationService
        {
            get;
        }

        public OrganizationServiceContext OrganizationDataContext
        {
            get;

            private set;
        }

        public IPluginExecutionContext PluginExecutionContext
        {
            get;
        }

        public ITracingService TracingService
        {
            get;
        }

        public LocalPluginContext(IServiceProvider serviceProvider)
        {
            // Validate ServiceProvider
            ServiceProvider = serviceProvider ?? throw new ArgumentException(nameof(serviceProvider));
            // Obtain the execution context service from the service provider.
            PluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            // Obtain the tracing service from the service provider.
            TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            // Obtain the Organization Service factory service from the service provider
            var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            // Use the factory to generate the Organization Service.
            OrganizationService = factory.CreateOrganizationService(PluginExecutionContext.UserId);
            // Generate the Organization Data Context
            OrganizationDataContext = new OrganizationServiceContext(OrganizationService);
        }

        public Entity PreImage
        {
            get{ try{ return PluginExecutionContext.PreEntityImages.Values.First(); }catch{ throw new InvalidPluginExecutionException("Pre Image Not Found"); } }
        }
        public Entity PostImage
        {
            get { try { return PluginExecutionContext.PostEntityImages.Values.First(); } catch { throw new InvalidPluginExecutionException("Post Image Not Found"); } }
        }

        public T GetInputParameters<T>( ) where T : class, ICrmRequest
        { 
            switch (PluginExecutionContext.MessageName)
            {
                case Constants.PipelineMessage.Create:
                    return new CreateInputParameters() { Target = PluginExecutionContext.InputParameters["Target"] as Entity } as T;
                case Constants.PipelineMessage.Update: 
                    return new UpdateInputParameters() { Target = PluginExecutionContext.InputParameters["Target"] as Entity } as T;
                case Constants.PipelineMessage.Delete: 
                    return new DeleteInputParameters() { Target = PluginExecutionContext.InputParameters["Target"] as EntityReference } as T;
                case Constants.PipelineMessage.Retrieve: 
                    return new RetrieveInputParameters() { Target = PluginExecutionContext.InputParameters["Target"] as EntityReference, ColumnSet = PluginExecutionContext.InputParameters["ColumnSet"] as ColumnSet, RelatedEntitiesQuery = PluginExecutionContext.InputParameters["RelatedEntitiesQuery"] as RelationshipQueryCollection } as T;
                case Constants.PipelineMessage.RetrieveMultiple: 
                    return new RetrieveMultipleInputParameters() { Query = PluginExecutionContext.InputParameters["Query"] as QueryBase } as T;
                case Constants.PipelineMessage.Associate: 
                    return new AssociateInputParameters() { Target = PluginExecutionContext.InputParameters["Target"] as EntityReference, RelatedEntities = PluginExecutionContext.InputParameters["RelatedEntities"] as EntityReferenceCollection, Relationship = PluginExecutionContext.InputParameters["Relationship"] as Relationship } as T;
                case Constants.PipelineMessage.Disassociate: 
                    return new DisassociateInputParameters() { Target = PluginExecutionContext.InputParameters["Target"] as EntityReference, RelatedEntities = PluginExecutionContext.InputParameters["RelatedEntities"] as EntityReferenceCollection, Relationship = PluginExecutionContext.InputParameters["Relationship"] as Relationship } as T;
                case Constants.PipelineMessage.SetState:
                    return new SetStateInputParameters() { EntityMoniker = PluginExecutionContext.InputParameters["EntityMoniker"] as EntityReference, State = PluginExecutionContext.InputParameters["State"] as OptionSetValue, Status = PluginExecutionContext.InputParameters["Status"] as OptionSetValue } as T;
                default:
                    return default(T);
            }
        }
        public T GetOutputParameters<T>() where T : class, ICrmResponse
        {
            if (PluginExecutionContext.Stage < Constants.PipelineStage.PostOperation)
            {
                throw new InvalidOperationException("OutputParameters only exist during Post-Operation stage.");
            }

            switch (PluginExecutionContext.MessageName)
            {
                case Constants.PipelineMessage.Create:
                    return new CreateOutputParameters() { Id = (Guid)PluginExecutionContext.OutputParameters["Id"] } as T;
                case Constants.PipelineMessage.Retrieve:
                    return new RetrieveOutputParameters() { Entity = PluginExecutionContext.OutputParameters["Entity"] as Entity } as T;
                case Constants.PipelineMessage.RetrieveMultiple:
                    return new RetrieveMultipleOutputParameters() { EntityCollection = PluginExecutionContext.OutputParameters["BusinessEntityCollection"] as EntityCollection } as T;
                default:
                    return default(T);
            }
        }
        public void Trace(string message)
        {
            if (string.IsNullOrWhiteSpace(message) || TracingService == null)
            {
                return;
            }

            if (PluginExecutionContext == null)
            {
                TracingService.Trace(message);
            }
            else
            {
                TracingService.Trace($"{message} : (Correlation Id: {PluginExecutionContext.CorrelationId}, Initiating User: {PluginExecutionContext.InitiatingUserId})");
            }
        }



        /// <summary>
        /// implement Disaposable interface
        /// </summary>
        public void Dispose() {

            if (OrganizationDataContext == null) 
            {
                return;
            }
            OrganizationDataContext.Dispose();
            OrganizationDataContext = null;
        }
    }
}
