import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FirebaseService } from 'src/app/shared/services/firebase.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent implements OnInit {

  contactForm: FormGroup;
  
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

    this.firebaseService.sendContactMessage(this.contactForm.value)
      .then(res => {
        debugger;
        this.contactForm.reset({});
      });
  }

}
