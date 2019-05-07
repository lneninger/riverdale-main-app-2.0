import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FirebaseService } from 'src/app/shared/services/firebase.service';
import { Observable, of } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent implements OnInit {

  contactForm: FormGroup;
  status: StatusType;

  constructor(private fb: FormBuilder, private firebaseService: FirebaseService) { }

  // Form Validator
  ngOnInit() {
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', Validators.email],
      message: ['', Validators.required]
    })
  }


  onSubmit($event: Event) {
    $event.preventDefault();
    debugger;
    if (this.contactForm.invalid) return false


    this.setSendingStatus();

    Observable.create(observer => {
      this.firebaseService.sendContactMessage(this.contactForm.value)
        .then(res => {
          debugger;
          this.contactForm.reset({});
          observer.next(res);
        });
    })
      .pipe(catchError(_ => {
        this.setErrorStatus();
        return of(_);
      }))
      .subscribe(_ => {
        this.setSuccessStatus();
      });


  }


  setSendingStatus() {
    this.status = 'sending';
  }

  setSuccessStatus() {
    this.status = 'success';
    setTimeout(() => {
      this.status = null;
    }, 3000)
  }

  setErrorStatus() {
    this.status = 'error';
  }
}


export type StatusType = 'sending' | 'success' | 'error';
