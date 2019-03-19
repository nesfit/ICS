/// <reference path="ShowPreview.js" />
/// <reference path="jquery-3.3.1.js" />
/// <reference path="../QUnit/qunit.js" />

$(document).ready(function () {

    QUnit.module("Preview", {
        setup: function () {

            var dom = '<input type="number" id="First" /></input>' +
                '<input type="number" id="Second" /></input>' +
                '<div id="operationPreview"></div>';

            $("#qunit-fixture").empty().append(dom);
        }
    });

    var labelContainsUpdatedValue = function (inputSelector, newValue) {
        $(inputSelector).val(newValue);
        Calculators.showPreview();
        var updatedLabel = $("#operationPreview").html();
        return updatedLabel.indexOf(newValue.toString()) > -1;
    }

    QUnit.test("Reports First field value", function (assert) {
        var containsValue = labelContainsUpdatedValue("#First", 25);
        assert.ok(containsValue, "The value of First input wasnt reflected in the preview text.");
    });

    QUnit.test("Reports Second field value", function (assert) {
        var containsValue = labelContainsUpdatedValue("#Second", 26);
        assert.ok(containsValue, "The value of Second input wasnt reflected in the preview text.");
    });

});