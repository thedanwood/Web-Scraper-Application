var loaderSelector = "#home-page-dashboard-loader";
var viewComponentContainerSelector = "#search-hisory-dashboard-container";
function loadSearchHistoryViewComponent() {
    $(loaderSelector).show();
    fetch("/SearchHistory/GetSearchHistoryViewComponent")
        .then((response) => {
            return response.text();
        })
        .then((result) => {
            $(loaderSelector).hide();
            $(viewComponentContainerSelector).html(result);
            $("#search-history-table").dataTable({
                order: [[4, 'desc']],
            });
        });
}
loadSearchHistoryViewComponent();
$("#search-history-section-btn").click(function () {
    loadSearchHistoryViewComponent();
})
$("#dashboard-section-btn").click(function () {
    $(loaderSelector).show();
    fetch("/Dashboard/GetDashboardViewComponent")
        .then((response) => {
            return response.text();
        })
        .then((result) => {
            $(loaderSelector).hide();
            $(viewComponentContainerSelector).html(result);
        });
})
function dashboardlineChartKeywordChanged() {
    getChartData();
}
function dashboardlineChartUrlChanged() {
    getChartData();
}
function getChartData() {
    var filterValues = getDashboardFilterValues();
    var url = "/Dashboard/GetDashboardLineChartData?" + new URLSearchParams({
        FrequencyEnumInt: 1, //set as 1 for demo purposes
        Keyword: filterValues.KeywordFilterValue,
        Url: filterValues.UrlFilterValue
    });
    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((result) => {
            generateChart(result);
        });
};
var chartInstance;
function generateChart(jsonData) {
    var dates = jsonData.data.searchedDateTimes;
    var searchEngineDataList = jsonData.data.chartDataList;
    var borderWidth = 3;
    var borderColoursForChart = [];
    var borderColours = ["#2196f3", "#78186b", "#00b058"];
    for (var i = 0; i < dates.length; i++) {
        borderColoursForChart.push(borderColours[i % borderColours.length]);
    }
    var datasets = [];
    for (var i = 0; i < searchEngineDataList.length; i++) {
        datasets.push(
            {
                label: searchEngineDataList[i].searchEngineName,
                data: searchEngineDataList[i].averagePositionNumbers,
                fill: false,
                borderColor: borderColours[i],
                borderWidth: borderWidth
            },
        )
    }
    var chart = document.querySelector("#chart").getContext("2d");
    var chartData = {
        type: "line",
        data: {
            labels: dates,
            datasets: datasets,
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    }
    if (chartInstance) {
        chartInstance.destroy();
    }
    chartInstance = new Chart(chart, chartData);
    chartInstance.render();
}

var keywordFilterSelector = "#dashboard-line-chart-keyword-select";
var urlFilterSelector="#dashboard-line-chart-url-select";

function getDashboardFilterValues() {
    return {
        KeywordFilterValue: $(keywordFilterSelector).find("option:selected").val(),
        UrlFilterValue: $(urlFilterSelector).find("option:selected").val()
    }
}
