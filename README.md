# Food Truck App 🍔🍟🍕🌭🚚

## Excercise description 🤓

There is a list of food trucks in an API that needs to be viewed in Google Maps.

To load this list, you must create your own API (in dotnet) which consults the information of the external API ([click to view it](https://data.sfgov.org/Economy-and-Community/Mobile-Food-Facility-Permit/rqzj-sfat)) and stores it in its own database (only necessary fields).

After this, the information must be made available to be consulted at any time from a web application (html).

## How did I solve the exercise? 🤔

Well, I separated the project into two subprojects:

- API (Back-End: made with .Net Core 5, EF).
- Web App (Front-End: made with ReactJS - Redux, and Node Express).

## API 💻

This project was developed with **DDD** (Domain Driven Design), using **.Net Core 5 C#** and **Sqlite** database.

### Architecture 👨🏻‍💼

The project consists of 11 subprojects, which are:

- **Abstractions**:
This transversal project contains all the interfaces defined to manage the dependency injection in all projects.
- **API**:
This project receives all web requests. The endpoints are documented with SWAGGER.

  The **ConfigureServices** method in **Startup.cs**, uses the **Resolver** project, injecting all the needed dependencies map to serviceCollection object, executing **services.AddFoodTruck();**
  
  The **FoodTruckController** only exposes one endpoint: GET `/foodtruck`
  
  In the project folder, the **data.db** file will be displayed, which corresponds to the SQLite database where the information obtained in the external API is stored.
- **Application**:
This project contains all the logical operations in the application, from the information query and data verification in the database to the external API query and subsequent storage in the database.

  This project only calls services layer (which is **Data** project responsibility: http calls and db queries) and maybe the transformations layer (which are **Domain** project responsibility: format data, etc).
  
- **Data**:
This project is responsible for making HTTP calls and database queries.

- **Domain**:
This project is responsible for making data transformations. For example, transforms the received data in an HTTP call to our own entity to be saved in the database.

- **Exceptions**:
This transversal project contains all the exceptions definitions of the app.

- **Extensions**:
This transversal project contains all the extensions, like the `IsInValid` method to validate **Enums** or `CleanSpaces` method to remove spaces into a string.

- **Infraestructure**:
This project implements the databases configurations. In this case, there are two options: SQLite or InMemory (for tests).

- **Models**:
This project contains:
  - Enums
  - Data transfer objects
  - Entities

- **Resolver**:
This project injects all the needed dependencies map to serviceCollection object in the **API** project, executing **AddFoodTruck** method.

- **Tests**:
Guess what it is... 😅

### To run locally, execute 📟:

```console
-> FoodTruckApp dotnet run --project API
```

If everything goes well, it should show:

```console
Building...
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: [https://localhost:5001](https://localhost:5001/swagger/index.html)
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: [http://localhost:5000](http://localhost:5000/swagger/index.html)
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/abcd/my-folder/FoodTruckApp/API
```

When the API is running, you can view swagger documentation:
- [https://localhost:5001](https://localhost:5001/swagger/index.html)
- [http://localhost:5000](http://localhost:5000/swagger/index.html)

## Web App 🌎

This project was developed with **ReactJS** and **Redux**, with a little **Node Express** server.

That server is used in order to handle the API calls to the backend (dotnet api) - something like a middle-end that manages external api calls -.

### Architecture 👨🏻‍💼

The project consists of 2 "subprojects", which are:

- **api**:
This layer is responsible to make all the API calls to the dotnet API. Was created to not expose the dotnet API URI in the browser.

  This project runs on Node Express Server, at `3500` port.
  
  In the **package.json** file of the **app** project, the proxy to this layer was configured to have execution transparent.

- **app**:
This layer is responsible to show the web app made with ReactJS Redux.

  This project makes HTTP calls to the api project to obtain all the data, without knows the dotnet API URI.

### To run locally, execute 📟:

```console
-> FoodTruckApp cd web
-> web npm i
-> web npm run dev
```

If everything goes well, it should show:

```console
> food-truck-fe@1.0.0 dev
> concurrently --kill-others-on-fail "npm run server" "npm run client"

[0] > food-truck-fe@1.0.0 server
[0] > nodemon ./api/server.js
[0] 
[1] 
[1] > food-truck-fe@1.0.0 client
[1] > cd app && npm start
[1] 
[0] [nodemon] 2.0.12
[0] [nodemon] to restart at any time, enter `rs`
[0] [nodemon] watching path(s): *.*
[0] [nodemon] watching extensions: js,mjs,json
[0] [nodemon] starting `node ./api/server.js`
[0] Listening on port 3500
[1] 
[1] > web@0.1.0 start
[1] > react-scripts start
[1] 
[1] ℹ ｢wds｣: Project is running at http://192.168.1.102/
[1] ℹ ｢wds｣: webpack output is served from 
[1] ℹ ｢wds｣: Content not from webpack is served from /Users/carlodiaz/RiderProjects/FoodTruckApp/web/app/public
[1] ℹ ｢wds｣: 404s will fallback to /
[1] Starting the development server...
[1] 
[1] Compiled successfully!
[1] 
[1] You can now view web in the browser.
[1] 
[1]   Local:            http://localhost:3000
[1]   On Your Network:  http://192.168.1.102:3000
[1] 
[1] Note that the development build is not optimized.
[1] To create a production build, use npm run build.
```

When the Web App is running, you can navigate to [http://localhost:3000](http://localhost:3000/).

## Consideration

- *The google map may be displayed with "For development purposes only" signs.*
- The <img src="https://image.flaticon.com/icons/png/512/1276/1276208.png" height="20" /> icon indicate "Food Truck" facility type.
- The <img src="https://image.flaticon.com/icons/png/512/5043/5043154.png" height="20" /> icon indicate "Push Cart" facility type.
- The <img src="https://image.flaticon.com/icons/png/512/2634/2634120.png" height="20" /> icon is displayed when the installation type has not been provided by the external API.

## Screenshots

- Web App
![image](https://user-images.githubusercontent.com/12788783/129991671-677afb2a-981a-432b-bfdd-128c8a72fe82.png)

- API (Swagger)
![image](https://user-images.githubusercontent.com/12788783/129991880-d1f3854b-bf8b-46e4-ab06-c1312c0b936d.png)

- IDE
![image](https://user-images.githubusercontent.com/12788783/129991858-a83c9fbd-b3ca-4287-8af3-6a085d858491.png)
