import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FirebaseService } from 'src/app/shared/services/firebase.service';
import { StripeService, Elements, Element as StripeElement, ElementsOptions } from "ngx-stripe";
import { AngularFireFunctions } from '@angular/fire/functions';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

//const stripe = require('stripe')('pk_test_iOFzxDfz6HHS7YLCWKlHrzIK005l1FQE5O');
//const stripe = Stripe('pk_test_iOFzxDfz6HHS7YLCWKlHrzIK005l1FQE5O');


@Component({
  selector: 'donation',
  templateUrl: './donation.component.html',
  styleUrls: ['./donation.component.scss']
})
export class DonationComponent implements OnInit, AfterViewInit {

  elements: Elements;
  card: StripeElement;
  donation$: Observable<any>;
  status: DonationProcessStatusType = null;

  // optional parameters
  elementsOptions: ElementsOptions = {
    locale: 'es'
  };

  stripeTest: FormGroup;

  constructor(
    private fb: FormBuilder
    , private firebaseService: FirebaseService
    , private stripeService: StripeService
    , private fns: AngularFireFunctions) {


  }

  // Form Validator
  ngOnInit() {
    this.stripeTest = this.fb.group({
      name: ['', [Validators.required]]
    });
    this.stripeService.elements(this.elementsOptions)
      .subscribe(elements => {
        this.elements = elements;
        // Only mount the element the first time
        if (!this.card) {
          this.card = this.elements.create('card', {
            style: {
              base: {
                iconColor: '#666EE8',
                color: '#31325F',
                lineHeight: '40px',
                fontWeight: 300,
                fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
                fontSize: '18px',
                '::placeholder': {
                  color: '#CFD7E0'
                }
              }
            }
          });
          this.card.mount('#card-element');
        }
      });
  }

  ngAfterViewInit() {
    //var elements = stripe.elements();
    //var elements = stripe.elements();
  }


  buy(amount: number) {

    this.status = 'sending';

    let centAmount = amount * 100;

    const name = this.stripeTest.get('name').value;
    this.stripeService
      .createSource(this.card, {
        type: 'card', amount: centAmount, currency: 'usd', owner: {
          name: 'Jenny Rosen',
        } })
      .subscribe(async result => {
        if (result.error) {
          console.log(result.error);
          this.status = 'error';
          alert(JSON.stringify(result.error));

        }
        else {
          const source = result.source;
          if (source.id) {
            // Use the token to create a charge or a customer
            // https://stripe.com/docs/charges
            console.log(source);

            await this.sendOrder(source, amount);
            this.status = 'success';

          } else if (result.error) {
            // Error creating the token
            console.log(result.error.message);
          }
        }
      });
  }

  async sendOrder(token: any, amount: number) {
    const order = {
      source: token.id,
      amount: amount * 100,
      currency: 'usd'
    }

    const callable = this.fns.httpsCallable('onDonation');
    const result = await callable(order).pipe(catchError(error => {
      console.error(`Donation error: `, error);
      this.status = 'error';
      return of(error);
    }));

    //this.donation$.subscribe(res => {
    //  console.log(`Donation response: `, res);
    //}, error => {

    //  });
  }

}


export type DonationProcessStatusType = 'sending' | 'success' | 'error';
