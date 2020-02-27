$(document).ready(function(){
    $(".ParkImg").hover( function(){
        var x = $(this).offset();
        var y = x.top - 50;
        $(this).find('p').show().offset({top: y});
        $(this).find('img').css('opacity', '0.5');
    }, function(){
        $(this).find('p').hide();
        $(this).find('img').css('opacity', '1');
    });
});

