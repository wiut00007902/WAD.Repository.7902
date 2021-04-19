// Add DepartmentsController to the application
managementApplication
    .controller('DepartmentsController', ['$scope', '$http', function ($scope, $http) {
        // Declare variable departments to keep list of departments.
        $scope.departments = [];

        // Get list of the departments and initialize it to the variable departments.
        $http.get('api/Departments')
            .then(function (response) {
                $scope.departments = response.data;
            })
    }]);

// Add configuration to the application. If link is #!/departments, then
// index.html in departments folder will be loaded and DepartmentsController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/departments',
                {
                    templateUrl: 'pages/departments/index.html',
                    controller: 'DepartmentsController'
                })
    });