angular.module('PopularTweetsApp.Home.Services', []).
  service('homeApiService', function ($http) {

      this.GetTwitterTimelineViaScreenName = function () {
          return $http({
              method: 'GET',
              url: 'api/Tweets',
              contentType: "application/json"
          }).success(function (data) {
              return true;
          }).error(function () {
              return false;
          });
      }
  });