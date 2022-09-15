$(document).ready(function () {

    if (window.location.pathname == "/") {
        return;
    }

    $(".has-treeview").removeClass("menu-is-opening");
    $(".has-treeview").removeClass("menu-open");
    $(".has-treeview ul").css("display","none");
 
    $("a[href='" + location.pathname + "']").closest(".has-treeview").attr('class', '').addClass('nav-item has-treeview menu-is-opening menu-open');
    $("a[href='" + location.pathname + "']").closest(".has-treeview").find("ul").css("display","block");
     //$("a[href='" + location.pathname + "']").parent().addClass('active');
    $("a[href='" + location.pathname + "']").addClass('active');
    $("a[href='" + location.pathname + location.search + "']").addClass('active');

});



// Ajax Loading
$(document).ajaxStart(function () {
    $('#loading').show();
    $('button').attr("disabled", true);
    //$('a').addClass("disabled");
    // Disable buttons
});
$(document).ajaxStop(function () {
    $('#loading').hide();
    $('button').attr("disabled", false);
    //  $('a').removeClass("disabled");
    // Enable buttons
});



 