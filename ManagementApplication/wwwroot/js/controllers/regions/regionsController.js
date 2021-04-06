managementApplication
    .controller('ReionsController', ['$scope', '$http', function ($scope, $http) {
        $scope.regions = [];
        $http.get('api/Regions')
            .then(function (response) {
                $scope.regions = response.data;
            })
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