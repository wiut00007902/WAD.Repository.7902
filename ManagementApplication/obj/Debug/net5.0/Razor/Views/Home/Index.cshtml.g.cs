#pragma checksum "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "835c0cdb0772b03985a57aa55f061c085d8c755d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\_ViewImports.cshtml"
using ManagementApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\_ViewImports.cshtml"
using ManagementApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"835c0cdb0772b03985a57aa55f061c085d8c755d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"555da32d61ac8385638499be0e6d220d08f9eebf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\Home\Index.cshtml"
   ViewData["Title"] = "Home Page"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div ng-app=""ManagementApplicationSPA"">
    <div ng-view>

    </div>
</div>

<script src=""https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"" type=""text/javascript""></script>
<script src=""https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular-route.min.js"" type=""text/javascript""></script>

<script type=""text/javascript"">
    angular
        .module('ManagementApplicationSPA', ['ngRoute'])
        .config(function ($routeProvider) {
            $routeProvider
                .when('/',
                    {
                        templateUrl: 'pages/home/index.html',
                        controller: 'IndexController'
                    })
                .when('/regions',
                    {
                        templateUrl: 'pages/regions/index.html',
                        controller: 'ReionsController'
                    })
                .when('/departments',
                    {
                        templateUrl: 'pages/departments/index.html',
                  ");
            WriteLiteral(@"      controller: 'DepartmentsController'
                    })
                .when('/employees',
                    {
                        templateUrl: 'pages/employees/index.html',
                        controller: 'EmployeesController'
                    })
                .when('/tasks',
                    {
                        templateUrl: 'pages/tasks/index.html',
                        controller: 'TasksController'
                    })
                .otherwise({
                    redirectTo: '/'
                });
        })
        .controller('IndexController', ['$scope', '$http', function ($scope, $http) {
            $scope.message = 'Welcome text';
        }])
        .controller('ReionsController', ['$scope', '$http', function ($scope, $http) {
            $scope.regions = [];
            $http.get('");
#nullable restore
#line 51 "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\Home\Index.cshtml"
                  Write(Url.Action("GetRegions", "Regions"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"')
                .then(function (response) {
                    $scope.regions = response.data;
                })
        }])
        .controller('DepartmentsController', ['$scope', '$http', function ($scope, $http) {
            $scope.departments = [];
            $http.get('");
#nullable restore
#line 58 "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\Home\Index.cshtml"
                  Write(Url.Action("GetDepartments", "Departments"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"')
                .then(function (response) {
                    $scope.departments = response.data;
                })
        }])
        .controller('EmployeesController', ['$scope', '$http', function ($scope, $http) {
            $scope.employees = [];
            $http.get('");
#nullable restore
#line 65 "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\Home\Index.cshtml"
                  Write(Url.Action("GetEmployees", "Employees"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"')
                .then(function (response) {
                    $scope.employees = response.data;
                })
        }])
        .controller('TasksController', ['$scope', '$http', function ($scope, $http) {
            $scope.tasks = [];
            $http.get('");
#nullable restore
#line 72 "C:\Users\Alo\Documents\WAD.Repository.7902-main\ManagementApplication\Views\Home\Index.cshtml"
                  Write(Url.Action("GetTasks", "Tasks"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\')\n                .then(function (response) {\n                    $scope.tasks = response.data;\n                })\n        }])\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
