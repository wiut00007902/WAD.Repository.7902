managementApplication
    .controller('CreateRegionController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
        $scope.region =
        {
            id: 0,
            regionName: '',
        };

        $scope.addRegion = function () {
            $http.post('api/Regions', $scope.region)
                .then(function (response) {
                    $location.path('/regions');
                });
        };
    }])

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createRegion',
                {
                    templateUrl: 'pages/regions/create.html',
                    controller: 'CreateRegionController'
                })
    });