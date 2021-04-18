managementApplication
    .controller('EditRegionController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $scope.region =
        {
            id: 0
        };

        $http.get('api/Regions/' + $routeParams.regionId)
            .then(function (response) {
                $scope.region = response.data;
            });

        $scope.editRegion = function () {
            $http.put('api/Regions/' + $routeParams.regionId, $scope.region)
                .then(function (response) {
                    $location.path('/regions');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editRegion/:regionId',
                {
                    templateUrl: 'pages/regions/edit.html',
                    controller: 'EditRegionController'
                })
    });