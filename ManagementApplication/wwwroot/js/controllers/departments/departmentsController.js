managementApplication
    .controller('DepartmentsController', ['$scope', '$http', function ($scope, $http) {
        $scope.departments = [];
        $http.get('api/Departments')
            .then(function (response) {
                $scope.departments = response.data;
            })

        $scope.deleteDepartment = function (department) {
            $http.delete('api/Departments/' + department.id).then(function (response) {
                var index = $scope.departments.indexOf(department);
                $scope.departments.splice(index, 1);
            })
        }
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/departments',
                {
                    templateUrl: 'pages/departments/index.html',
                    controller: 'DepartmentsController'
                })
    });