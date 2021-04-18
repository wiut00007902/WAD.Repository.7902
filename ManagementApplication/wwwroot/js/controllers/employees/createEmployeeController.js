managementApplication
    .controller('CreateEmployeeController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
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

        $scope.addEmployee = function () {

            $scope.employee.departmentId = $scope.employeeDepartments.department.id;

            $scope.employee.gender = $scope.employee.gender - 0;
            $scope.employee.schedule = $scope.employee.schedule - 0;

            $http.post('api/Employees', $scope.employee)
                .then(function (response) {
                    $location.path('/employees');
                });
        };
    }]);
managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createEmployee',
                {
                    templateUrl: 'pages/employees/create.html',
                    controller: 'CreateEmployeeController'
                })
    });