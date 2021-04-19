// Add EditTaskController to the application
managementApplication
    .controller('EditTaskController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {

        // Declare variable task to keep all user input and preset input fields.
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

        // Get the task by its ID passing route parameter taskId to the link
        $http.get('api/Tasks/' + $routeParams.taskId)
            .then(function (response) {
                $scope.task = response.data;
            });

        // Create the function editTask().
        $scope.editTask = function () {

            // Initialize task.employeeId to taskEmployee.employee.id.
            $scope.task.employeeId = $scope.taskEmployee.employee.id;

            // Put the final task.
            $http.put('api/Tasks/' + $routeParams.taskId, $scope.task)
                .then(function (response) {
                    // Then go to the list of tasks.
                    $location.path('/tasks');
                });
        };
    }]);

// Add configuration to the application. If link is #!/editTask/:taskId, then
// edit.html in tasks folder will be loaded and EditTaskController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editTask/:taskId',
                {
                    templateUrl: 'pages/tasks/edit.html',
                    controller: 'EditTaskController'
                })
    });