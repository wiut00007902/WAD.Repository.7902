var managementApplication = angular.module('ManagementApplicationSPA', ['ngRoute']);

managementApplication
    .controller('IndexController', ['$scope', '$http', function ($scope, $http) {
        $scope.message = 'Welcome text';
    }]);

managementApplication.config(function ($routeProvider) {
    $routeProvider
        .when('/',
            {
                templateUrl: 'pages/home/index.html',
                controller: 'IndexController'
            })
        .otherwise({
            redirectTo: '/'
        });
});