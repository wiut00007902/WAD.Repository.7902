managementApplication
    .controller('TasksController', ['$scope', '$http', function ($scope, $http) {
        $scope.tasks = [];
        $http.get('api/Tasks')
            .then(function (response) {
                $scope.tasks = response.data;
            })

        $scope.deleteTask = function (task) {
            $http.delete('api/Tasks/' + task.id).then(function (response) {
                var index = $scope.tasks.indexOf(task);
                $scope.tasks.splice(index, 1);
            })
        }
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/tasks',
                {
                    templateUrl: 'pages/tasks/index.html',
                    controller: 'TasksController'
                })
    });