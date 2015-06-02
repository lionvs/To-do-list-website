angular.module('app').controller('mvTaskListCtrl', function ($scope, mvTask) {
    $scope.tasks = mvTask.query();

});