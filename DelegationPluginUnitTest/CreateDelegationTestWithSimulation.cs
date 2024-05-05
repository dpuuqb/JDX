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

        [Fact]
        [TestMethod]
        public void Should_create_delegation_with_Pending_Status()
        {
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Postoperation,
                Mode = ProcessingStepMode.Synchronous

            });

            _service.Execute(new CreateRequest()
            {
                Target =
                new Delegation()
                {
                    Id = Guid.NewGuid(),
                    [Delegation.Fields.DelegatedUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.DelegatingUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.EffectiveDate] = new DateTime(2024, 05, 01),
                    [Delegation.Fields.ExpiryDate] = new DateTime(2024, 06, 30),
                    [Delegation.Fields.IsAutoPublish] = true,
                    [Delegation.Fields.StatusReason] = Delegation.StatusReasonEnum.Published.ToOptionSetValue()
                }
            });

            var delegations = _context.CreateQuery<Delegation>().ToList();
            Assert.Single(delegations);
            Assert.Equal(Delegation.StatusReasonEnum.Pending, delegations[0].StatusReason);
        }

        [Fact]
        [TestMethod]
        public void Should_create_delegation_with_Delegating_Status()
        {
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Postoperation,
                Mode = ProcessingStepMode.Synchronous

            });

            _service.Execute(new CreateRequest()
            {
                Target =
                new Delegation()
                {
                    Id = Guid.NewGuid(),
                    [Delegation.Fields.DelegatedUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.DelegatingUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.EffectiveDate] = new DateTime(2024, 03, 01),
                    [Delegation.Fields.ExpiryDate] = new DateTime(2024, 06, 30),
                    [Delegation.Fields.IsAutoPublish] = true,
                    [Delegation.Fields.StatusReason] = Delegation.StatusReasonEnum.Published.ToOptionSetValue()
                }
            });

            var delegations = _context.CreateQuery<Delegation>().ToList();
            Assert.Single(delegations);
            Assert.Equal(Delegation.StatusReasonEnum.Delegating, delegations[0].StatusReason);
        }
        /// <summary>
        /// Test from Draft to Delegating
        /// </summary>
        [Fact]
        [TestMethod]
        public void Should_preAndPost_create_delegation_with_pipeline()
        {
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Preoperation,
                Mode = ProcessingStepMode.Synchronous

            });
            _context.RegisterPluginStep<CreateDelegation>(new PluginStepDefinition()
            {
                EntityLogicalName = Delegation.EntityLogicalName,
                MessageName = "Create",
                Stage = ProcessingStepStage.Postoperation,
                Mode = ProcessingStepMode.Synchronous

            });

            _service.Execute(new CreateRequest()
            {
                Target =
                new Delegation()
                {
                    Id = Guid.NewGuid(),
                    [Delegation.Fields.DelegatedUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.DelegatingUser] = new EntityReference(User.EntityLogicalName, Guid.NewGuid()),
                    [Delegation.Fields.EffectiveDate] = new DateTime(2024, 03, 01),
                    [Delegation.Fields.ExpiryDate] = new DateTime(2024, 06, 30),
                    [Delegation.Fields.IsAutoPublish] = true,
                    [Delegation.Fields.StatusReason] = Delegation.StatusReasonEnum.Draft.ToOptionSetValue()
                }
            });

            var delegations = _context.CreateQuery<Delegation>().ToList();
            Assert.Single(delegations);
            Assert.Equal(Delegation.StatusReasonEnum.Delegating, delegations[0].StatusReason);
        }
    }
}
