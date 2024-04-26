var DelegationRibbon= (function (DelegationRibbon) {

	DelegationRibbon.Publish = (primaryControl)=>{
		console.log("Publish");
        //open progress bar
        Xrm.Utility.showProgressIndicator('Processing...')
        //input validation
        //update status if possible
       
        primaryControl.getAttribute('statuscode').setValue(952700000);
        primaryControl.data.save().then(() => {
            Xrm.Utility.closeProgressIndicator();
            primaryControl.data.refresh();
        });
        
	}
    DelegationRibbon.EnablePublish = (primaryControl)=>{
        //customize enable rule for Publish
        //update mode && status is draft
        //add Auto-Publish
        if (primaryControl.getAttribute("jms_isautopublish").getValue()) return false;
        return primaryControl.ui.getFormType() != 1 && primaryControl.getAttribute('statuscode').getValue() == 1
    }

	DelegationRibbon.Cancel= (primaryControl)=> {
		console.log("Canceled");
        var formContext = primaryControl || Xrm.Page;

        Xrm.WebApi.updateRecord('jms_delegation', primaryControl.data.getEntity().getId(), {'statecode':1,'statuscode':2})
        .then((result)=>primaryControl.data.refresh(), (error)=>Xrm.Navigation.openErrorDialog({message:error.message}))
	}
    
    DelegationRibbon.EnableCancel = (primaryControl)=>{
        //customize enable rule for Cancel
        //update mode && status is pending or delegating
        return primaryControl.ui.getFormType() != 1 && (primaryControl.getAttribute('statuscode').getValue() == 952700001 || primaryControl.getAttribute('statuscode').getValue() == 952700002)
    }

	

	return DelegationRibbon;
}(DelegationRibbon|| {}));
