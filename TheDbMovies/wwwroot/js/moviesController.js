// moviesController.js 


(function () {

    "use strict";

    // Getting the existing module
    angular.module("myApp-movies")
        .controller("moviesController", moviesController);

    function moviesController($http) {

        var vm = this;
        vm.movies = [];

        vm.newMovie = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/movies")
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

        vm.addMovie = function () {

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/movies", vm.newMovie)
                .then(function (repsonse) {
                    // Success
                    vm.movies.push(response.data);
                    vm.newMovie = {};

                }, function () {
                    //failure
                    vm.errorMessage = "Failed to save new movie";
                })
                .finally(function () {
                    vm.isBusy = false;

                });

            //vm.trips.push({
            //    name: vm.newTrip.name,
            //    created: new Date()
            //});

            //vm.newTrip = {};
        };


    }

})();