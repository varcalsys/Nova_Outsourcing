	
jQuery(document).ready(function ($) { // wait until the document is ready
	$('#send').click(function(){ // when the button is clicked the code executes
		$('.error').fadeOut('slow'); // reset the error messages (hides them)

		var error = false; // we will set this true if the form isn't valid

		var name = $('input#Nome').val(); // get the value of the input field
		if(name == "" || name == " ") {
			$('#err-name').fadeIn('slow'); // show the error message
			error = true; // change the error state to true
		}

		var message = $('textArea#Mensagem').val(); // get the value of the input field
		if (message == "" || message == " ") {
		    $('#err-message').fadeIn('slow'); // show the error message
		    error = true; // change the error state to true
		}

		var email_compare = /^([a-z0-9_.-]+)@([da-z.-]+).([a-z.]{2,6})$/; // Syntax to compare against input
		var email = $('input#Email').val(); // get the value of the input field
		if (email == "" || email == " ") { // check if the field is empty
			$('#err-email').fadeIn('slow'); // error - empty
			error = true;
		}else if (!email_compare.test(email)) { // if it's not empty check the format against our email_compare variable
			$('#err-emailvld').fadeIn('slow'); // error - not right format
			error = true;
		}

		if(error == true) {
			$('#err-form').slideDown('slow');
			return false;
		}

		var data_string = $('#contact-form').serialize(); // Collect data from form

	    $.ajax({
	        type: "POST",
	        url: '/Home/Contato',
	        data: data_string,
	        timeout: 6000,
			error: function (request, error) {
				if (error == "timeout") {
					$('#err-timedout').slideDown('slow');
				}
				else {
					$('#err-state').slideDown('slow');
					$("#err-state").html('An error occurred: ' + error + '');
				}
			},
			success: function (data) {
			    if (data == 'erro') {
			        //$('#err-state').slideDown('slow');
			        //$("#err-state").html('Ocorreu um erro no envio verifique os dados e tente novamente');
			        $('#ajaxerror').slideDown('slow');
			    } else {
			        
			        $('#contact-form').slideUp('slow');
			        $('#ajaxsuccess').slideDown('slow');
			    }
			}
		});

		return false; // stops user browser being directed to the php file
	}); // end click function

});
