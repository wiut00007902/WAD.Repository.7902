// Add DeleteDepartmentController to the application
managementApplication
    .controller('DeleteDepartmentController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        // Declare variable department to keep present all the data about it.
        $scope.department =
        {
            regionId: 0
        };

        // Get the department by its ID passing route parameter departmentId to the link.
        $http.get('api/Departments/' + $routeParams.departmentId)
            .then(function (response) {
                // Initialize department to the response of the server.
                $scope.department = response.data;
            });

        // Create the function deleteDepartment().
        $scope.deleteDepartment = function () {
            // Delete the department.
            $http.delete('api/Departments/' + $routeParams.departmentId, $scope.department)
                .then(function (response) {
                    // Then go to the list of departments.
                    $location.path('/departments');
                });
        };
    }]);

// Add configuration to the application. If link is #!/deleteDepartment/:departmentId, then
// delete.html in departments folder will be loaded and DeleteDepartmentController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteDepartment/:departmentId',
                {
                    templateUrl: 'pages/departments/delete.html',
                    controller: 'DeleteDepartmentController'
                })
    });