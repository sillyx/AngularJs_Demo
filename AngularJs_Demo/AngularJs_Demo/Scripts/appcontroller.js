var appModule = angular.module("app", []);
var flag;
appModule.controller("appcontroller", function ($scope, $http, serviceFactory) {
    $scope.showEdit = true;
    $scope.Id = '';
    $scope.Name = '';
    $scope.Position = '';
    $scope.Address = '';
    $scope.Users = [];
    var slideService = serviceFactory.createService("Em");
    slideService.addFucntion("GetDataList","get");
    //加载
    $scope.Load = function () {
        $http.get("/api/Em/GetDataList").success(function (data, status) {
            $scope.Users = data;
        }).error(function (status) {
            alert(status);
        });
    };
    $scope.Delete = function (user) {
        $http.post("/api/Em/DelEntity", user).success(function (data, status) {
            alert(status);
            $scope.Load();
        }).error(function (status) {
            alert(status);
        });
    };
    $scope.Update = function (user) {
        $http.post('/api/Em/UpadateEntity', user).success(function (data, status) {
            alert(status);
            $scope.Load();
        }).error(function (data, status) {
            alert(status);
        });
    };
    $scope.toggle = function (id) {
        $scope.showEdit = !$scope.showEdit;
        flag = $scope.showEdit;
    }
    $scope.Load();
});
appModule.directive('edit', function ($document) {
    return {
        restrict: 'AE',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            element.bind('click', function () {
                var obj = $(element).parent().parent().find('input');
                if (!flag) {
                    obj.focus();
                    obj.removeAttr('readonly').removeAttr('style');
                    obj.css({ 'border': '1px', 'text-align': 'center' });
                }
                else {
                    obj.attr('readonly', 'readonly').removeAttr('style');
                    obj.css({ 'border': 'none', 'text-align': 'center' });
                }
            });
        }
    }
});