var appModule = angular.module("app", []);
appModule.controller("appcontroller", function ($scope, $http) {
    $scope.Id = '';
    $scope.Name = '';
    $scope.Position = '';
    $scope.Address = '';
    $scope.Users = [];
    //加载
    $scope.Load = function () {
        $http.get("/api/Em/GetDataList").success(function (data, status) {
            $scope.Users = data;
        });
    };
    $scope.Del = function (userId) {
        alert(userId); 
    };
    $scope.Update = function (user,index) {
        alert($(this).text());
    };
    $scope.Load();
});