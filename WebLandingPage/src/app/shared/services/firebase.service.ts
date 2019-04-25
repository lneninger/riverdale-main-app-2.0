import { Injectable, Inject } from '@angular/core';
import { FirebaseApp, FirebaseDatabase } from '@angular/fire';
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFirestore } from '@angular/fire/firestore';

@Injectable({ providedIn: 'root' })
export class FirebaseService {

  constructor(
    private db: AngularFireDatabase, private dbStore: AngularFirestore
  ) { }
  
 // Add or Remove class

  // Landing page
  public subscribeToNewsletter(email: string) {
    return this.db.database.ref('newsletters_subscriptions').push({ email: email.toLowerCase() });

    //return this.dbStore..database.ref('newsletters_subscriptions').push({ email: email.toLowerCase() });
  }

}
