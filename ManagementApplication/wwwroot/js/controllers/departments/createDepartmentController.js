managementApplication
    .controller('CreateDepartmentController', ['$scope', '$http', '$location', function ($scope, $http, $location) {
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

        $scope.addDepartment = function () {

            $scope.department.regionId = $scope.departmentRegion.region.id;

            $http.post('api/Departments', $scope.department)
                .then(function (response) {
                    $location.path('/departments');
                });
        };
    }]);

managementApplication
    .config(function ($routeProvider) {
        $routeProvider
            .when('/createDepartment',
                {
                    templateUrl: 'pages/departments/create.html',
                    controller: 'CreateDepartmentController'
                })
    });