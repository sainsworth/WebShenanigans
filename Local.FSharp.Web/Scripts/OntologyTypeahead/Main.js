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

$("#jq_a_towns").autocomplete(
{
    search: function () {},
    source: function (request, response)
    {
        $.ajax(
        {
            url: $APIRoot_ontologyTypeahead + "/lookup/a_towns",
            dataType: "json",
            data:
            {
                query: request.term,
            },
            success: function (data)
            {
                var resp = [];
                if (data != undefined && data.Response != undefined && data.Response.Data != undefined && data.Response.Data.length > 0) {
                    for (var i = 0; i < data.Response.Data.length; i++)
                    {
                        resp.push(data.Response.Data[i].Label)
                    }
                }
                response(resp);
            }
        });
    }//,
    //minLength: 2
});

$('#boxes-a-towns').typeahead({
    highlight: true,
    minLength: 3,
    limit: 10
},
{
    name: "a-towns",
    display: "Label",
    source: function (query, response) {
        $.ajax(
        {
            url: $APIRoot_ontologyTypeahead + "/lookup/a_towns",
            dataType: "json",
            data:
            {
                query: query,
            },
            success: function (data) {
                if (data != undefined && data.Response != undefined) {
                    response(data.Response.Data);
                } else {
                    response([]);
                }
                
            }
        });
    }
});

$().ready(function () {
    poll();
});