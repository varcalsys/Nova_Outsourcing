	
jQuery(document).ready(function ($) { // wait until the document is ready
	$('#enviar').click(function () {
	    $('.error').fadeOut('slow'); // reset the error messages (hides them)

	    var error = false; // we will set this true if the form isn't valid

	    var email_compare = /^([a-z0-9_.-]+)@([da-z.-]+).([a-z.]{2,6})$/; // Syntax to compare against input
	    var email = $('input#newsletter').val(); // get the value of the input field
	    if (email == "" || email == " ") { // check if the field is empty
	        $('#errNews-email').fadeIn('slow'); // error - empty
	        error = true;
	    } else if (!email_compare.test(email)) { // if it's not empty check the format against our email_compare variable
	        $('#errNews-emailvld').fadeIn('slow'); // error - not right format
	        error = true;
	    }

	    if (error == true) {
	        
	        return false;
	    }


	    var data_string = $('#newsletter-form').serialize(); // Collect data from form

	    $.ajax({
	        type: "POST",
	        url: '/Home/Newsletter',
	        data: data_string,
	        timeout: 6000,
	        error: function (request, error) {
	            if (error == "timeout") {
	                $('#errNews-timedout').slideDown('slow');
	            }
	            else {
	                $('#errNews-state').slideDown('slow');
	                $("#errNews-state").html('An error occurred: ' + error + '');
	            }
	        },
	        success: function (data) {
	            if (data == 'erro') {
	                $('#ajaxerrorNews').slideDown('slow');
	            } else {

	                $('#newsletter-form').slideUp('slow');
	                $('#ajaxsuccessNews').slideDown('slow');
	            }
	        }
	    });

	    return false;
        
    } );
});
