jQuery(document).ready(function(){
	"use strict";
    
    jQuery('#theme-setting-panel a').on( 'click', function(){
		if(jQuery(this).attr('data-section') != 'setting-panel-buy-another-license') {
	    	jQuery('#theme-setting-panel a').removeClass('nav-tab-active');
	    	jQuery(this).addClass('nav-tab-active');
	    	
	    	jQuery('.setting-section').css('display', 'none');
	    	jQuery('#'+jQuery(this).attr('data-section')).fadeIn();
	    	jQuery('#current_tab').val('#'+jQuery(this).attr('data-section'));
		}
		else {
			window.open(tgAjax.purchaseurl,'_blank');
		}
    	
    	return false;
    });
	
	jQuery('#themegoods-envato-code-submit').on( 'click', function(){
		var envatoPurchaseCode = jQuery('#pp_envato_personal_token').val();
		var siteDomain = jQuery('#themegoods-site-domain').val();

		console.log(envatoPurchaseCode.length);
		//If not enter purchase code
		if(envatoPurchaseCode.length != 36) {
			jQuery('#pp_envato_personal_token').focus();
			
			if(jQuery('#pp_registration_section .tg_error').length == 0) {
				jQuery('<br style="clear:both;"/><div class="tg_error"><span class="dashicons dashicons-warning"></span>Purchase code is invalid</div>').insertAfter('#themegoods-site-domain');
			}
			
			return false;
		}
		else {
			jQuery('.tg_error').hide();
		}
	});
    
    jQuery('.vive_admin_trigger').on( 'click', function(){
	    var triggerSection = jQuery(this).attr('data-trigger');
	    jQuery('#'+triggerSection).trigger('click');
	    
	    return false;
	});
	
	var elems = document.querySelectorAll('.iphone_checkboxes');

	for (var i = 0; i < elems.length; i++) {
	  var switchery = new Switchery(elems[i], { color: '#2271b1', size: 'small' });
	}
		
	jQuery('.setting-section').css('display', 'none');
    
    //if URL has #
    if(self.document.location.hash != '')
	{
		//Check if Instagram request
		var stringAfterHash = self.document.location.hash.substr(1);
		var hashDataArr = stringAfterHash.split('=');
		
		jQuery('html, body').stop().animate({scrollTop:0}, 'fast');
		jQuery('.nav-tab').removeClass('nav-tab-active');
		jQuery('a'+self.document.location.hash+'-a').addClass('nav-tab-active');
		jQuery('div'+self.document.location.hash).css('display', 'block');
		jQuery('#current_tab').val(self.document.location.hash);
	}
	else
	{
	    jQuery('div#setting-panel-registration').css('display', 'block');
	}
    
    jQuery('.setting-options-sortable').sortable({
	    placeholder: 'ui-state-highlight',
	    create: function(event, ui) { 
	    	myCheckRel = jQuery(this).attr('rel');
	    
	    	var order = jQuery(this).sortable('toArray');
        	jQuery('#'+myCheckRel).val(order);
	    },
	    update: function(event, ui) {
	    	myCheckRel = jQuery(this).attr('rel');
	    
	    	var order = jQuery(this).sortable('toArray');
        	jQuery('#'+myCheckRel).val(order);
	    }
	});
	jQuery('.setting-options-sortable').disableSelection();
	
	if(jQuery('body').hasClass('post-type-footer'))
	{
		jQuery('#page_template').children('option[value="elementor_canvas"]').prop('selected',true);
		jQuery('#pageparentdiv').hide();
	}
	
	if(jQuery('body').hasClass('post-type-header'))
	{
		jQuery('#page_template').children('option[value="elementor_canvas"]').prop('selected',true);
		jQuery('#pageparentdiv').hide();
	}
	
	if(jQuery('body').hasClass('post-type-megamenu'))
	{
		jQuery('#page_template').children('option[value="elementor_canvas"]').prop('selected',true);
		jQuery('#pageparentdiv').hide();
	}
	
	if(jQuery('body').hasClass('post-type-fullmenu'))
	{
		jQuery('#page_template').children('option[value="elementor_canvas"]').prop('selected',true);
		jQuery('#pageparentdiv').hide();
	}
	
	if(jQuery('body').hasClass('post-type-galleries'))
	{
		jQuery('#page_template').children('option[value="default"]').prop('selected',true);
		jQuery('#pageparentdiv').hide();
	}
	
	if(jQuery('body').hasClass('post-type-portfolios'))
	{
		jQuery('#page_template').children('option[value="default"]').prop('selected',true);
		jQuery('#pageparentdiv').hide();
	}
});