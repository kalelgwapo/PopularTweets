angular.module('PopularTweetsApp.Home.Controllers', ['ngResource', 'ngSanitize']).
controller('homeController', function ($scope, homeApiService, $sce) {
    $scope.tweets = [];
    $scope.loading = false;
    $scope.getTweets = function () {
        $scope.loading = true;
        homeApiService.GetTwitterTimelineViaScreenName($scope.screenName, $scope.numberTweets).then(function (data) {
            $scope.tweets = data;
            $scope.loading = false;
        });
    };

    $scope.returnAsSafe = function (item) {
        return $sce.trustAsHtml(item);
    }
});