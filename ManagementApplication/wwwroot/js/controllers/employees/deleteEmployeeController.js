// Add DeleteEmployeeController to the application
managementApplication
    .controller('DeleteEmployeeController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        // Declare variable employee to keep present all the data about it.
        $scope.employee = {}; 

        // Get the employee by its ID passing route parameter employeeId to the link.
        $http.get('api/Employees/' + $routeParams.employeeId)
            .then(function (response) {
                // Initialize employee to the response of the server.
                $scope.employee = response.data;
            });

        // Create the function deleteEmployee().
        $scope.deleteEmployee = function () {
            // Delete the employee.
            $http.delete('api/Employees/' + $routeParams.employeeId, $scope.employee)
                .then(function (response) {
                    // Then go to the list of employees.
                    $location.path('/employees');
                });
        };
    }]);

// Add configuration to the application. If link is #!/deleteEmployee/:employeeId, then
// delete.html in employees folder will be loaded and DeleteEmployeeController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteEmployee/:employeeId',
                {
                    templateUrl: 'pages/employees/delete.html',
                    controller: 'DeleteEmployeeController'
                })
    });