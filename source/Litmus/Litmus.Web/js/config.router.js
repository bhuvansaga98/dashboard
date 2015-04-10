'use strict';

/**
 * Config for the router
 */
angular.module('app')
  .run(['$rootScope', '$state', '$stateParams', function ($rootScope, $state, $stateParams) {
      $rootScope.$state = $state;
      $rootScope.$stateParams = $stateParams;
  }])
.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/app/dashboard');
    $stateProvider
        .state('app', {
            'abstract': true,
            url: '/app',
            templateUrl: 'tpl/app.html'
        })
        .state('app.dashboard', {
            url: '/dashboard',
            templateUrl: 'tpl/app_dashboard_v2.html',
            resolve: {
                deps: [
                    '$ocLazyLoad',
                    function($ocLazyLoad) {
                        return $ocLazyLoad.load(['js/controllers/chart.js']);
                    }
                ]
            }
        })
        .state('app.project', { url: '/projects', templateUrl: 'tpl/projects/index.html' })
        .state('app.project.create', { url: '/create', templateUrl: 'tpl/projects/create.html' })
;
}]);
