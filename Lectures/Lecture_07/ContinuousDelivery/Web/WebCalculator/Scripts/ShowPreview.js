/// <reference path="jquery-3.3.1.js" />

(function (namespace) {

    // simply to make it available for unit tests
    namespace.showPreview = function () {
        var firstNumber = $("#First").val();
        var secondNumber = $("#Second").val();
        var newPreview = "Expression to calculate: '" + firstNumber + " + " + secondNumber + "'";
        $("#operationPreview").html(newPreview);
    };

    $(document).ready(function () {
        $("#First").on('input', namespace.showPreview);
        $("#Second").on('input', namespace.showPreview);
    });

})(window.Calculators = window.Calculators || {});