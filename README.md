Assignment 3: Trading Cards
Overview
Trading cards were a common type of collectible, particularly for sports fans. Select a sport of interest to you and develop an application for viewing custom trading cards for some of the players of that sport.
Directions
Start by selecting which sport you want to cover and finding some data. You will need to create a custom data set for your application to display. Include data for at least 10 players, belonging to at least 3 different teams. For each player your data set should include their name, team, photo and at least 4 other stats about the player that are relevant to your chosen sport. Store your data in a data structure that can be queried using LINQ (for ease of development, the data may be hard-coded into your application).
Your application should include 2 key components: a list of cards to view, and a view of the currently selected card. Use data binding to display a list of cards the user can view. Cards should be listed by the athlete’s name (use a query on the actual data set to allow data to be added or removed). The card view should bind to the data source supplying the data you’ve gathered. Use data binding to modify things such as the text, picture, and colors used to portray the card. The card view must display the athlete’s name, team, picture and stats, and should also include a couple other bindings based on the data related to card’s visual design (for example, the card’s border color could change based on the player’s team, or the player’s stats could be listed in red or green to indicate if their values are high or low).

References:
Players stats:
LeBron James. (2024, November 12). In Wikipedia. https://en.wikipedia.org/wiki/LeBron_James
Kevin Durant. (2024, November 13). In Wikipedia. https://en.wikipedia.org/wiki/Kevin_Durant
Giannis Antetokounmpo. (2024, November 8). In Wikipedia. https://en.wikipedia.org/wiki/Giannis_Antetokounmpo
Stephen Curry. (2024, November 14). In Wikipedia. https://en.wikipedia.org/wiki/Stephen_Curry
Joel Embiid. (2024, November 15). In Wikipedia. https://en.wikipedia.org/wiki/Joel_Embiid
Luka Dončić. (2024, November 16). In Wikipedia. https://en.wikipedia.org/wiki/Luka_Don%C4%8Di%C4%87
Nikola Jokić. (2024, November 17). In Wikipedia. https://en.wikipedia.org/wiki/Nikola_Joki%C4%87
Kawhi Leonard. (2024, November 18). In Wikipedia. https://en.wikipedia.org/wiki/Kawhi_Leonard
Jimmy Butler. (2024, November 19). In Wikipedia. https://en.wikipedia.org/wiki/Jimmy_Butler
Anthony Davis. (2024, November 20). In Wikipedia. https://en.wikipedia.org/wiki/Anthony_Davis
Player Photos: https://www.gettyimages.ca/
Logos:
CleanPNG. (n.d.). CleanPNG - HD PNG images and illustrations. Free unlimited download. Retrieved November 13, 2024, from https://www.cleanpng.com/
Dictionary - https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-9.0
I used ChatGPT to assist me with writing the function below. I gave it the following prompt:
Give me the stats for NBA Players based on wikipedia
Put in comments
Give me the hex colors for the NBA teams
Help me improve my code
Check my code syntax
How do you paint the stats and logo in front of the photo
