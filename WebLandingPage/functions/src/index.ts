import * as functions from 'firebase-functions';


const nodemailer = require('nodemailer');

// // Start writing Firebase Functions
// // https://firebase.google.com/docs/functions/typescript
//
// export const helloWorld = functions.https.onRequest((request, response) => {
//  response.send("Hello from Firebase!");
// });

export const watchNewNewslettersSubscriptions = functions.database.ref('/newsletters_subscriptions').onCreate((snapshot, context) => {

  console.log(`Executing watchNewNewslettersSubscriptions`);
  console.log(functions.config());
  const gmailEmail = encodeURIComponent(functions.config().gmail.email);
  const gmailPassword = encodeURIComponent(functions.config().gmail.password);
  const mailTransport = nodemailer.createTransport(`smtps://${gmailEmail}:${gmailPassword}@smtp.gmail.com`);


  const subscription = snapshot.val();

  const mailOptions = {
    to: subscription.email,
    subject: `Subscription received`,
    html: `We received your subscription of our newsletters`
  };

  return mailTransport.sendMail(mailOptions).then(() => console.log(`Mail sent to: ${subscription.email}`));

});

