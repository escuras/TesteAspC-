
setTimeout(function () {
    var elemento = document.getElementById("LabelError");
    var bt = document.getElementById('btlogin');
    if (elemento != null) {
        elemento.style.visibility = "hidden";
        bt.style.marginTop = "-30px";
    }
}, 3000);


