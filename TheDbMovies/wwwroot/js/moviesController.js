// moviesController.js 

(function () {

    "use strict"

    // Getting the existing module 

    angular.module("myApp-movies")
        .controller("moviesController", moviesController);

    function moviesController($http) {

        var vm = this;
        vm.movies = [];
        vm.newMovie = {};
        vm.errorMessage = "";
        vm.isBusy = "";

        $http.get("/api/trips")
            .then(function (response) {
                // Success
                angular.copy(response.data, vm.movies);
            }, function (error) {
                // Failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {

                vm.isBusy = false;

            });

    }

})();