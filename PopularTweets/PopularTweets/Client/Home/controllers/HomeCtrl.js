angular.module('PopularTweetsApp.Home.Controllers', ['ngResource', 'ngSanitize']).
controller('homeController', function ($scope, homeApiService, $sce) {
    $scope.tweets = [];
    $scope.getTweets = function () {
        homeApiService.GetTwitterTimelineViaScreenName($scope.screenName, $scope.numberTweets).then(function (data) {
            $scope.tweets = data;
        });
        console.log($scope.tweets);
    };

    $scope.returnAsSafe = function (item) {
        return $sce.trustAsHtml(item);
    }
});