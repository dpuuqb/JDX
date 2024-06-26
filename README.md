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
	
<h1>Use Guide</h1>
	<h3>Step 1: Download solution below</h3>
 	<ul>
		<li><a href="https://github.com/dpuuqb/JDX/raw/master/Delegation_1_0_0_0.zip" target="_blank" >unmanaged.zip</a></li>
		<li><a href="https://github.com/dpuuqb/JDX/raw/master/Delegation_1_0_0_0_managed.zip" target="_blank" >managed.zip</a></li>
	</ul>
	<h3>Step 2: Create system job</h3>
 	<p>Create a record of entity Custom Trigger</p>
    	<img src="https://github.com/dpuuqb/JDX/assets/106572740/0f040230-ab66-4a08-bce0-ec8c9ee144bb" alt="Delegation App">
   	<p>Create a Bulk delete record over entity Custom Trigger</p>
   	<img src="https://github.com/dpuuqb/JDX/assets/106572740/6fbb821f-6fb8-41d3-a05d-24487e1ec629" alt="Delegation App">
   	<img src="https://github.com/dpuuqb/JDX/assets/106572740/a0e2eff3-cd4d-43f3-877e-be1910a75951" alt="Delegation App">
    <h3>Step 3: Configure delegation reassignment</h3>
  	<img src="https://github.com/dpuuqb/JDX/assets/106572740/714baad7-2ee1-443c-b0ec-e1b7ea336eba" alt="Delegation App">
 	<ul>
		 <li>Entity Name: A entity logical name that will be reassigned owner while delgating.</li>
		 <li>Is Default: A indicator wheather apply to global.</li>
		 <li>Filter: A piece of query filter in a format of XML that customize reassignment.</li>
	 </ul>
  <h3>Step 4: Delegation App</h3>
  <img src="https://github.com/dpuuqb/JDX/assets/106572740/5e5da9d7-59b5-4b72-9572-0da0d96c4f16" alt="Delegation App">
