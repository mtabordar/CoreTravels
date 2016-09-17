(function (){
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

    $("#sideBarToggle").on("click", function () {
        $sideBarContent.toggleClass("hide-sidebar");
    })    
})();