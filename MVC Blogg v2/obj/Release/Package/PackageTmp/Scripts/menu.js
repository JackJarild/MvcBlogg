$(function() {
    var pull = $('#pull');
    menu = $('.main-menu ul');
    menuHeight = menu.height();

    $(pull).on('click', function(e) {
        e.preventDefault();
        menu.slideToggle();
    });

    $(window).resize(function(){
        var w = $(window).width();
            if(w > 520 && menu.is(':hidden')) {
                menu.removeAttr('style');
            }
    });
});


$(function() {
    var pull2 = $('#pull2');
    menu2 = $('.category-nav ul');
    menuHeight2 = menu.height();

    $(pull2).on('click', function(e) {
        e.preventDefault();
        menu2.slideToggle();
    });

    $(window).resize(function(){
        var v = $(window).width();
            if(v > 700 && menu2.is(':hidden')) {
                menu2.removeAttr('style');
            }
    });
});
	
	