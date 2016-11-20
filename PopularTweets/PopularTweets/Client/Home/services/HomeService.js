angular.module('PopularTweetsApp.Home.Services', []).
  service('homeApiService', function ($http) {

      this.GetTwitterTimelineViaScreenName = function (screenName, numberTweets) {
          return $http({
              method: 'GET',
              url: 'api/Tweets/GetTweets',
              contentType: "application/json",
              params: { screenName: screenName, numberTweets : numberTweets }
          }).then(function (response) {
              console.log(response.data);
              return response.data;
          });
      }
  });