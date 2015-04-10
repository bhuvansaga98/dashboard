(function () {
    'use strict';
    angular
        .module('app')
        .controller('projectCtrl', ['$scope', 'Project', projectCtrl]);
    function projectCtrl($scope, project) {
        $scope.detail = project.find({ id: $scope.id });
        project.findAll().then(function (d) { $scope.rows = d; });
        $scope.add = function () {
            return project.create({ name: $scope.name });
        }
        $scope.edit = function () {
            return project.update({ name: $scope.name });
        }
        $scope.remove = function () {
            return project.remove({ id: $scope.id });
        }
    }
})();