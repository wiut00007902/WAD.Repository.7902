// Add DetailsDepartmentController to the application
managementApplication
    .controller('DetailsDepartmentController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
        // Declare variable department to represent it on the page.
        $scope.department =
        {
            id: 0
        };

        // Get the department by its ID passing route parameter departmentId to the link
        $http.get('api/Departments/' + $routeParams.departmentId)
            .then(function (response) {
                // Initialize department to the response of the server.
                $scope.department = response.data;
            });
    }]);

// Add configuration to the application. If link is #!/departmentDetails/:departmentId, then
// details.html in departments folder will be loaded and DetailsDepartmentController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/departmentDetails/:departmentId',
                {
                    templateUrl: 'pages/departments/details.html',
                    controller: 'DetailsDepartmentController'
                })
    });