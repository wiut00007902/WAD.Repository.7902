// Add TaskController to the application
managementApplication
    .controller('TasksController', ['$scope', '$http', function ($scope, $http) {

        // Declare variable tasks to keep list of tasks.
        $scope.tasks = [];

        // Get list of the tasks and initialize it to the variable tasks.
        $http.get('api/Tasks')
            .then(function (response) {
                $scope.tasks = response.data;
            })
    }]);

// Add configuration to the application. If link is #!/tasks, then
// index.html in tasks folder will be loaded and TasksController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/tasks',
                {
                    templateUrl: 'pages/tasks/index.html',
                    controller: 'TasksController'
                })
    });