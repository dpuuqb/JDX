using DelegationPlugins;
using DelegationPlugins.Entities;
using FakeXrmEasy.Abstractions.Plugins.Enums;
using FakeXrmEasy.Pipeline;
using FakeXrmEasy.Plugins.Audit;
using FakeXrmEasy.Plugins.PluginSteps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using SharedLibrary;
using System;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;

namespace DelegationPluginUnitTest
{
    [TestClass]
    public class CreateDelegationTestWithSimulation: FakeXrmEasyPipelineTestsBase
    {
        [Fact]
        [TestMethod]
        public void Should_create_delegation_with_Draft_Status()
        {
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Preoperation,
                Mode = ProcessingStepMode.Synchronous

            });

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
        }

        [Fact]
        [TestMethod]
        public void Should_create_delegation_with_Published_Status()
        {
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Preoperation,
                Mode = ProcessingStepMode.Synchronous

            });

            _service.Execute(new CreateRequest()
            {
                Target =
                new Delegation()
                {
                    [Delegation.Fields.DelegatedUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.DelegatingUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.EffectiveDate] = new DateTime(2024, 05, 01),
                    [Delegation.Fields.ExpiryDate] = new DateTime(2024, 06, 30),
                    [Delegation.Fields.IsAutoPublish] = true,
                    [Delegation.Fields.StatusReason] = Delegation.StatusReasonEnum.Draft.ToOptionSetValue()
                }
            });

            var delegations = _context.CreateQuery<Delegation>().ToList();
            Assert.Single(delegations);
            Assert.Equal(Delegation.StatusReasonEnum.Published, delegations[0].StatusReason);
        }
    }
}
