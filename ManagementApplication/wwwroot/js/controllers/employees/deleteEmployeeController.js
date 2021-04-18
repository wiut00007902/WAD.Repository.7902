managementApplication
    .controller('DeleteEmployeeController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $scope.employee =
        {
            firstName: '',
            lastName: '',
            dateOfBirth: '',
            gender: 0,
            passportNo: '',
            address: '',
            phone: '',
            email: '',
            departmentId: '',
            position: '',
            salary: 0,
            schedule: 0
        }; 

        $http.get('api/Employees/' + $routeParams.employeeId)
            .then(function (response) {
                $scope.employee = response.data;
            });

        $scope.deleteEmployee = function () {
            $http.delete('api/Employees/' + $routeParams.employeeId, $scope.employee)
                .then(function (response) {
                    $location.path('/employees');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteEmployee/:employeeId',
                {
                    templateUrl: 'pages/employees/delete.html',
                    controller: 'DeleteEmployeeController'
                })
    });