// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const sideMenu = $('#aside');
const menuBtn = $('#menu-btn');
const closeBtn = $('#close-btn');
const themeToggler = $('.theme-toggler');


//show sidebar
menuBtn.click(function () {
    sideMenu.css("display", "block");
});


//close menubar
closeBtn.click(function () {
    sideMenu.css("display", "none");
});


//change theme
themeToggler.click(function () {
    $('body').toggleClass('dark-theme-variables');
    $(this).children('span').toggleClass('active');

});



