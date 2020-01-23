$(document).ready(function(){
    $(".ParkImg").hover( function(){
        $(this).find('p').show().offset($(this).offset());
        $(this).find('img').css('opacity', '0.6');
    }, function(){
        $(this).find('p').hide();
        $(this).find('img').css('opacity', '1');
    });
});