$("#search-engine-select").select2();
var keywordSelectSelector = "#keywords-select";
$(keywordSelectSelector).select2({
    tags: true,
})
$("#generate-search-results-form").submit(function () {
    $("#search-engine-search-submit").attr("disabled", "disabled");
    $('#search-engine-search-loader').show();
})