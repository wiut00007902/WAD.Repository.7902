managementApplication
    .controller('CreateTaskController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
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

        $scope.addTask = function () {

            $scope.task.employeeId = $scope.taskEmployee.employee.id;

            $http.post('api/Tasks', $scope.task)
                .then(function (response) {
                    $location.path('/tasks');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createTask',
                {
                    templateUrl: 'pages/tasks/create.html',
                    controller: 'CreateTaskController'
                })
    });