function updateOntologyStatus(event, start, end, error) {
    var success = "";
    var suffix = "";
    if (event == "ok") {
        success = "successful ";
        suffix = " (" + (end - start) + "ms)"
    }
    else
    {
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

function poll() {
    var start = Date.now();
    $.ajax({
        url: $APIRoot_ontologyTypeahead + '/admin/ping',
        type: "GET",
        success: function (data) {
            var now = Date.now();
            updateOntologyStatus("ok", start, now);
        },
        error: function (xhr, textStatus, errorThrown) {
            var now = Date.now();
            updateOntologyStatus("not-ok", start, now, errorThrown);
        },
        dataType: "json",
        complete: setTimeout(function () { poll() }, 10000),
        timeout: 2000
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
            })

        },
        error: function (xhr, textStatus, errorThrown) {
            var now = Date.now();
            updateOntologyStatus("not-ok", start, now, errorThrown);
            swal({
                title: "Ping Error",
                text: errorThrown,
                type: "error"
            })
        //},
        //complete: function (xhr, textStatus) {
        //    swal({
        //        title: "Ping Response",
        //        text: textStatus,
        //        type: "warning"
        //    })
        }
    });
});

$().ready(function () {
    poll();
});