managementApplication
    .controller('TasksController', ['$scope', '$http', function ($scope, $http) {
        $scope.tasks = [];
        $http.get('api/Tasks')
            .then(function (response) {
                $scope.tasks = response.data;
            })
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