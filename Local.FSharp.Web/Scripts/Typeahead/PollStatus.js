function updateOntologyStatus(event, start, end, error) {
    var success = "";
    var suffix = "";
    if (event == "ok") {
        success = "successful ";
        suffix = " (" + (end - start) + "ms)"
    }
    else {
        if (error == "") {
            error = "No response or error response";
        }
        suffix = " : " + error;
    }
    $("#ontologyHealthText").html("Last " + success + "ping: " + moment(start).format('DD-MMM-YYYY hh:mm:ss') + suffix);
    $("#ontologyHealthIndicator-unknown").hide()
    $("#ontologyHealthIndicator-ok").hide();
    $("#ontologyHealthIndicator-not-ok").hide();
    $("#ontologyHealthIndicator-" + event).show();
};

var shorttimeout = 2000;
var longtimeout = 30000;

function poll() {
    var start = Date.now();
    $.ajax({
        url: $APIRoot_ontologyTypeahead + '/admin/ping',
        type: "GET",
        success: function (data) {
            var now = Date.now();
            updateOntologyStatus("ok", start, now);
            setTimeout(function () { poll() }, longtimeout);
        },
        error: function (xhr, textStatus, errorThrown) {
            var now = Date.now();
            updateOntologyStatus("not-ok", start, now, errorThrown);
            setTimeout(function () { poll() }, shorttimeout);
        },
        dataType: "json",
        //complete: setTimeout(function () { poll() }, longtimeout),
        timeout: longtimeout
    })
};

$('#btnPing').click(function () {
    var start = Date.now();
    $.ajax({
        url: $APIRoot_ontologyTypeahead + '/admin/ping',
        dataType: 'json',
        success: function (data) {
            var now = Date.now();
            updateOntologyStatus("ok", start, now);
            swal({
                title: "Ping Success",
                text: "ping responded : " + (now - start) + "ms",
                type: "success"
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            var now = Date.now();
            updateOntologyStatus("not-ok", start, now, errorThrown);
            swal({
                title: "Ping Error",
                text: errorThrown,
                type: "error"
            })
        }
    });
});

$().ready(function () {
    poll();
});