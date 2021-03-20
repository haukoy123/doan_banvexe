function iconopen() {
    document.getElementById("menuleft1").style.display = "block";
    document.getElementById("menuleft2").style.display = "none";

    document.getElementById("closeNav").style.display = "block";
    document.getElementById("openNav").style.display = "none";

    document.getElementById("right").style.marginLeft = "16%";

}
function iconclose() {
    document.getElementById("menuleft1").style.display = "none";
    document.getElementById("menuleft2").style.display = "block";

    document.getElementById("closeNav").style.display = "none";
    document.getElementById("openNav").style.display = "block";

    document.getElementById("right").style.marginLeft = "55px";

}