// Create AngularJS application.
var managementApplication = angular.module('ManagementApplicationSPA', ['ngRoute']);

// Add the default configuration to the application. 
managementApplication.config(function ($routeProvider) {
    $routeProvider
        .when('/',
            {
                templateUrl: 'pages/home/index.html',
                controller: 'IndexController'
            })
        // If link is not defined in configurations, then user will
        // be redirected to the default page.
        .otherwise({
            redirectTo: '/'
        });
});