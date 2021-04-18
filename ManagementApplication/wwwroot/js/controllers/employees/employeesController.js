managementApplication
    .controller('EmployeesController', ['$scope', '$http', function ($scope, $http) {
        $scope.employees = [];
        $http.get('api/Employees')
            .then(function (response) {
                $scope.employees = response.data;
            })
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/employees',
                {
                    templateUrl: 'pages/employees/index.html',
                    controller: 'EmployeesController'
                })
    });