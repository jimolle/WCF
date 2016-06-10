function ajaxError() {
    alert("Anropet misslyckades, vänligen försök igen.");
};

function searchFailed() {
    $("#searchresults").html("Anropet misslyckades, vänligen försök igen.");
}

$("input[data-autocomplete-source]").each(function () {
    var target = $(this);
    target.autocomplete({ source: target.attr("data-autocomplete-source") });
});