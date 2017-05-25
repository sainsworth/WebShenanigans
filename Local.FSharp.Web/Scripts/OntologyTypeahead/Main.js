$('#btnPing').click(function () {
    var start = Date.now();
    $.ajax({
        url: $APIRoot_ontologyTypeahead + '/admin/ping',
        dataType: 'json',
        success: function(data){
            swal({
                title: "Ping Success",
                text: "ping responded : " + (Date.now() - start) + "ms",
                type: "success"
            })
        },
        error: function (xhr, textStatus, errorThrown) {
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