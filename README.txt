# PopularTweets
A simple web app that sorts a user's timeline tweets via popularity


Assumptions:
Only need 2 API calls to twitter for the data but looks like I needed 4.
- OAuth
- Tweet Timeline
- Get Favorite and Retweet Count (Favorite count of a tweet can't be found in the /Get/User_Timeline call)
- Get OEmbed

Done Differently:
I couldve assembled my own embed html using directives when the data from the web api returns but I'm not sure which is faster between assembling my own embed html via directives OR getting the OEmbed from twitter and just inject the result. I prompted for the latter.

Speed up Implementation:
As discussed in the Done Differently section. I'm curious which wouldve been faster between using directives for the embed or just inject the html from twitter.

Comments:
Most of the time I spent developing the web app were in using twitter's API. It was my first time using it and had to search within the documentation for the relevant information needed.

Injecting the embed HTML werent working immediately in the angular side since angular doesnt really trust binding html into the view side. Had to use $sce to bypass it.

There was an error when calling twitter's api but I couldnt replicate it.

Case Studies:
I've worked at multiple projects but I couldve provide URLs since those are confidential. These can be found in my CV.

Flight Desk Information System
It's a windows app made for windows tablet. The app is being used by pilots providing them with information needed (flight plan, crew roster, weather patterns, manuals etc.). This one of my proudest projects since this is the first time I've led a team. It was composed of 3 juniors, a tester and a project manager. I was responsible in distributing tasks, communicating with the client and coordinating with the project manager. This is similar with the exam given since we also used web api that communicated with the airline's API.

B2B Redesign
An ecommerce website that is already in production. I'm responsible for it's redesign into version 3, using angularJS. The website is expected to be responsive and is using ajax calls to the web api controllers.
