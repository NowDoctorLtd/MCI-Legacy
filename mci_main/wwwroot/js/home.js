// ghastly.js

$(document).ready(function () {
    var topResult = null;

    var doAutocomplete = function (request, response) {
        $.ajax({
            type: "GET",
            url: "/search/lite?query=" + request["term"],
            success: function (data) { 
                console.log("data:" + JSON.stringify(data));
                response(data['specialties']); 
            },
            error: function () { response({"specialities": []})}
        }); 
     };

    $("#mainSearch").autocomplete({
        minLength: 2,
        delay: 300,
        source: doAutocomplete,
        select: function (event, selection) {
            console.log("Selection made. " + JSON.stringify(selection));
            console.log(selection.item.value);
            $("#mainSearch").val(selection.item.value);
            $("#mainSearchForm").submit();
        },
        close: function (e) {
            $(this).val("");
        },
        response: function (e, ui) {
            if (ui.content.length > 0) {
                topResult = ui.content[0].value;
                console.log(topResult);
            }
        }
    });


    // when press return (kc 13) search for topmost value (wip)
    $("#mainSearch").on('keypress', function (e) {
        if (e.which == 13) {
            event.preventDefault();
            if (topResult != null) {
                console.log(topResult);
                $("#mainSearch").val(topResult);
                $("#mainSearchForm").submit();
            }
            $(this).autocomplete("close");
        } else if (e.which == 8) {
            // FIXME: should clear top result and not nav when enter is struck after clearing

            topResult = null;
        }
    });

});

