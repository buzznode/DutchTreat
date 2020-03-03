$(document).ready(function () {

  /* Hide the form */
  $('#theForm').hide();

  /* Handle btnBuy click */
  $('#btnBuy').on('click', function () {
    console.log('Buying Item');
  });

  /* Handle product properties clicks */
  $('.product-props li').on('click', function () {
    console.log('You clicked on ' + $(this).text());
  });

  var $loginToggle = $('#loginToggle');
  var $popupForm = $('.popup-form');

  $loginToggle.on('click', function () {
    $popupForm.fadeToggle(500);
  });

});
