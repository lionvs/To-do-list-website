angular.module('app').controller('mvTaskListCtrl', function ($scope,$http, mvTask, mvSubTask) {
    mvTask.query().$promise.then(function(tasks) {
        $scope.tasksUnfinished = tasks.filter(function(t) {
            return !t.IsFinished;
        });
        $scope.tasksFinished = tasks.filter(function(t) {
            return t.IsFinished;
        });
    });

    $scope.subtaskChanged = function(subtask) {
        subtask.IsFinished = !subtask.IsFinished;
        $http.put("/api/subtask/" + subtask.Id, subtask);
    }


});