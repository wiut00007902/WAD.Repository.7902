// Add DeleteRegionController to the application
managementApplication
    .controller('DeleteRegionController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location,$routeParams) {
        // Declare variable region to keep present all the data about it.
        $scope.region =
        {
            id: 0
        };

        // Get the region by its ID passing route parameter regionId to the link.
        $http.get('api/Regions/' + $routeParams.regionId)
            .then(function (response) {
                // Initialize region to the response of the server.
                $scope.region = response.data;
            });

        // Create the function deleteRegion().
        $scope.deleteRegion = function () {
            // Delete the region.
            $http.delete('api/Regions/' + $routeParams.regionId, $scope.region)
                .then(function (response) {
                    // Then go to the list of regions.
                    $location.path('/regions');
                });
        };
    }]);

// Add configuration to the application. If link is #!/deleteRegion/:regionId, then
// delete.html in regions folder will be loaded and DeleteRegionController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteRegion/:regionId',
                {
                    templateUrl: 'pages/regions/delete.html',
                    controller: 'DeleteRegionController'
                })
    });