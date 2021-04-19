// Add CreateRegionController to the application
managementApplication
    .controller('CreateRegionController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
        // Declare variable region to keep all user input.
        $scope.region =
        {
            id: 0,
            regionName: '',
        };

        // Create the function addRegion().
        $scope.addRegion = function () {
            // Post the final region.
            $http.post('api/Regions', $scope.region)
                .then(function (response) {
                    // Then go to the list of regions
                    $location.path('/regions');
                });
        };
    }])

// Add configuration to the application. If link is #!/createRegion, then
// create.html in regions folder will be loaded and CreateRegionController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createRegion',
                {
                    templateUrl: 'pages/regions/create.html',
                    controller: 'CreateRegionController'
                })
    });