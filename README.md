# SoccerBoard

Made with Net5/Blazor Server Side
<br>
<br>
<b>Functional Requirements</b>
<br>
The web app should include two web pages: One for showing a list of matches and one for showing details
of a single match. For both pages, clean and modern UI is preferred though not required.
<br>
<br>
<b>List of matches</b>
<br>
The list view (which can be implemented as a table or as a list of some sorts) should contain all the matches
available from the API. The following info should be available for each match: Date, Teams, Score.
The match in the list view should be clickable or each match should contain “Details”-button. When user
clicks the match/the details button, web app should move to the match details page.
Optionally, the user should be able to filter the match list using a single textbox. In the textbox user could
write the name of the team (or part of it), for example “IFK” and the list would filter out all the games
except those where “IFK Mariehamn” or “HIFK” has played.
<br>
<br>
<b>Details of a single match</b>
<br>
The details page of a single match should contain the following information about the selected match:
Date, Teams, Team Logos, Score, List of match events (EventMinute, EventTypeIcon and Description is
enough). 

