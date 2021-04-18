managementApplication
    .controller('DepartmentsController', ['$scope', '$http', function ($scope, $http) {
        $scope.departments = [];
        $http.get('api/Departments')
            .then(function (response) {
                $scope.departments = response.data;
            })
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/departments',
                {
                    templateUrl: 'pages/departments/index.html',
                    controller: 'DepartmentsController'
                })
    });