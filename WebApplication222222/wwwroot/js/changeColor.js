document.addEventListener("DOMContentLoaded", function () {
    var currentPath = window.location.pathname;

    var navItems = document.querySelectorAll('.nav-item');

    navItems.forEach(function (item) {
        var itemPath = item.getAttribute('href');

        if ((currentPath === itemPath) || (currentPath === "/" && (itemPath === "/Elements/Index" || itemPath === "/Characters/Index"))) {
            item.style.color = 'rgb(70, 177, 240)'; 
        } else {
            item.style.color = 'white'; 
        }
    });
});
