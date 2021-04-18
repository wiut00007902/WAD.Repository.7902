managementApplication
    .controller('DetailsTasksController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
        $scope.task = {};

        $http.get('api/Tasks/' + $routeParams.taskId)
            .then(function (response) {
                $scope.task = response.data;
            });
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/taskDetails/:taskId',
                {
                    templateUrl: 'pages/tasks/details.html',
                    controller: 'DetailsTasksController'
                })
    });