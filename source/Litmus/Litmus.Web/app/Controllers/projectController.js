(function () {
    'use strict';
    angular
        .module('app')
        .controller('projectCtrl',['$scope', 'Project', projectCtrl]);
    function projectCtrl($scope, project) {
        $scope.name = 'Gaurav';
        $scope.rows = project.find();
        $scope.add = function () {
            var tmp = project.create({ name: $scope.name });
        }
    }
})();