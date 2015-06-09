angular.module('app').factory('mvCategory', function ($resource) {
    var TaskResource = $resource('/api/categories/:Id', { Id: "@id" }, {
        update: { method: 'PUT', isArray: false }
    });

    return TaskResource;
});