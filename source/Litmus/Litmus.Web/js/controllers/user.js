'use strict';

/* Controllers */

// Form controller
app.controller('UserCtrl', ['$scope', '$http', '$q', function ($scope, $http, $q) {

    var user = {
        current: function () {
            return $http.get('/home/UserProfile');
        },
    }

    user.current().then(function (d) {
        $scope.name = d.data.DisplayName;
    });
}]);
