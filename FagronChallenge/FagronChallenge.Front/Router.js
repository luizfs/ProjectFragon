﻿/// <reference path="scripts/angular.js" />

var MyApp = angular.module("MyApp", ['ngRoute', 'CustomerService', 'pascalprecht.translate', 'ui.mask']);

MyApp.config(['$routeProvider', '$translateProvider',
    function ($routeProvider, $translateProvider) {
        $routeProvider.
            when('/AddCustomers', {
                templateUrl: 'Views/AddCustomers.html',
                controller: 'AddCustomersController'
            }).
            when('/EditCustomers/:id', {
                templateUrl: 'Views/EditCustomers.html',
                controller: 'EditCustomersController'
            }).
            when('/ListCustomers', {
                templateUrl: 'Views/ListCustomers.html',
                controller: 'ListCustomersController'
            }).
            when('/DetailsCustomers/:id', {
                templateUrl: 'Views/DetailsCustomers.html',
                controller: 'DetailsCustomersController'
            }).
            otherwise({
                redirectTo: '/ListCustomers'
            });
        $translateProvider.useStaticFilesLoader({
            prefix: 'Translations/',
            suffix: '.json',
        });

        $translateProvider.preferredLanguage('pt');
    }
]);

