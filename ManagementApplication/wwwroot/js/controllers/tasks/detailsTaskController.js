// Add DetailsTasksController to the application
managementApplication
    .controller('DetailsTasksController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
        // Declare variable task to represent it on the page.
        $scope.task = {};

        // Get the task by its ID passing route parameter taskId to the link
        $http.get('api/Tasks/' + $routeParams.taskId)
            .then(function (response) {
                // Initialize task to the response of the server.
                $scope.task = response.data;
            });
    }]);

// Add configuration to the application. If link is #!/taskDetails/:taskId, then
// details.html in tasks folder will be loaded and DetailsTasksController will be applied.
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/taskDetails/:taskId',
                {
                    templateUrl: 'pages/tasks/details.html',
                    controller: 'DetailsTasksController'
                })
    });