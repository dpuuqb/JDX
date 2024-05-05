using DelegationPlugins.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;

namespace DelegationPluginUnitTest
{
    [TestClass]
    public class DelegationSystemJobsTestWithSimulation:FakeXrmEasyPipelineTestsBase
    {
        public DelegationSystemJobsTestWithSimulation()
        {



            #region simulate test environment
            //prepare teams
            Team team1 = new Team()
            {
                [Team.Fields.TeamName] = "Test team 1"

            };
            Guid team1Id = _service.Create(team1);
            Team team2 = new Team()
            {
                [Team.Fields.TeamName] = "Test team 2"

            };
            Guid team2Id = _service.Create(team2);

            //prepare users
            User delegatedUser = new User()
            {
                FirstName = "delegatedUser",
                LastName = "Test"
            };
            Guid user1Id = _service.Create(delegatedUser);
            User delegatingUser = new User()
            {
                FirstName = "delegatingUser",
                LastName = "Test"
            };
            Guid user2Id = _service.Create(delegatingUser);

            //associate users and teams
            
            _service.Associate(Team.EntityLogicalName, 
                team1Id, 
                new Relationship("teammembership_association"), 
                new EntityReferenceCollection() {new EntityReference(User.EntityLogicalName, user1Id)});
            _service.Associate(Team.EntityLogicalName,
                team2Id,
                new Relationship("teammembership_association"),
                new EntityReferenceCollection() { new EntityReference(User.EntityLogicalName, user2Id) });
                



            Delegation delegation = new Delegation()
            {
                [Delegation.Fields.DelegatedUser] = new EntityReference(User.EntityLogicalName, user1Id),
                [Delegation.Fields.DelegatingUser] = new EntityReference(User.EntityLogicalName, user2Id),
                [Delegation.Fields.EffectiveDate] = new DateTime(2024, 04, 29),
                [Delegation.Fields.ExpiryDate] = new DateTime(2024, 06, 30),
                [Delegation.Fields.IsAutoPublish] = true,
                [Delegation.Fields.StatusReason] = Delegation.StatusReasonEnum.Pending.ToOptionSetValue()
            };
            _service.Create(delegation);
            DelegationReassignConfiguration config = new DelegationReassignConfiguration()
            {
                [DelegationReassignConfiguration.Fields.EntityName] = "jms_delegationtest",
                [DelegationReassignConfiguration.Fields.IsDefault] = true
            };
            _service.Create(config);

            #endregion
        }
        [TestMethod]
        [Fact]
        public void Test_Context_Should_Ready()
        {
            var delegations = _context.CreateQuery<Delegation>().ToList();
            Assert.Single(delegations);
        }
    }
}
