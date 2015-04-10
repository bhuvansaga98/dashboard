(function () {
    'use strict';
    var projectService = angular.module('projectService', ['ngResource']);

    projectService.factory('Project', ['$http','$q',
    function ($http,$q) {
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
                      var temp = {};
                      var defer = $q.defer();
                      $http.get('/api/project/all').success(function (data) {
                          defer.resolve(data);
                      });
                      return defer.promise;
              },
              remove: function (id) {
                  return $http.delete('api/project/' + id);
              }
          }
      }]);


})();