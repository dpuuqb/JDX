User Guide:
install Delegation solution;

Custom tables: Delegation, Deletion Reassign Configuration, Delegation Reassign Record, Custom Trigger

Details on each table: TBD

Relationship:  Delegation: Deletion Reassign Configuration = M:N; Delegation: Deletion Reassign Record = 1:N
Delegation state:status (see transit editor)
		inactive: Canceled, Expired
		active: Draft, Pending, Delegating
		
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
