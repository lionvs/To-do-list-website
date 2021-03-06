﻿angular.module('app').controller('mvCategoriesCtrl', function ($scope, $http, mvCategory) {
    mvCategory.query().$promise.then(function (categories) {
        $scope.allCategories = categories;
        $scope.allCategories.forEach(function(category) {
            category.show = false;
        });
    });
    $scope.addnewCategory = function (newCategoryName) {
        var category = { Name: newCategoryName};
        $scope.allCategories.push(category);
        $http.post("/api/categories/", category);
    };
    $scope.removeCategory = function(category) {
        $scope.allCategories.splice($scope.allCategories.indexOf(category), 1);
        $http.delete("/api/categories/" + category.Id);
    };
    
    $scope.editCategory = function (category) {
        if (category.show) {
            $http.put("/api/categories/" + category.Id, category);
            category.show = !category.show;
        } else {
            category.show = !category.show;
        }

    };
});