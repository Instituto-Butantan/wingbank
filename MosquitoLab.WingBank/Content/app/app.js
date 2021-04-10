$(document).ready(function () {
    var translate = {
        currentLanguage: "en-US",
        changeLanguage: function (e) {
            e.preventDefault();
            var language = $(this).attr("language");
            $(".translate-content .content").removeClass("active");
            $(".flag").removeClass("active");
            $(".content-" + language).addClass("active");
            $(this).addClass("active");
        },
        run: function () {
            $("body").on("click", ".flag", translate.changeLanguage);
        }
    }
    translate.run();
});