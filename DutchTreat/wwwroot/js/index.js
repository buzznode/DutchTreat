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