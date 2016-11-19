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

      this.getEmbed = function () {
          return $http({
              method: 'GET',
              url: 'https://api.twitter.com/1/statuses/oembed.json?id=287348974577385474&align=center&callback=?',
              dataType: 'jsonp'
          }).success(function (data) {
              console.log(data);
              return data;
          }).error(function () {
              return false;
          });
      }
  });