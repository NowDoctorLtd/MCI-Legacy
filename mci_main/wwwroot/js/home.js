// ghastly.js
$(document).ready(function () {
    var topResult = null;

    $("#mainSearch").autocomplete({
        minLength: 3,
        delay: 500,
        source: sampleSearchCollection.toJSON(),
        select: function (event, selection) {
            console.log("Selection made. " + JSON.stringify(selection));
            renderResult(selection.item.value);
            // Clear or keep result??
            console.log(this);
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
        if (e.keyCode == 13) {
            event.preventDefault();
            if (topResult != null) {
                renderResult(topResult);
            }
            $(this).autocomplete("close");
        }
    });

});

