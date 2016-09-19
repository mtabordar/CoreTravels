(function () {
    //var txtUsername = $("#username");
    //txtUsername.text("Maxwell54");

    //var main = $("#main");
    //main.on("mouseenter", function () {
    //    main.css("background-color", "#888");
    //});
    //main.on("mouseleave", function () {
    //    main.css("background-color", "");;
    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var menuItem = $(this);
    //    menuItem.css("color", "red");
    //})

    var $sideBarContent = $("#sidebar,#content");
    var $icon = $("#sideBarToggle i.fa");

    $("#sideBarToggle").on("click", function () {
        $sideBarContent.toggleClass("hide-sidebar");
        if ($sideBarContent.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        }
        else {
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");
        }
    })
})();