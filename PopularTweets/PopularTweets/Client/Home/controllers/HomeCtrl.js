angular.module('PopularTweetsApp.Home.Controllers', ['ngResource']).
controller('homeController', function ($scope, homeApiService, $sce) {
    $scope.getEmbedHtml = $sce.trustAsHtml("\u003Cblockquote class=\"twitter-tweet\"\u003E\u003Cp lang=\"en\" dir=\"ltr\"\u003EHappy 50th anniversary to the Wilderness Act! Here's a great wilderness photo from \u003Ca href=\"https:\/\/twitter.com\/YosemiteNPS\"\u003E@YosemiteNPS\u003C\/a\u003E. \u003Ca href=\"https:\/\/twitter.com\/hashtag\/Wilderness50?src=hash\"\u003E#Wilderness50\u003C\/a\u003E \u003Ca href=\"http:\/\/t.co\/HMhbyTg18X\"\u003Epic.twitter.com\/HMhbyTg18X\u003C\/a\u003E\u003C\/p\u003E— US Dept of Interior (@Interior) \u003Ca href=\"https:\/\/twitter.com\/Interior\/status\/507185938620219395\"\u003ESeptember 3, 2014\u003C\/a\u003E\u003C\/blockquote\u003E\n\u003Cscript async src=\"\/\/platform.twitter.com\/widgets.js\" charset=\"utf-8\"\u003E\u003C\/script\u003E");
    
    $scope.getTweets = function () {
        homeApiService.GetTwitterTimelineViaScreenName($scope.screenName, $scope.numberTweets);
    };
    console.log('success');
});