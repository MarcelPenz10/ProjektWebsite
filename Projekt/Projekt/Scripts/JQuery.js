$(document).ready(function(){
    $(".ParkImg").hover( function(){
        $(this).find('p').show().offset($(this).offset());
    }, function(){
        $(this).find('p').hide();
    });
});