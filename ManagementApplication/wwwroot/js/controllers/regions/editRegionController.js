// Add EditRegionController to the application
managementApplication
    .controller('EditRegionController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {

        // Declare variable region to keep all user input and preset input fields.
        $scope.region =
        {
            id: 0
        };

        // Get the region by its ID passing route parameter regionId to the link
        $http.get('api/Regions/' + $routeParams.regionId)
            .then(function (response) {
                // Initialize region to the response of the server.
                $scope.region = response.data;
            });

        // Create the function editRegion().
        $scope.editRegion = function () {
            // Put the final region.
            $http.put('api/Regions/' + $routeParams.regionId, $scope.region)
                .then(function (response) {
                    // Then go to the list of regions.
                    $location.path('/regions');
                });
        };
    }]);

// Add configuration to the application. If link is #!/editRegion/:regionId, then
// edit.html in regions folder will be loaded and EditRegionController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editRegion/:regionId',
                {
                    templateUrl: 'pages/regions/edit.html',
                    controller: 'EditRegionController'
                })
    });