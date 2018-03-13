function calculate() {
    var o = 0, p = 0, a = 0, v = 0, e = 0, r = 0;
    m = "", s = "";
    o = parseFloat($(".selected").text());
    p = parseFloat(document.getElementById("price").value);
    a = parseFloat($("#abv").val());
    if (o == "" || o == 0 || isNaN(o)) {
        e += 1;
        m += "Please enter valid number for OZ. \n";
    }
    if (p == "" || p == 0 || isNaN(p)) {
        e += 1;
        m += "Please enter valid number for Price. \n";
    }
    if (a == "" || a == 0 || isNaN(a)) {
        e += 1;
        m += "Please enter valid number for ABV. \n";
    }
    if (e > 0) {
        alert(m);
    }
    else {
        // Formula (oz * abv) / price
        r = ((o * a) / p);
        if (r < 4.00) {
            s = "F";
        }
        if (r >= 4.00 && r < 8.00) {
            s = "D";
        }
        if (r >= 8.00 && r < 12.00) {
            s = "C-";
        }
        if (r >= 12.00 && r < 16.00) {
            s = "C";
        }
        if (r >= 16.00 && r < 20.00) {
            s = "C+";
        }
        if (r >= 20.00 && r < 24.00) {
            s = "B-";
        }
        if (r >= 24.00 && r < 28.00) {
            s = "B";
        }
        if (r >= 28.00 && r < 32.00) {
            s = "B+";
        }
        if (r >= 32.00 && r < 36.00) {
            s = "A-";
        }
        if (r >= 36.00) {
            s = "A";
        }
        $("#answer span").first().before("<span>This beer rating is <span class=\"rating\">" + s + "</span>.</span>");

    }
}
function submitEnter(obj, e) {
    var unicode = e.keyCode ? e.keyCode : e.charCode;
    if (unicode == 13) {
        calculate();
        return false;
    }
    else {
        return true;
    }
}
$(document).ready(function () {
    $(".btnOZ").click(function () {
        $(this).parent().find(".selected").removeClass("selected");
        $(this).toggleClass("selected");
    });
    if (navigator.userAgent.match(/Android/)) {
        $(".content").css("display", "none");
        $(".content").css("visibility", "hidden");
    }
});

window.addEventListener('load', function () {
    window.setTimeout(function () {
        var bubble = new google.bookmarkbubble.Bubble();

        var parameter = 'bmb=1';

        bubble.hasHashParameter = function () {
            return window.location.hash.indexOf(parameter) != -1;
        };

        bubble.setHashParameter = function () {
            if (!this.hasHashParameter()) {
                window.location.hash += parameter;
            }
        };

        bubble.getViewportHeight = function () {
            window.console.log('Example of how to override getViewportHeight.');
            return window.innerHeight;
        };

        bubble.getViewportScrollY = function () {
            window.console.log('Example of how to override getViewportScrollY.');
            return window.pageYOffset;
        };

        bubble.registerScrollHandler = function (handler) {
            window.console.log('Example of how to override registerScrollHandler.');
            window.addEventListener('scroll', handler, false);
        };

        bubble.deregisterScrollHandler = function (handler) {
            window.console.log('Example of how to override deregisterScrollHandler.');
            window.removeEventListener('scroll', handler, false);
        };

        bubble.showIfAllowed();
    }, 1000);
}, false);