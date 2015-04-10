(function () {
    'use strict';
    angular
    .module('app')
    .controller('projectCtrl', ['$scope','$state', 'Project', projectCtrl])
    .controller('homeCtrl', ['$scope', homeCtrl]);

    function homeCtrl($scope) {
        $scope.name = "hello";
    }

    function projectCtrl($scope,$state, project) {
        //$state.params.id
        $scope.detail = project.find({ id: $scope.id });

        function getProjects() { project.findAll().then(function (d) { $scope.rows = d; }); }
        getProjects();

        $scope.add = function () {
            project.create({ name: $scope.name }).then(function (d) { getProjects(); $scope.name = ""; window.location.href="/app/project.html" });
        }

        $scope.edit = function () {
            return project.update({ name: $scope.name });
        }

        $scope.remove = function () {
            return project.remove({ id: $scope.id });
        }
    }
})();