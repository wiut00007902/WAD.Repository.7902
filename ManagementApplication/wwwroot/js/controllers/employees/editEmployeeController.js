// Add EditEmployeeController to the application
managementApplication
    .controller('EditEmployeeController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {

        // Declare variable employee to keep all user input and preset input fields.
        $scope.employee =
        {
            firstName: '',
            lastName: '',
            dateOfBirth: '',
            gender: 0,
            passportNo: '',
            address: '',
            phone: '',
            email: '',
            departmentId: '',
            position: '',
            salary: 0,
            schedule: 0
        };

        // Declare variable employeeDepartments to refer to the speciffic
        // department ID of the employee.
        $scope.employeeDepartments =
        {
            department: {}
        };

        // Declare variable departments keep list of departments.
        $scope.departments = [];

         // Get list of the departments and initialize it to the variable departments.
        $http.get('api/Departments')
            .then(function (response) {
                $scope.departments = response.data;
            })

        // Get the employee by its ID passing route parameter employeeId to the link
        $http.get('api/Employees/' + $routeParams.employeeId)
            .then(function (response) {
                $scope.employee = response.data;
            });

        // Create the function editEmployee().
        $scope.editEmployee = function () {

            // Initialize employee.departmentId to employeeDepartments.department.id.
            $scope.employee.departmentId = $scope.employeeDepartments.department.id;

            // Converting selected value from string to int by substracting zero.
            $scope.employee.gender = $scope.employee.gender - 0;
            $scope.employee.schedule = $scope.employee.schedule - 0;

            // Put the final employee.
            $http.put('api/Employees/' + $routeParams.employeeId, $scope.employee)
                .then(function (response) {
                    // Then go to the list of employees.
                    $location.path('/employees');
                });
        };
    }]);

// Add configuration to the application. If link is #!/editEmployee/:employeeId, then
// edit.html in employees folder will be loaded and EditEmployeeController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editEmployee/:employeeId',
                {
                    templateUrl: 'pages/employees/edit.html',
                    controller: 'EditEmployeeController'
                })
    });