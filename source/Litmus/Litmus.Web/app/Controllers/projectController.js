(function () {
    'use strict';
    angular
        .module('app')
        .controller('projectCtrl', ['$scope', 'Project', projectCtrl]);
    function projectCtrl($scope, project) {
        $scope.name = 'First Project';
        $scope.row = project.find({ id: $scope.id });
        $scope.rows = project.findAll();
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