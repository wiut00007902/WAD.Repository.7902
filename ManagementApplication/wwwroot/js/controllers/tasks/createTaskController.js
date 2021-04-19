// Add CreateTaskController to the application
managementApplication
    .controller('CreateTaskController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
        // Declare variable task to keep all user input.
        $scope.task =
        {
            taskName: '',
            taskDescription: '',
            employeeId: '',
            deadline: ''
        };

        // Declare variable taskEmployee to refer to the speciffic
        // employee ID of the task.
        $scope.taskEmployee =
        {
            employee: {}
        };

        // Declare variable employees keep list of employees.
        $scope.employees = [];

        // Get list of the employees and initialize it to the variable employees.
        $http.get('api/Employees')
            .then(function (response) {
                $scope.employees = response.data;
            })

        // Create the function addTask().
        $scope.addTask = function () {
            // Initialize task.employeeId to taskEmployee.employee.id.
            $scope.task.employeeId = $scope.taskEmployee.employee.id;
            // Post the final task.
            $http.post('api/Tasks', $scope.task)
                .then(function (response) {
                    // Then go to the list of tasks.
                    $location.path('/tasks');
                });
        };
    }]);

// Add configuration to the application. If link is #!/createTask, then
// create.html in tasks folder will be loaded and CreateTaskController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createTask',
                {
                    templateUrl: 'pages/tasks/create.html',
                    controller: 'CreateTaskController'
                })
    });