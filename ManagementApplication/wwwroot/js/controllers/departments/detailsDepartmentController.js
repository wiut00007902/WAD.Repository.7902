managementApplication
    .controller('DetailsDepartmentController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
        $scope.department =
        {
            id: 0
        };

        $http.get('api/Departments/' + $routeParams.departmentId)
            .then(function (response) {
                $scope.department = response.data;
            });
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/departmentDetails/:departmentId',
                {
                    templateUrl: 'pages/departments/details.html',
                    controller: 'DetailsDepartmentController'
                })
    });