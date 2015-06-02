angular.module('app').factory('mvSubTask', function ($resource) {
    var TaskResource = $resource('/api/subtask/:_id', { _id: "@id" }, {
        update: { method: 'PUT', isArray: false }
    });

    return TaskResource;
});