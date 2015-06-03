angular.module('app').controller('mvTaskListCtrl', function ($scope,$http, mvTask, mvSubTask) {
    mvTask.query().$promise.then(function(tasks) {
        $scope.tasksUnfinished = tasks.filter(function(t) {
            return !t.IsFinished;
        });
        $scope.tasksFinished = tasks.filter(function(t) {
            return t.IsFinished;
        });
    });

    $http.get("/api/categories/").
        success(function(data, status, headers, config) {
            $scope.categories = data;
        });

    checkTaskFinish = function(task) {
        if ((task.subTasks.filter(function (subTask) {
            return !subTask.IsFinished;
        })).length < 1) {
            task.IsFinished = !task.IsFinished;
            $scope.tasksUnfinished.splice($scope.tasksUnfinished.indexOf(task), 1);
            $scope.tasksFinished.push(task);
            $http.put("/api/tasks/" + task.Id, task);
        }
    }

    $scope.subtaskChanged = function(subtask, task) {
        subtask.IsFinished = !subtask.IsFinished;
        $http.put("/api/subtask/" + subtask.Id, subtask);

        //if all subtasks are finished move task to finished
        checkTaskFinish(task);
    }
    $scope.removeSubtaskChanged = function (subtask, task) {
        task.subTasks.splice(task.subTasks.indexOf(subtask), 1);
        $http.delete("/api/subtask/" + subtask.Id);
        checkTaskFinish(task);
    }
    $scope.removeAllFinishedTasks = function() {
        $scope.tasksFinished.forEach(function(task) {
            $http.delete("/api/tasks/" + task.Id);
        });
        $scope.tasksFinished = [];
    }
    $scope.addnewSubtask = function(task, subTaskName) {
        var subtask = {TaskId : task.Id, SubName:subTaskName, IsFinished:false};
        task.subTasks.push(subtask);
        $http.post("/api/subtask/", subtask);
    }

    $scope.addnewTask = function (taskName, newTaskCategory) {
        var task = { TaskName: taskName, subTasks: [], CategoryId: newTaskCategory.Id };
        $scope.tasksUnfinished.push(task);
        $http.post("/api/tasks/", task);
    }

    $scope.taskChanged = function (task) {
        if ($scope.tasksFinished.indexOf(task) != -1) {
            $scope.tasksFinished.splice($scope.tasksFinished.indexOf(task), 1);
            $scope.tasksUnfinished.push(task);
        } else {
            $scope.tasksUnfinished.splice($scope.tasksUnfinished.indexOf(task),1);
            $scope.tasksFinished.push(task);
        }
        task.IsFinished = !task.IsFinished;

        $http.put("/api/tasks/" + task.Id, task);
    }

});