$(document).ready(function() {
  var vm = {
    familyId: undefined,
    genusId: undefined,
    specieId: undefined,
    subfamilyId: undefined,
    subgenusId: undefined,
    subspecieId: undefined,
    tribeId: undefined
  };
  var search = {
    getFamilies: function() {
      $.get(_env.host + "search/GetFamlies", function(data) {
        $("#select-family option").remove();
        $("#select-family").append(
          $('<option selected="selected" value="">Select family</option>')
        );
        $.each(data, function(index, item) {
          $("#select-family").append(
            $("<option></option>")
              .text(item.name)
              .val(item.id)
          );
        });
      });
    },
    getSubfamilies: function() {
      $.ajax({
        url: _env.host + "search/GetSubfamilies",
        type: "get",
        data: search.getVm(),
        success: function(data) {
          $("#select-subfamily option").remove();
          $("#select-subfamily").append(
            $('<option value="" selected="selected">Select subfamily</option>')
          );
          $.each(data, function(index, item) {
            $("#select-subfamily").append(
              $("<option></option>")
                .text(item.name)
                .val(item.id)
            );
          });
        },
        error: function(xhr) {}
      });
    },
    getTribes: function() {
      $.ajax({
        url: _env.host + "search/GetTribes",
        type: "get",
        data: search.getVm(),
        success: function(data) {
          $("#select-tribe option").remove();
          $("#select-tribe").append(
            $('<option value="" selected="selected">Select tribe</option>')
          );
          $.each(data, function(index, item) {
            $("#select-tribe").append(
              $("<option></option>")
                .text(item.name)
                .val(item.id)
            );
          });
        },
        error: function(xhr) {}
      });
    },
    getGenus: function() {
      $.ajax({
        url: _env.host + "search/GetGenus",
        type: "get",
        data: search.getVm(),
        success: function(data) {
          $("#select-genus option").remove();
          $("#select-genus").append(
              $('<option value="" selected="selected">Select genus</option>')
          );
          $.each(data, function(index, item) {
            $("#select-genus").append(
              $("<option></option>")
                .text(item.name)
                .val(item.id)
            );
          });
        },
        error: function(xhr) {}
      });
    },
    getSubGenus: function() {
      $.ajax({
        url: _env.host + "search/GetSubgenus",
        type: "get",
        data: search.getVm(),
        success: function(data) {
          $("#select-subgenus option").remove();
          $("#select-subgenus").append(
              $('<option value="" selected="selected">Select Subgenus</option>')
          );
          $.each(data, function(index, item) {
            $("#select-subgenus").append(
              $("<option></option>")
                .text(item.name)
                .val(item.id)
            );
          });
        },
        error: function(xhr) {}
      });
    },
    getSpecies: function() {
      $.ajax({
        url: _env.host + "search/GetSpecies",
        type: "get",
        data: search.getVm(),
        success: function(data) {
          $("#select-specie option").remove();
          $("#select-specie").append(
            $('<option selected="selected">Select specific epithet</option>')
          );
          $.each(data, function(index, item) {
            $("#select-specie").append(
              $("<option></option>")
                .text(item.name)
                .val(item.id)
            );
          });
        },
        error: function(xhr) {}
      });
    },
    getSubspecies: function() {
      $.ajax({
        url: _env.host + "search/GetSubspecies",
        type: "get",
        data: search.getVm(),
        success: function(data) {
          $("#select-subspecie option").remove();
          $("#select-subspecie").append(
            $('<option selected="selected">Select species</option>')
          );
          $.each(data, function(index, item) {
            $("#select-subspecie").append(
              $("<option></option>")
                .text(item.name)
                .val(item.id)
            );
          });
        },
        error: function(xhr) {}
      });
    },
    getVm: function() {
      vm.familyId = $("#select-family").val();
      vm.subfamilyId = $("#select-subfamily").val();
      vm.genusId = $("#select-genus").val();
      // vm.subgenusId = $("#select-subgenus").val();
      vm.specieId = $("#select-specie").val();
      // vm.subspecieId = $("#select-subspecie").val();
      vm.tribeId = $("#select-tribe").val();
      return vm;
    },
    familyChanged: function() {
        search.getTribes();
        search.getSubfamilies();
    },
    subfamilyChanged: function () {
         search.getSpecies();
         search.getTribes();
         search.getGenus();
    },
    tribeChanged: function() {
      search.getGenus();
    },
    genusChanged: function() {
      search.getSpecies();
    },
    // subgenusChanged: function () {
    //     search.getSpecies();
    // },
    // specieChanged: function () {
    //     search.getSpecies();
    // },
    refresh: function() {
      search.getFamilies();
      search.getSpecies();
    },
    init: function() {
      search.getVm();
      search.refresh();
      $("body").on("change", "#select-family", search.familyChanged);
      $("body").on("change", "#select-subfamily", search.subfamilyChanged);
      $("body").on("change", "#select-genus", search.genusChanged);
      // $("body").on("change", "#select-subgenus", search.subgenusChangedspe);
      // $("body").on("change", "#select-specie", search.specieChanged);
      $("body").on("change", "#select-tribe", search.tribeChanged);
    }
  };
  search.init();
});

var placeSearch, autocomplete;
var componentForm = {
  locality: "short_name",
  administrative_area_level_1: "short_name",
  country: "short_name",
  administrative_area_level_2: "short_name"
};

function initAutocomplete() {
  // Create the autocomplete object, restricting the search to geographical
  // location types.
  autocomplete = new google.maps.places.Autocomplete(
    document.getElementById("locality"),
    {
      types: ["geocode"]
    }
  );

  // When the user selects an address from the dropdown, populate the address
  // fields in the form.
  autocomplete.addListener("place_changed", fillInAddress);
}

function fillInAddress() {
  // Get the place details from the autocomplete object.
  var place = autocomplete.getPlace();

  console.log("place");
  console.log(place);
  for (var component in componentForm) {
    document.getElementById(component).value = "";
  }

  // Get each component of the address from the place details
  // and fill the corresponding field on the form.
  for (var i = 0; i < place.address_components.length; i++) {
    var addressType = place.address_components[i].types[0];
    if (componentForm[addressType]) {
      var val = place.address_components[i][componentForm[addressType]];
      console.log(addressType);
      document.getElementById(addressType).value = val;
    }
  }
}

// Bias the autocomplete object to the user's geographical location,
// as supplied by the browser's 'navigator.geolocation' object.
function geolocate() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(function(position) {
      var geolocation = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      };
      var circle = new google.maps.Circle({
        center: geolocation,
        radius: position.coords.accuracy
      });
      autocomplete.setBounds(circle.getBounds());
    });
  }
}
