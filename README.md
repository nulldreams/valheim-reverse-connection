# Steps

- run `yarn` or `npm install` inside node folder
- run `yarn start` inside node folder
- serve the node folder using `localserver` npm module
- replace localhost:900 inside `JotunnModStub.cs` by the localserver url
- build the mod project
- open a terminal and run `nc -lnvp {reverse connection port}`
- run the game
