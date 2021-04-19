// Add DeleteTaskController to the application
managementApplication
    .controller('DeleteTaskController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        // Declare variable task to keep present all the data about it.
        $scope.task = {};

        // Get the task by its ID passing route parameter taskId to the link.
        $http.get('api/tasks/' + $routeParams.taskId)
            .then(function (response) {
                $scope.task = response.data;
            });

        // Create the function deleteTask().
        $scope.deleteTask = function () {
            // Delete the task.
            $http.delete('api/Tasks/' + $routeParams.taskId, $scope.task)
                .then(function (response) {
                    // Then go to the list of tasks.
                    $location.path('/tasks');
                });
        };
    }]);

// Add configuration to the application. If link is #!/deleteTask/:taskId, then
// delete.html in tasks folder will be loaded and DeleteTaskController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteTask/:taskId',
                {
                    templateUrl: 'pages/tasks/delete.html',
                    controller: 'DeleteTaskController'
                })
    });