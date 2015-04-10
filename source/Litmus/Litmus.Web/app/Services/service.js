(function () {
    'use strict';
    var projectService = angular.module('projectService', ['ngResource']);

    projectService.factory('Project', ['$resource',
      function ($resource) {
          return {
              create: function (project) {
                  return $resource('/api/project', {}, {
                      query: { method: 'POST', params: project }
                  });
              },
              find: function () {
                  return $resource('/api/project/1', {}, {
                      query: { method: 'GET', isArray: true }
                  });
              },
          }
      }]);


})();