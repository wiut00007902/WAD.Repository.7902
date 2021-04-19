// Add DetailsRegionController to the application
managementApplication
    .controller('DetailsRegionController', ['$scope', '$http', '$routeParams', function ($scope, $http,  $routeParams) {
        // Declare variable region to represent it on the page.
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
    }]);

// Add configuration to the application. If link is #!/regionDetails/:regionId, then
// details.html in regions folder will be loaded and DetailsRegionController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/regionDetails/:regionId',
                {
                    templateUrl: 'pages/regions/details.html',
                    controller: 'DetailsRegionController'
                })
    });