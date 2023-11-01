document.addEventListener("DOMContentLoaded", function () {
    // 获取当前页面的路径
    var currentPath = window.location.pathname;

    // 获取所有导航栏项
    var navItems = document.querySelectorAll('.nav-item');

    // 遍历导航栏项
    navItems.forEach(function (item) {
        var itemPath = item.getAttribute('href');

        // 处理特殊情况：Element和Atlas
        if ((currentPath === itemPath) || (currentPath === "/" && (itemPath === "/Elements/Index" || itemPath === "/Characters/Index"))) {
            item.style.color = 'rgb(70, 177, 240)'; // 如果匹配，将文本颜色设置为rgb(70, 177, 240)
        } else {
            item.style.color = 'white'; // 如果不匹配，将文本颜色设置为白色
        }
    });
});
