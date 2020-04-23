// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var rootApiUrl = "https://localhost:44398";

$("#run-data-pipeline").click(function () {
    $.getJSON(rootApiUrl + "/api/datapipeline/version", function (response) {
        alert("Response was: " + response);
    });
});