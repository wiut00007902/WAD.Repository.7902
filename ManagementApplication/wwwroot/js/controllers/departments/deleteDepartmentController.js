managementApplication
    .controller('DeleteDepartmentController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $scope.department =
        {
            regionId: 0
        };

        $http.get('api/Departments/' + $routeParams.departmentId)
            .then(function (response) {
                $scope.department = response.data;
            });

        $scope.deleteDepartment = function () {
            $http.delete('api/Departments/' + $routeParams.departmentId, $scope.department)
                .then(function (response) {
                    $location.path('/departments');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/deleteDepartment/:departmentId',
                {
                    templateUrl: 'pages/departments/delete.html',
                    controller: 'DeleteDepartmentController'
                })
    });