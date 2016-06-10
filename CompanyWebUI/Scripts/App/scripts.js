function ajaxError() {
    alert("Anropet misslyckades, vänligen försök igen.");
};

function searchFailed() {
    $("#searchresults").html("Inget hittades, vängligen försök igen.");
}

$(function() {
    $("#testH2").mouseover(function () {
        $(this).effect("bounce");
    });
});

$("input[data-autocomplete-source]").each(function () {
    var target = $(this);
    target.autocomplete({ source: target.attr("data-autocomplete-source") });
});