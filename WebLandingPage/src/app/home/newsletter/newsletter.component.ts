import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FirebaseService } from 'src/app/shared/services/firebase.service';

@Component({
  selector: 'app-newsletter',
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.scss']
})
export class NewsletterComponent implements OnInit {

  subscribeForm: FormGroup;
  
  constructor(private sf: FormBuilder, private firebaseService: FirebaseService) {
  }

  // Email Validator
  ngOnInit() {
    this.subscribeForm = this.sf.group({
      email: ['', [Validators.required, Validators.email]],
    })
  }

  onSubmit($event: Event) {
    $event.preventDefault();
    debugger;
    if (this.subscribeForm.invalid) return false

    this.firebaseService.subscribeToNewsletter(this.subscribeForm.value.email)
      .then(res => {
        debugger;
        this.subscribeForm.reset({});
      });

   
  }

}
