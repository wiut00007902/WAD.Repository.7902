managementApplication
    .controller('EmployeesController', ['$scope', '$http', function ($scope, $http) {
        $scope.employees = [];
        $http.get('api/Employees')
            .then(function (response) {
                $scope.employees = response.data;
            })

        $scope.deleteEmployee = function (employee) {
            $http.delete('api/Employees/' + employee.id).then(function (response) {
                var index = $scope.employees.indexOf(employee);
                $scope.employees.splice(index, 1);
            })
        }
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