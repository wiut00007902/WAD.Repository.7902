// Add RegionsController to the application
managementApplication
    .controller('RegionsController', ['$scope', '$http', function ($scope, $http) {
        // Declare variable regions to keep list of tasks.
        $scope.regions = [];

        // Get list of the regions and initialize it to the variable regions.
        $http.get('api/Regions')
            .then(function (response) {
                $scope.regions = response.data;
            })
    }]);

// Add configuration to the application. If link is #!/regions, then
// index.html in regions folder will be loaded and RegionsController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/regions',
                {
                    templateUrl: 'pages/regions/index.html',
                    controller: 'RegionsController'
                })
    });