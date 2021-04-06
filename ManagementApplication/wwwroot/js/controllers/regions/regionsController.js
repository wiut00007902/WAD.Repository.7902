managementApplication
    .controller('ReionsController', ['$scope', '$http', function ($scope, $http) {
        $scope.regions = [];
        $http.get('api/Regions')
            .then(function (response) {
                $scope.regions = response.data;
            })

        $scope.deleteRegion = function (region) {
            $http.delete('api/Regions/' + region.id).then(function (response) {
                var index = $scope.regions.indexOf(region);
                $scope.regions.splice(index, 1);
            })
        }
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/regions',
                {
                    templateUrl: 'pages/regions/index.html',
                    controller: 'ReionsController'
                })
    });