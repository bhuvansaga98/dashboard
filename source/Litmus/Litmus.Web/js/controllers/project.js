'use strict';

/* Controllers */

// Form controller
app.controller('ProjectCtrl', ['$scope', '$http', '$q', function ($scope, $http, $q) {

    var project = {
        create: function (item) {
            var defer = $q.defer();
            $http.post('/api/project', item).success(function (data) {
                defer.resolve(data);
            });
            window.location.href = "#/app/projects";
            return defer.promise;
        },
        update: function (item) {
            return $http({ method: "put", url: "/api/project", data: item });
        },
        find: function (id) {
            return $http.get('/api/project/' + id);
        },       
        findAll: function () {
            var defer = $q.defer();
            $http.get('/api/project/all?$orderby=Id desc').success(function (data) {
                defer.resolve(data);
            });
            return defer.promise;
        },
        remove: function (id) {
            return $http.delete('api/project/' + id);
        }
    }

    //$state.params.id
    $scope.detail = project.find({ id: $scope.id });

    function loadProjects() { project.findAll().then(function (d) { $scope.rows = d; }); }

    $scope.add = function () {
        project.create({ name: $scope.name }).then(function (d) {
            $scope.name = '';
            loadProjects();
        });
    }

    $scope.edit = function () {
        return project.update({ name: $scope.name });
    }

    $scope.remove = function () {
        return project.remove({ id: $scope.id });
    }

    loadProjects();

}]);
