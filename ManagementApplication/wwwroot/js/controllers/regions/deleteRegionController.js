managementApplication
    .controller('DeleteRegionController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location,$routeParams) {
        $scope.region =
        {
            id: 0
        };

        $http.get('api/Regions/' + $routeParams.regionId)
            .then(function (response) {
                $scope.region = response.data;
            });

        $scope.deleteRegion = function () {
            $http.delete('api/Regions/' + $routeParams.regionId, $scope.region)
                .then(function (response) {
                    $location.path('/regions');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteRegion/:regionId',
                {
                    templateUrl: 'pages/regions/delete.html',
                    controller: 'DeleteRegionController'
                })
    });