using DelegationPlugins.Entities;
using DelegationPlugins;
using FakeXrmEasy.Abstractions.Plugins.Enums;
using FakeXrmEasy.Plugins.PluginSteps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;
using FakeXrmEasy.Pipeline;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using FakeXrmEasy.Plugins.PluginImages;

namespace DelegationPluginUnitTest
{
    [TestClass]
    public class UpdateDelegationTestWithSimulation: FakeXrmEasyPipelineTestsBase
    {

        /// <summary>
        /// create a draft delegation
        /// manually pulish
        /// draft status transit to published at pre-udate message
        /// published to pending or delegating based on effective date at post-update message
        /// </summary>
        [Fact]
        [TestMethod]
        public void Should_update_draft_delegation_with_pipeline()
        {
            //register pre-create
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Preoperation,
                Mode = ProcessingStepMode.Synchronous

            });
            //register post-create
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Postoperation,
                Mode = ProcessingStepMode.Synchronous

            });

            //register images
            string registeredPreImageName = "PreImage";
            string registeredPostImageName = "PostImage";
            PluginImageDefinition preImageDefinition = new PluginImageDefinition(registeredPreImageName, ProcessingStepImageType.PreImage, new string[] { Delegation.Fields.Status, Delegation.Fields.StatusReason });
            PluginImageDefinition postImageDefinition = new PluginImageDefinition(registeredPostImageName, ProcessingStepImageType.PostImage, new string[] { Delegation.Fields.Status, Delegation.Fields.StatusReason });

            //register pre-update
            PluginStepDefinition preUpdateStep = new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Update",
                Stage = ProcessingStepStage.Preoperation,
                Mode = ProcessingStepMode.Synchronous
            };
            preUpdateStep.ImagesDefinitions = new PluginImageDefinition[] { preImageDefinition };
            _context.RegisterPluginStep<UpdateDelegation>(preUpdateStep);

            //register post-update
            PluginStepDefinition postUpdateStep = new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Update",
                Stage = ProcessingStepStage.Postoperation,
                Mode = ProcessingStepMode.Asynchronous
            };
            postUpdateStep.ImagesDefinitions = new PluginImageDefinition[] { preImageDefinition, postImageDefinition };
            _context.RegisterPluginStep<UpdateDelegation>(postUpdateStep);
           


            #region create new delegation take manual publish
            _service.Execute(new CreateRequest()
            {
                Target =
                new Delegation()
                {
                    [Delegation.Fields.DelegatedUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.DelegatingUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.EffectiveDate] = new DateTime(2024, 05, 01),
                    [Delegation.Fields.ExpiryDate] = new DateTime(2024, 06, 30),
                    [Delegation.Fields.IsAutoPublish] = false,
                    [Delegation.Fields.StatusReason] = Delegation.StatusReasonEnum.Draft.ToOptionSetValue()
                }
            });
            
            var delegations = _context.CreateQuery<Delegation>().ToList();
            Assert.Single(delegations);
            Assert.Equal(Delegation.StatusReasonEnum.Draft, delegations[0].StatusReason);

            #endregion

            #region update the delegation by simulating clicking Publish button.
            Delegation update = new Delegation() 
            { 
                Id = delegations[0].Id,
                StatusReason = Delegation.StatusReasonEnum.Published,
            };
            _service.Execute(new UpdateRequest()
            {
                Target = update
            });

            var delegationsAfter = _context.CreateQuery<Delegation>().ToList();
            Assert.Single(delegationsAfter);
            Assert.Equal(Delegation.StatusReasonEnum.Pending, delegationsAfter[0].StatusReason);
            #endregion
        }

    }
}
