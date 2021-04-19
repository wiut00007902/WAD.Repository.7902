// Add CreateDepartmentController to the application
managementApplication
    .controller('CreateDepartmentController', ['$scope', '$http', '$location', function ($scope, $http, $location) {

        // Declare variable department to keep all user input.
        $scope.department =
        {
            departmentName: '',
            regionId: 0,
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

        // Create the function addDepartment().
        $scope.addDepartment = function () {

            // Initialize department.regionId to departmentRegion.region.id.
            $scope.department.regionId = $scope.departmentRegion.region.id;

            // Post the final department.
            $http.post('api/Departments', $scope.department)
                .then(function (response) {
                    // Then go to the list of departments.
                    $location.path('/departments');
                });
        };
    }]);

// Add configuration to the application. If link is #!/createDepartment, then
// create.html in departments folder will be loaded and CreateDepartmentController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createDepartment',
                {
                    templateUrl: 'pages/departments/create.html',
                    controller: 'CreateDepartmentController'
                })
    });