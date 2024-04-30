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
	
<h2>Instruction</h2>
	<h4>Download solution below</h4>
 	<a href="https://github.com/dpuuqb/JDX/raw/master/Delegation_1_0_0_0.zip" target="_blank" >unmanaged.zip</a>
 	<a href="https://github.com/dpuuqb/JDX/raw/master/Delegation_1_0_0_0_managed.zip" target="_blank" >managed.zip</a>
  	<h4>Choose Delegation App</h4>
   	<img src="https://github.com/dpuuqb/JDX/assets/106572740/5e5da9d7-59b5-4b72-9572-0da0d96c4f16" alt="Delegation App">
   	<h4>Create a Custom Trigger record with name: Delegation Job</h4>
    	<img src="https://github.com/dpuuqb/JDX/assets/106572740/0f040230-ab66-4a08-bce0-ec8c9ee144bb" alt="Delegation App">
 	
  	<h4>Create daily scheduled job</h4>
   <p>Create a Bulk delete record over entity Custom Trigger</p>
   	<img src="https://github.com/dpuuqb/JDX/assets/106572740/6fbb821f-6fb8-41d3-a05d-24487e1ec629" alt="Delegation App">
   	<img src="https://github.com/dpuuqb/JDX/assets/106572740/a0e2eff3-cd4d-43f3-877e-be1910a75951" alt="Delegation App">
 	
 	
 		
