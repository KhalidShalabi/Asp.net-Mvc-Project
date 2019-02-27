function toggleSlidebar() {
    document.getElementById("side-menu").classList.toggle("active");
    document.getElementById("maincontent").style.marginLeft = "-21%";
    document.getElementById("footer").style.width = "121%";
    document.getElementById("footer").style.marginRight = "1%";
    document.getElementById("tog").style.display = "none";
    document.getElementById("tog2").style.display = "inline";

}
function toggleSlidebar2() {
    document.getElementById("side-menu").classList.toggle("active");
    document.getElementById("maincontent").style.marginLeft = "0";
    document.getElementById("footer").style.width = "100%";
    document.getElementById("tog").style.display = "inline";
    document.getElementById("tog2").style.display = "none";
}
function iconchange1() {
    if (document.getElementById("icons1").classList.toggle("active")) {
        document.getElementById("icons1").style.display = "none";
        document.getElementById("icons2").style.display = "inline";
    }
    else {
        document.getElementById("icons2").style.display = "none";
        document.getElementById("icons1").style.display = "inline";
    }
}
function iconchange2() {
    if (document.getElementById("icons3").classList.toggle("active")) {
        document.getElementById("icons3").style.display = "none";
        document.getElementById("icons4").style.display = "inline";
    }
    else {
        document.getElementById("icons4").style.display = "none";
        document.getElementById("icons3").style.display = "inline";
    }
}
function iconchange3() {
    if (document.getElementById("icons5").classList.toggle("active")) {
        document.getElementById("icons5").style.display = "none";
        document.getElementById("icons6").style.display = "inline";
    }
    else {
        document.getElementById("icons6").style.display = "none";
        document.getElementById("icons5").style.display = "inline";
    }
}



$(document).ready(function () {
    function Contains(text_one, text_two) {
        if (text_one.indexOf(text_two) != -1)
            return true;
    }
    $("#Search").keyup(function () {
        var searchText = $("#Search").val().toLowerCase();
        $(".Search").each(function () {
            if (!Contains($(this).text().toLowerCase(), searchText)) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });
    });
});