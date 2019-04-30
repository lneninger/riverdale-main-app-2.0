import * as functions from 'firebase-functions';


const nodemailer = require('nodemailer');

// // Start writing Firebase Functions
// // https://firebase.google.com/docs/functions/typescript
//
// export const helloWorld = functions.https.onRequest((request, response) => {
//  response.send("Hello from Firebase!");
// });

export const onNewslettersSubscriptions = functions.database.ref('/newsletters_subscriptions/{subscriptionId}').onCreate((snapshot, context) => {

  console.log(`Executing onNewslettersSubscriptions cloud function`);
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


export const onContactus = functions.database.ref('/contactus/{contactId}').onCreate((snapshot, context) => {

  console.log(`Executing onNContactus cloud function`);
  console.log(functions.config());
  const gmailEmail = encodeURIComponent(functions.config().gmail.email);
  const gmailPassword = encodeURIComponent(functions.config().gmail.password);
  const mailTransport = nodemailer.createTransport(`smtps://${gmailEmail}:${gmailPassword}@smtp.gmail.com`);


  const data = snapshot.val();

  const toContactEmailOptions = {
    to: data.email,
    subject: `Your message was received`,
    html: `We received your message. After review it, we'll contact you for further information. Thanks`
  };

  mailTransport.sendMail(toContactEmailOptions).then(() => console.log(`Mail sent to: ${data.email}`));


  const toUsEmailOptions = {
    to: gmailEmail,
    subject: `Contact us received`,
    html: `<ol>
            <dt>Email: </dt>
            <dd>${data.email}</dd>
            <dt>Name: </dt>
            <dd>${data.name}</dd>
            <dt>Phone: </dt>
            <dd>${data.phone}</dd>
            <dt>Message: </dt><hr/>
            <dd><pre>${data.phone}</pre></dd>
          </dl>`
  };

  mailTransport.sendMail(toUsEmailOptions).then(() => console.log(`Mail sent to: ${data.email}`));

  return;

});

