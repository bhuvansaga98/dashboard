(function () {
    'use strict';
    angular.module('app', ['projectService'])
    .config(['$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state('home', { url: '/', templateUrl: 'app/views/home.html', controller: 'HomeCtrl' })
        .state('projects', { url: '/projects', templateUrl: 'app/views/projects/index.html' })
        .state('project-edit', { url: '/project/:id', templateUrl: 'app/views/projects/edit.html' })
        .state('project-create', { url: '/project/create', templateUrl: 'app/views/projects/create.html' })
        .state('projects', { url: "/projects/:id", templateUrl: 'app/views/task/index.html' });
    }]);
})();