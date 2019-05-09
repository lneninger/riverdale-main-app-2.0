import * as functions from 'firebase-functions';
import * as admin from 'firebase-admin';
//import { request } from 'http';
import * as Cors from 'cors';
import { Observable } from 'rxjs';

import * as Stripe from 'stripe';

const cors = Cors({ origin: true });

const stripe = new Stripe(functions.config().stripe.token);
const currency = functions.config().stripe.currency || 'USD';



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



export const onDonation = functions.https.onRequest(async (req: functions.https.Request, res: functions.Response) => {

  return cors(req, res, async () => {

    const data = <IDonationModel>req.body.data;

    console.log(`Mapped to model`, data, `original body`, req.body);

    //const token = data.source;

    const intent: Stripe.paymentIntents.IPaymentIntentCreationOptions = {
      source: data.source, // paymentintent token
      amount: data.amount,
      currency: currency,
      payment_method_types: ['card'],
    };


    console.log('Sending donation:', intent);

    const response = await stripe.paymentIntents.create(intent);
    console.log('Donation Response:', response);

    await Observable.create(observer => {
      admin.database().ref('/donations').push(intent).then(() => {
          console.info(`donation saved successfully`);
        observer.next();
        observer.complete();
      },
        error => {
          console.error(error);
        });
    })

    res.status(200).jsonp({ data: response });


  });



});


export interface IDonationModel {
  source: string;
  amount: number;
  currency: string;
}
