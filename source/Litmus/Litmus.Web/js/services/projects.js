var apiService = angular.module('apiService', ['ngResource']);
apiService.factory('Project', ['$http', '$q',
function ($http, $q) {
    return {
        create: function (project) {
            var defer = $q.defer();
            $http.post('/api/project', project).success(function (data) {
                defer.resolve(data);
            });
            return defer.promise;
        },
        update: function (project) {
            return $http({ method: "put", url: "/api/project", data: project });
        },
        find: function (id) {
            return $http.get('/api/project/' + id);
        },
        findAll: function () {
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