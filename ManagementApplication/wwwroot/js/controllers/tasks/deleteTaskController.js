managementApplication
    .controller('DeleteTaskController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $scope.task = {};

        $http.get('api/tasks/' + $routeParams.taskId)
            .then(function (response) {
                $scope.task = response.data;
            });

        $scope.deleteTask = function () {
            $http.delete('api/Tasks/' + $routeParams.taskId, $scope.task)
                .then(function (response) {
                    $location.path('/tasks');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteTask/:taskId',
                {
                    templateUrl: 'pages/tasks/delete.html',
                    controller: 'DeleteTaskController'
                })
    });