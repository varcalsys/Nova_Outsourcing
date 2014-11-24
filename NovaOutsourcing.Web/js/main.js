/*-----------------------------------------------------------------------------------*/
/* 		Mian Js Start
/*-----------------------------------------------------------------------------------*/
$(document).ready(function($){
	var $ = jQuery.noConflict();
	"use strict"


/*-----------------------------------------------------------------------------------*/
/*	STICKY NAVIGATION
/*-----------------------------------------------------------------------------------*/
$(".sticky").sticky({topSpacing:0});


/*-----------------------------------------------------------------------------------*/
/* 		Hove Effects
/*-----------------------------------------------------------------------------------*/
    if (Modernizr.touch) {          
          // handle the closing of the overlay
          $(".close-overlay").click(function(e){
              e.preventDefault();
                e.stopPropagation();
                if ($(this).closest(".img").hasClass("hover")) {
                    $(this).closest(".img").removeClass("hover");
                }
            });
        } else {
            // handle the mouseenter functionality
            $(".img").mouseenter(function(){
                $(this).addClass("hover");
            })
            // handle the mouseleave functionality
            .mouseleave(function(){
                $(this).removeClass("hover");
            });}



/*-----------------------------------------------------------------------------------*/
/*	Parallax
/*-----------------------------------------------------------------------------------*/


	$(window).stellar({ 
	horizontalScrolling: false,
   });  


/*-----------------------------------------------------------------------------------*/
/* Pretty Photo
/*-----------------------------------------------------------------------------------*/

    jQuery("a[data-rel^='prettyPhoto']").prettyPhoto({
        theme: "facebook"
    });



/*-----------------------------------------------------------------------------------*/
/* SLIDER
/*-----------------------------------------------------------------------------------*/

$("#owl-screen").owlCarousel({ 
    autoPlay: 3000, //Set AutoPlay to 3 seconds
    items : 4,
    itemsDesktop : [1199,3],
    itemsDesktopSmall : [979,3],
	stopOnHover : true,
    navigation : true, // Show next and prev buttons
    pagination : false,
	navigationText: ["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
});



/*-----------------------------------------------------------------------------------*/
/* SLIDER
/*-----------------------------------------------------------------------------------*/

$("#owl-team").owlCarousel({ 
    autoPlay: 3000, //Set AutoPlay to 3 seconds
    items : 4,
    itemsDesktop : [1199,3],
    itemsDesktopSmall : [979,3],
    stopOnHover : true,
    navigation : true, // Show next and prev buttons
    pagination : false,
    navigationText: ["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
});


/*-----------------------------------------------------------------------------------*/
/* SLIDER
/*-----------------------------------------------------------------------------------*/

$("#owl-testi").owlCarousel({ 
    autoPlay: 3000, //Set AutoPlay to 3 seconds
    items : 1,
    singleItem : true,
    stopOnHover : true,
    navigation : false, // Show next and prev buttons
    pagination : true,
    navigationText: ["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
});



/*-----------------------------------------------------------------------------------*/
/* ANIMATION
/*-----------------------------------------------------------------------------------*/

var wow = new WOW({
    boxClass:     'wow',      // animated element css class (default is wow)
    animateClass: 'animated', // animation css class (default is animated)
    offset:       100,          // distance to the element when triggering the animation (default is 0)
    mobile:       false        // trigger animations on mobile devices (true is default)
  });
wow.init();



/*-----------------------------------------------------------------------------------*/
/* CONTACT FORM
/*-----------------------------------------------------------------------------------*/
var form = $('#contact'),
    submit = form.find('[name="submit"]');
form.on('submit', function(e) {
  e.preventDefault();
  
  // avoid spamming buttons
  if (submit.attr('value') !== 'Send')
    return;
  
  var valid = true;
  form.find('input, textarea').removeClass('invalid').each(function() {
    if (!this.value) {
      $(this).addClass('invalid');
      valid = false;
    }
  });
  
  if (!valid) {
    form.animate({left: '0em'},  50)
        .animate({left:  '0em'}, 100)
        .animate({left:    '0'},  50);
  } else {
    submit.attr('value', 'Sending...')
          .css({boxShadow: '0 0 0em 0em rgba(225, 225, 225, 0.6)',
                backgroundColor: '#ccc'});
    // simulate AJAX response
    setTimeout(function() {
      // step 1: slide labels and inputs
      // when AJAX responds with success
      // no animation for AJAX failure yet
      form.find('label')
          .animate({left: '100%'}, 500)
          .animate({opacity: '0'}, 500);
    }, 1000);
    setTimeout(function() {
      // step 2: show thank you message after step 1
      submit.attr('value', 'Thank you :)')
            .css({boxShadow: 'none'});
    }, 2000);
    setTimeout(function() {
      // step 3: reset
      form.find('input, textarea').val('');
      form.find('label')
          .css({left: '0'})
          .animate({opacity: '1'}, 500);
      submit.attr('value', 'Send')
            .css({backgroundColor: '#f3835d'});
    }, 4000);
  }
});


/*-----------------------------------------------------------------------------------*/	
/*	Back to Top
-----------------------------------------------------------------------------------*/

	$(window).scroll(function(){
    	if($(window).scrollTop() > 300){
      	$("#back-to-top").fadeIn(600);
    	}	 else{
      		$("#back-to-top").fadeOut(600);
   		 }
 	 });
$('#back-to-top, .back-to-top').click(function() {
      $('html, body').animate({ scrollTop:0 }, '1000');
      return false;
  });



/*-----------------------------------------------------------------------------------*/	
/*	TABS
-----------------------------------------------------------------------------------*/

(function() {
	[].slice.call( document.querySelectorAll( '.tabs' ) ).forEach( function( el ) {
		new CBPFWTabs( el );
	});
})();


/*-----------------------------------------------------------------------------------*/
/*    Active Menu Item on Page Scroll
/*-----------------------------------------------------------------------------------*/

$(window).scroll(function(event) {
    Scroll();
}); 
$('.scroll a').click(function() {  
    $('html, body').animate({scrollTop: $(this.hash).offset().top -60}, 1000);
    return false;
});
// User define function
function Scroll() {
var contentTop      =   [];
var contentBottom   =   [];
var winTop      =   $(window).scrollTop();
var rangeTop    =   200;
var rangeBottom =   500;
$('.navbar-collapse').find('.scroll a').each(function(){
  contentTop.push( $( $(this).attr('href') ).offset().top);
    contentBottom.push( $( $(this).attr('href') ).offset().top + $( $(this).attr('href') ).height() );
})
$.each( contentTop, function(i){
  if ( winTop > contentTop[i] - rangeTop ){
    $('.navbar-collapse li.scroll')
      .removeClass('active')
      .eq(i).addClass('active');      
    }
  })};
});
