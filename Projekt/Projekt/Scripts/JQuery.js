$(document).ready(function(){
    $(".ParkImg").hover( function(){
        $(this).find('span').show().offset($(this).offset()).css('text-align','center');
    }, function(){
        $(this).find('span').hide();
    });
});