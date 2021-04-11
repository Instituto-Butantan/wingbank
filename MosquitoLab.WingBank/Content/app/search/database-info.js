$(document).ready(function () {
    var element;
    var info;
    var databaseInfo = {
        getInfo: function (call) {
            $.get(_env.host + "search/GetDatabaseInfo", function (data) {
                info = data;
                if (call != undefined)
                    call(data);
                return;
            });
        },
        prepareComponent: function () {
            if (element != undefined) {
                databaseInfo.getInfo(function (info) {
                    element.html('<span class="wingbank-text"> ' + info.availableRecords + ' Available records | ' + info.records + ' records </span>');
                });
            }
        },
        init: function () {
            element = $('[dabase-info]');
            databaseInfo.prepareComponent();
        }
    }
    databaseInfo.init();
});