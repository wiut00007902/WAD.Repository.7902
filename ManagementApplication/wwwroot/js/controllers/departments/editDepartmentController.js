// Add EditDepartmentController to the application
managementApplication
    .controller('EditDepartmentController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {

         // Declare variable department to keep all user input and preset input fields.
        $scope.department =
        {
            regionId: 0
        };

        // Declare variable departmentRegion to refer to the speciffic
        // region ID of the department.
        $scope.departmentRegion =
        {
            region: {}
        };

        // Declare variable regions keep list of regions.
        $scope.regions = [];

        // Get list of the regions and initialize it to the variable regions.
        $http.get('api/Regions')
            .then(function (response) {
                $scope.regions = response.data;
            })

        // Get the department by its ID passing route parameter departmentId to the link
        $http.get('api/Departments/' + $routeParams.departmentId)
            .then(function (response) {
                // Initialize department to the response of the server.
                $scope.department = response.data;
            });

        // Create the function editDepartment().
        $scope.editDepartment = function () {

            // Initialize department.regionId to departmentRegion.region.id.
            $scope.department.regionId = $scope.departmentRegion.region.id;

            // Put the final department.
            $http.put('api/Departments/' + $routeParams.departmentId, $scope.department)
                .then(function (response) {
                    // Then go to the list of departments.
                    $location.path('/departments');
                });
        };
    }]);

// Add configuration to the application. If link is #!/editDepartment/:departmentId, then
// edit.html in departments folder will be loaded and EditDepartmentController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editDepartment/:departmentId',
                {
                    templateUrl: 'pages/departments/edit.html',
                    controller: 'EditDepartmentController'
                })
    });