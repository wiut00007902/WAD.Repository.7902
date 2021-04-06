managementApplication
    .controller('EditEmployeeController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
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

        $scope.employeeDepartments =
        {
            department: {}
        };

        $scope.departments = [];
        $http.get('api/Departments')
            .then(function (response) {
                $scope.departments = response.data;
            })

        $http.get('api/Employees/' + $routeParams.employeeId)
            .then(function (response) {
                $scope.employee = response.data;
            });

        $scope.editEmployee = function () {

            $scope.employee.departmentId = $scope.employeeDepartments.department.id;

            $scope.employee.gender = $scope.employee.gender - 0;
            $scope.employee.schedule = $scope.employee.schedule - 0;

            $http.put('api/Employees/' + $routeParams.employeeId, $scope.employee)
                .then(function (response) {
                    $location.path('/employees');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editEmployee/:employeeId',
                {
                    templateUrl: 'pages/employees/edit.html',
                    controller: 'EditEmployeeController'
                })
    });