![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

<h1>Delegation Solution<h1>
	A basic solution for user delegation logic that can associate team members and conditional reassign owned records in a designated date range.
<h2>Delegation UML Diagram</h2>

<img src="https://github.com/dpuuqb/JDX/assets/106572740/36ce9958-7a7d-47e3-9b4b-a3f91571b087" alt="Delegation UML Diagram">


<h2>Tables</h2>
<ul>
	<li>Delegation: used to create delegation logic as archivement. Giving user lookups and effective/expiry with associating appropriate configurations if required to reassign.</li>
	<li>Delegation Reassign Configuration: Used to defined reassign entity type and set query filter.</li>
	<li>Delegation Reassign Record: Used to store entity type name and Guid for reassigned record.</li>
	<li>Custom Trigger: used to create system job lead that can be work with flows to trigger actions recurrently.</li>
</ul>

<h2>Delegation Status Transitions</h2>
<img src="https://github.com/dpuuqb/JDX/assets/106572740/74dd1bcf-d556-482b-854a-059f24d6c5e4" alt="Delegation Status Transitions">
	
1. create delegation reassign config records (add xml filter if required)
2. create custom trigger = Delegation Job
3. create daily system deletion job (recurrence by 1 day)

Solution including:
		1. one JavaScript
		2. two Workflow
		3. 3 plugin steps 	
				a. preValidate - create of delegation
				b. publish to start delegation - update status of delegation
				c. custom trigger pending deledation once effective date arrive
				d. cancel to end delegation - update status of delegation
				e. custom trigger delegating delegation once expiry date arrive


Email Notification (Not implemented yet)
