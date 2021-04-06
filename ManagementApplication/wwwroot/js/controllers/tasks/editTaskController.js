managementApplication
    .controller('EditTaskController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $scope.task =
        {
            taskName: '',
            taskDescription: '',
            employeeId: '',
            deadline: ''
        };

        $scope.taskEmployee =
        {
            employee: {}
        };

        $scope.employees = [];
        $http.get('api/Employees')
            .then(function (response) {
                $scope.employees = response.data;
            })

        $http.get('api/Tasks/' + $routeParams.taskId)
            .then(function (response) {
                $scope.task = response.data;
            });

        $scope.editTask = function () {

            $scope.task.employeeId = $scope.taskEmployee.employee.id;

            $http.put('api/Tasks/' + $routeParams.taskId, $scope.task)
                .then(function (response) {
                    $location.path('/tasks');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editTask/:taskId',
                {
                    templateUrl: 'pages/tasks/edit.html',
                    controller: 'EditTaskController'
                })
    });