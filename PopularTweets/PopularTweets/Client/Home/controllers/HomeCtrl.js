angular.module('PopularTweetsApp.Home.Controllers', []).
controller('homeController', function ($scope, homeApiService) {
    homeApiService.GetTwitterTimelineViaScreenName();
    console.log('success');
});