// Add DetailsEmployeeController to the application
managementApplication
    .controller('DetailsEmployeeController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
        // Declare variable employee to represent it on the page.
        $scope.employee = {};

        // Get the employee by its ID passing route parameter employeeId to the link
        $http.get('api/Employees/' + $routeParams.employeeId)
            .then(function (response) {
                // Initialize employee to the response of the server.
                $scope.employee = response.data;
            });
    }]);

// Add configuration to the application. If link is #!/employeeDetails/:employeeId, then
// details.html in employees folder will be loaded and DetailsEmployeeController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/employeeDetails/:employeeId',
                {
                    templateUrl: 'pages/employees/details.html',
                    controller: 'DetailsEmployeeController'
                })
    });