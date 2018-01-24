$("#jq_a_towns").autocomplete(
{
    search: function () {},
    source: function (request, response)
    {
        $.ajax(
        {
            url: "/values/typeahead/a_towns/" + request.term,
            dataType: "json",
            success: function (data)
            {
                var resp = [];
                if (data != undefined && data.data != undefined && data.data.length > 0) {
                    for (var i = 0; i < data.data.length; i++) {
                        resp.push(data.data[i].label);
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
    display: "label",
    source: function (query, response) {
        $.ajax(
        {
            url: "/values/typeahead/a_towns/" + query,
            dataType: "json",
            success: function (data) {
                if (data != undefined && data.data != undefined) {
                    response(data.data);
                } else {
                    response([]);
                }
                
            }
        });
    }
});

function IsNotAlreadyAdded(group, id) {
    var g = document.getElementById(group);
    if (g.children.length > 0)
    {
        for (var child in g.children) {
            if (g.children[child].id === id) {
                return false;
            }
        }
    }
    return true;
}

$(".fromTypeaheadApi").on("typeahead:selected", function (evt, item) {
    $(this).blur().val("");

    var collection = $("#" + this.dataset.boxesCollection);
    if (IsNotAlreadyAdded(this.dataset.boxesCollection, item.id) === true) {
        $.ajax(
        {
            url: "partial/bluebox",
            data:
            {
                id: item.id,
                label: item.label
            },
            success: function (data) {
                collection.append(data);
            }
        });
    }
});
