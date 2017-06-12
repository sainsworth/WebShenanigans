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

function IsNotAlreadyAdded(group, id) {
    var g = $(document.getElementById(id));
    if (g.length == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

$('#boxes-a-towns').on('typeahead:selected', function (evt, item) {
    $(this).blur().val('');

    if (IsNotAlreadyAdded("boxes-collection", item.Id) == true) {
        $.ajax(
        {
            url: "partial/bluebox",
            data:
            {
                id: item.Id,
                label: item.Label
            },
            success: function (data) {
                $("#boxes-collection").append(data);
            }
        });
    }
});
