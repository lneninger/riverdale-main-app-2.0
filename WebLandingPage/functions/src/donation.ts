import * as functions from 'firebase-functions';
import * as express  from 'express';
import * as Cors from 'cors';
import * as Stripe from 'stripe';

export const app = express();
app.use(Cors({ origin: true }));
app.use(express.json());

app.post('', async (req, res) => {
  const data = <IDonationModel>req.body;

  console.log(`Mapped to model`, data, `original body`, req.body);

  const token = data.source;
  const currency = functions.config().stripe.currency || 'USD';
  const stripe = new Stripe(functions.config().stripe.token);


  const intent: Stripe.paymentIntents.IPaymentIntentCreationOptions = {
    amount: data.amount,
    currency: currency,
    payment_method_types: ['card']
  };


  console.log('Sending donation:', intent);

  const response = await stripe.paymentIntents.create(intent);

  console.log('Donation Response:', response);

  res.status(200).jsonp({ data: response });
});

export interface IDonationModel {
  source: string;
  amount: number;
  currency: string;
}
