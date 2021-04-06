managementApplication
    .controller('EditDepartmentController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $scope.department =
        {
            departmentName: '',
            regionId: 0,
        };

        $scope.departmentRegion =
        {
            region: {}
        };

        $scope.regions = [];
        $http.get('api/Regions')
            .then(function (response) {
                $scope.regions = response.data;
            })

        $http.get('api/Departments/' + $routeParams.departmentId)
            .then(function (response) {
                $scope.department = response.data;
            });

        $scope.editDepartment = function () {

            $scope.department.regionId = $scope.departmentRegion.region.id;

            $http.put('api/Departments/' + $routeParams.departmentId, $scope.department)
                .then(function (response) {
                    $location.path('/departments');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/editDepartment/:departmentId',
                {
                    templateUrl: 'pages/departments/edit.html',
                    controller: 'EditDepartmentController'
                })
    });