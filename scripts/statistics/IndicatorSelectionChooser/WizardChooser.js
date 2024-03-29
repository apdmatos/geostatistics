

Statistics.IndicatorSelectionChooser.WizardChooser = 
	Statistics.Class(Statistics.IndicatorSelectionChooser, 
{
	
	/**
	 * @private
	 * @proeprty {JQuery.SmartWizard}
	 */
	_wizard: null,
	
	/**
	 * Called to draw the wizard
	 * @public
	 * @function
	 */
	redraw: function() {
		
		this.div.addClass('swMain');
		
		var ul = $("<ul></ul>");
		this.div.append(ul);
		
		for(var i = 0, step; step = this.steps[i]; ++i) {
			var stepNumber = i + 1;
			var li = $(
					"<li>"
						+ "<a href=#step-" + stepNumber + ">"
							+ "<label class='stepNumber'>" + stepNumber + "</label>"
							+ "<span class='stepDesc'>" 
								+ step.getStepName() + "<br/>"
								+ "<small></small>" 
							+ "</span>"
						+ "</a>"
				  + "</li>");
			
			var content = $("<div id='step-" + stepNumber + "'></div>"); 	  
			step.draw(content);
			
			ul.append(li);
			this.div.append(content);
		}
		
		var self = this;
		function leaveAStepCallback(currAnchor, nextAnchor) {
			return self.validateStep(Number(currAnchor.attr('rel')), Number(nextAnchor.attr('rel')));
		}
		
		function onFinishCallback( ) {
			for (var i = 0; i < self.steps.length; ++i) 
				if (!self.validateStep(i + 1)) {
					self.selectStep(self.steps[i]);
					return false;
				}
			if(self.doneFunc) self.doneFunc(self.getStepsSelection());
			return true;
		}
		
		this._wizard = this.div.smartWizard({
			transitionEffect:'slideleft',
			onLeaveStep:leaveAStepCallback,
			onFinish:onFinishCallback,
			enableFinishButton:true
		});
	},

	/**
	 * @public
	 * @function
	 * @param {Statistics.Model.Search.StepEnum} stepEnumType
	 */	
	selectStepByType: function(stepEnumType) {
		var step = this.getStepByType(stepEnumType);
		this.selectStep(step);
	},
	
	/**
	 * @public
	 * @function
	 * @param {Statistics.IndicatorSelectionChooser.StepChooser} stepEnumType
	 */	
	selectStep: function(step) {
		var idx = step.getStepIndex();
		this._wizard.smartWizard('showStep', idx);
	},
	
/**********************************************************************************
 * ********************************************************************************
 * Private methods
 **********************************************************************************
 **********************************************************************************/	
	
	/**
	 * @private
	 * @function
	 * @param {Integer} stepIdx
	 */
	validateStep: function(currStepIdx, nextStepIdx) {
		var currIdx = currStepIdx - 1;
		var nextIdx = nextStepIdx - 1;
		
		if (nextIdx < currIdx) return true;
		
		var step = this.steps[currIdx];
		if(!step.validateStep()){
			this._wizard.smartWizard('showMessage', step.validationError());
      		this._wizard.smartWizard('setError',{stepnum:step,iserror:true});
			
			return false;       
		}
		
		this._wizard.smartWizard('setError',{stepnum:step,iserror:false});
		return true;
	}
	
});