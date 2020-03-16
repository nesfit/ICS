describe("Calculator", function () {
    beforeEach(function () {
        let dom = '<input type="number" id="First" /></input>' +
        '<input type="number" id="Second" /></input>' +
        '<div id="operationPreview"></div>';

        setFixtures(dom);
    });

    let labelContainsUpdatedValue = function (inputSelector, newValue) {
        $(inputSelector).val(newValue);
        Calculators.showPreview();
        let updatedLabel = $("#operationPreview").html();
        return updatedLabel.indexOf(newValue.toString()) > -1;
    };

    it("Reports First field value", function () {
        let containsValue = labelContainsUpdatedValue("#First", 25);
        expect(containsValue).toBeTruthy("The value of First input wasn't reflected in the preview text.");
    });

    it("Reports Second field value", function () {
        let containsValue = labelContainsUpdatedValue("#Second", 26);
        expect(containsValue).toBeTruthy("The value of Second input wasn't reflected in the preview text.");
    });
});
