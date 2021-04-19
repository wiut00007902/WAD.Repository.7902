// Add CreateEmployeeController to the application
managementApplication
    .controller('CreateEmployeeController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
        // Declare variable employee to keep all user input.
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

        // Create the function addEmployee().
        $scope.addEmployee = function () {

            // Initialize employee.departmentId to employeeDepartments.department.id.
            $scope.employee.departmentId = $scope.employeeDepartments.department.id;

            // Converting selected value from string to int by substracting zero.
            $scope.employee.gender = $scope.employee.gender - 0;
            $scope.employee.schedule = $scope.employee.schedule - 0;

            // Post the final employee.
            $http.post('api/Employees', $scope.employee)
                .then(function (response) {
                    // Then go to the list of employees.
                    $location.path('/employees');
                });
        };
    }]);

// Add configuration to the application. If link is #!/createEmployee, then
// create.html in employees folder will be loaded and CreateEmployeeController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createEmployee',
                {
                    templateUrl: 'pages/employees/create.html',
                    controller: 'CreateEmployeeController'
                })
    });