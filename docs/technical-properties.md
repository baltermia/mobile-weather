<h1 align="center">Technical Properties</h1>

## Functional Requirements (Use-Cases)
<img src="https://raw.githubusercontent.com/speyck/mobile-weather/main/docs/use-case.drawio.svg" width="650px" />

### Actors
There's only actor in the use case which is any user, really. No authentication or autorization is needed to use the app. The app can be used directly after it's installed (despite maybe having to allow gps access etc.).

## Non-Functional Requirements
- The app doesn't break when having e.g. internet connection/gps issues (could possibly give user feedback)  
- All text is clearly visible with no displaying issues  
- Does the app work on Android Versions above the one specified (Android 8.1 Oreo)

## Testing
The App will be tested both manually and also with Xamarin.UITest-Project Tests. There are a total of three Tests which are described below:

### 1. Get current Location
Using the "GPS"-Button on the bottom right of the application the current Location should be calibrated using the GPS-Sensor and the weather should be updated to that location.

#### Requirements:
- A valid internet connection
- GPS Sensor which is enabled and working correctly

#### Steps:
1. Click GPS Button
2. Location will be shown with weather, check if Location is correct (you should know where you're at obviously)
3. Check if weather is correct (using at least two different sources, e.g [weather.com](https://weather.com/) / [accuweather.com](https://www.accuweather.com/)).

As we're testing this in Zürich, the Location should be Zürich. The weather is of course always dependant.

### 2. Serach new Location
We're searching for a specific Location and the weather should be shown correctly.

#### Requirements:
- A valid internet connection

#### Steps:
1. Click the "SEARCH LOCATION" Button
2. Click the Serach Field at the top of the Page
3. Type "Chur"
4. Click the item with the value "Chur" from the list
5. Check if the Location is set correctly
6. Check if weather is correct (using at least two different sources, e.g [weather.com](https://weather.com/) / [accuweather.com](https://www.accuweather.com/)).

### 3. Check saved Location
The app should save the last location automatically. So this test is fairly easy

#### Requirements:
- A valid internet connection

#### Steps:
1. Select any Location (current or searched)
2. You should memorize or write the location somewhere
3. Close the app (fully)
4. Open the app again
5. Check if the Location is the same as before (or if set at all)

## Packages
<img src="https://raw.githubusercontent.com/speyck/mobile-weather/main/docs/packages.drawio.svg" width="650px" />

## Deployment Diagram
<img src="https://raw.githubusercontent.com/speyck/mobile-weather/main/docs/deployment.drawio.svg" width="650px" />
