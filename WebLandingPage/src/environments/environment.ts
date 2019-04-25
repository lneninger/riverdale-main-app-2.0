// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,

  firebase: {
    apiKey: "AIzaSyBoS6ADY2ivN5rmpkHyX5B2xo4TKiReBHs",
    authDomain: "hipalanet-test.firebaseapp.com",
    databaseURL: "https://hipalanet-test.firebaseio.com",
    projectId: "hipalanet-test",
    storageBucket: "hipalanet-test.appspot.com",
    messagingSenderId: "309802452085"
  }
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
