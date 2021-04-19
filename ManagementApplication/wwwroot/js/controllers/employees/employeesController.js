// Add EmployeesController to the application
managementApplication
    .controller('EmployeesController', ['$scope', '$http', function ($scope, $http) {
        // Declare variable employees to keep list of tasks.
        $scope.employees = [];

        // Get list of the employees and initialize it to the variable employees.
        $http.get('api/Employees')
            .then(function (response) {
                $scope.employees = response.data;
            })
    }]);

// Add configuration to the application. If link is #!/employees, then
// index.html in employees folder will be loaded and EmployeesController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/employees',
                {
                    templateUrl: 'pages/employees/index.html',
                    controller: 'EmployeesController'
                })
    });