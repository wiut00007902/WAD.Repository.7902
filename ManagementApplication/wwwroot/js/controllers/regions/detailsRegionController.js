managementApplication
    .controller('DetailsRegionController', ['$scope', '$http', '$routeParams', function ($scope, $http,  $routeParams) {
        $scope.region =
        {
            id: 0
        };

        $http.get('api/Regions/' + $routeParams.regionId)
            .then(function (response) {
                $scope.region = response.data;
            });
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/regionDetails/:regionId',
                {
                    templateUrl: 'pages/regions/details.html',
                    controller: 'DetailsRegionController'
                })
    });