(function () {
    'use strict';
    var projectService = angular.module('projectService', ['ngResource']);

    projectService.factory('Project', ['$http',
      function ($http) {
          return {
              create: function (project) {
                  return $http({ method: "post", url: "/api/project", data: project });
              },
              update: function (project) {
                  return $http({ method: "put", url: "/api/project", data: project });
              },
              find: function (id) {
                  return $http.get('/api/project/' + id);
              },
              findAll: function () {
                  return $http.get('/api/project/all');
              },
              remove: function (id) {
                  return $http.delete('api/project/' + id);
              }
          }
      }]);


})();