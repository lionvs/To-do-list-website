angular.module('app').factory('mvTask', function ($resource) {
    var TaskResource = $resource('/api/tasks/:Id', { Id: "@id" }, {
        update: { method: 'PUT', isArray: false }
    });

    return TaskResource;
});