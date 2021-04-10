$("document").ready(function() {
  var methods = {
    ALL: "ALL",
    SINGLE: "SINGLE"
  };
  var grid = {
    selectedWings: [],
    getSelectedWings: function(output) {
      var wings = localStorage.getItem("wings");
      if (wings) {
        wings = JSON.parse(wings);
      } else {
        wings = [];
        grid.save(wings);
      }
      grid.selectedWings = wings;
      if (output != undefined) output(wings);
      return wings;
    },
    save(wings) {
      grid.selectedWings = wings;
      localStorage.setItem("wings", JSON.stringify(wings));
    }
  };
  var result = {
    state: false,
    single: undefined,
    method: undefined,
    accepted: false,
    selectWing: function(e) {
      e.preventDefault();
      var wing = parseInt($(this).attr("item-id"));
      var wingStatus = $(this).attr("checked") == undefined ? false : true;
      if (wingStatus) {
        result.addWing(wing);
      } else {
        result.removeWing(wing);
      }
    },
    addWing: function(wing) {
      grid.getSelectedWings(function(wings) {
        if (wings.indexOf(wing) == -1) {
          wings.push(wing);
          grid.save(wings);
        }
      });
      result.updateCounterState();
    },
    removeWing: function(wing) {
      grid.getSelectedWings(function(wings) {
        var index = wings.indexOf(wing);
        wings.splice(index, 1);
        grid.save(wings);
      });
      result.updateCounterState();
    },
    downloadWing: function(e) {
      e.preventDefault();
      if (!result.state) {
        result.state = true;
        result.single = $(this).attr("w-id");
        result.method = methods.SINGLE;
        result.openTermsDialog(e);
      }
    },
    downloadSelecteds: function(e) {
      e.preventDefault();
      if (!result.state) {
        result.state = true;
        result.method = methods.ALL;
        result.openTermsDialog(e);
      }
    },
    openTermsDialog: function(event) {
      $.get(_env.host + "terms/partial", function(html) {
        $("#myModal .modal-content .modal-body").html(html);
      });
    },
    acceptTerms: function(e) {
      e.preventDefault();
      var data = [];
      if (result.state) {
        if (result.method == methods.ALL) {
          if (grid.selectedWings.length > 0) {
            data = grid.selectedWings;
            result.clear();
          } else {
            alert("Select at least 1 file");
            return;
          }
        } else if (result.method == methods.SINGLE) {
          data.push(result.single);
        }
      }

      result.requestDownloadFiles(data);
      result.accepted = false;
      result.single = undefined;
      wing = undefined;
      result.state = false;
    },
    declineTerms: function(e) {
      e.preventDefault();
      result.accepted = false;
      result.single = undefined;
    },
    mathSelectedsWithResult: function() {
      grid.getSelectedWings(function(wings) {
        $(".wing-selector").removeAttr("checked");
        $(".wing-selector").each(function(index, item) {
          if (wings.indexOf(parseInt($(item).attr("item-id"))) != -1) {
            $(item).attr("checked", "checked");
          }
        });
        result.updateCounterState();
      });
    },
    updateCounterState() {
      $(".selected-files-counter").html(grid.selectedWings.length);
    },
    clear: function() {
      localStorage.clear();
      result.mathSelectedsWithResult();
    },
    deleteFromList() {
      result.removeWing(parseInt($(this).attr("w-id")));
      result.updateCounterState();
      result.findByIds();
    },
    requestDownloadFiles: function(data) {
      var win = window.open(_env.host + "download/wings?files=" + data, "_blank");
      win.focus();
    },
    findByIds: function() {
      $.get(_env.host + "result/byids?wingsIds=" + grid.selectedWings, function(data) {
        result.loadSelectedWingsOnTable(data);
      });
    },
    loadSelectedWingsOnTable: function(data) {
      var element = $(".selecteds-wings-list");
      $(".selecteds-wings-list li").remove();
      data.forEach(item => {
        var gender = item.gender == 70 ? "Female" : "Male";
        var side = item.wingSide == 76 ? "Left" : "Right";
        var date = new Date(item.samplingDate);
        var sampling =
          date
            .toISOString()
            .slice(0, 10)
            .replace(/-/g, "/") +
          " " +
          ("0" + date.getHours()).slice(-2) +
          ":" +
          ("0" + date.getMinutes()).slice(-2);
        console.log(sampling);
        element.append(
          '<li class="list-group-item">  <table> <td>' +
            item.title +
            '</td>   <td style="width:20px;"> <button  style="cursor:pointer" class="btn btn-danger btn-sm remove-wing" w-id="' +
            item.id +
            '"><i class="glyphicon glyphicon-trash"></i></button> </td> </table> <table style="font-size: 10px;  color: #999"> <td style="padding-right:8px"> <b>Gender:</b> ' +
            gender +
            ' </td> <td style="padding-right:8px"> <b>Side:</b> ' +
            side +
            ' </td> <td style="padding-right:8px"> <b>Sampling:</b> ' +
            sampling +
            " </td></table> </li> "
        );
      });
    },
    gridResize() {
      var w = $(window).width();
      if (w < 767) {
        $(".teste-resp").width(w - 34);
      }
    },
    init: function() {
      $("body").on("click", ".download-file", result.downloadWing);
      $("body").on("click", "#download-selcteds", result.downloadSelecteds);
      $("body").on("change", ".wing-selector", result.selectWing);
      $("body").on("click", "#confirm-dialog", result.acceptTerms);
      $("body").on("click", ".close-dialog", result.declineTerms);
      $("body").on("click", "#selected-wings-dialog", result.findByIds);
      $("body").on("click", ".remove-wing", result.deleteFromList);
      $("body").on("click", ".clear-selected-files", result.clear);
      result.mathSelectedsWithResult();
      result.gridResize();
      // localStorage.clear();
    }
  };
  result.init();
});
