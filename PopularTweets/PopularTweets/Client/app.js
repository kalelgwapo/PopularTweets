angular.module('PopularTweetsApp', [
    'ngRoute',
  'PopularTweetsApp.Home'
]).
config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
      when("/home", {
          templateUrl: "Client/Home/templates/Home.html"
      }).
      otherwise({ redirectTo: '/home' });
}]);