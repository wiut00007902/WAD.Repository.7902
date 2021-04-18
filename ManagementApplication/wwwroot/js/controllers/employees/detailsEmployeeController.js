managementApplication
    .controller('DetailsEmployeeController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
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
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/employeeDetails/:employeeId',
                {
                    templateUrl: 'pages/employees/details.html',
                    controller: 'DetailsEmployeeController'
                })
    });