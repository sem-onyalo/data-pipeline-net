// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var rootApiUrl = "https://localhost:44398";

var dataPipelineState;

$("#data-pipeline-run").click(function () {
    $.getJSON(rootApiUrl + "/api/datapipeline/run", function (response) {
        dataPipelineState = 0;

        $('#data-pipeline-progress').empty();

        window.setTimeout(checkDataPipelineStatus, 500);
    });
});

function checkDataPipelineStatus() {
    $.getJSON(rootApiUrl + "/api/datapipeline/status", function (response) {
        checkDelay = 3500;
        currentState = parseInt(response)
        if (dataPipelineState == 0 && currentState > 0) {
            $('#data-pipeline-progress').append('<div id="state-ingesting" class="progress-bar progress-bar-striped progress-bar-animated" style="width: 33%">Ingesting data...</div>');
            dataPipelineState = 1;
            window.setTimeout(checkDataPipelineStatus, checkDelay);
        } else if (dataPipelineState == 1 && currentState > 1) {
            $('#state-ingesting').remove();
            $('#data-pipeline-progress').append('<div id="state-ingested" class="progress-bar bg-success" style="width: 33%">Ingested</div>');
            $('#data-pipeline-progress').append('<div id="state-transforming" class="progress-bar progress-bar-striped progress-bar-animated" style="width: 34%">Transforming data...</div>');
            dataPipelineState = 2;
            window.setTimeout(checkDataPipelineStatus, checkDelay);
        } else if (dataPipelineState == 2 && currentState > 2) {
            $('#state-transforming').remove();
            $('#data-pipeline-progress').append('<div id="state-transformed" class="progress-bar bg-success" style="width: 34%">Transformed</div>');
            $('#data-pipeline-progress').append('<div id="state-loading" class="progress-bar progress-bar-striped progress-bar-animated" style="width: 33%">Loading data...</div>');
            dataPipelineState = 3;
            window.setTimeout(checkDataPipelineStatus, checkDelay);
        } else if (dataPipelineState == 3 && currentState > 3) {
            $('#state-loading').remove();
            $('#data-pipeline-progress').append('<div id="state-loaded" class="progress-bar bg-success" style="width: 33%">Loaded</div>');
            dataPipelineState = 4;
        }
    });

}