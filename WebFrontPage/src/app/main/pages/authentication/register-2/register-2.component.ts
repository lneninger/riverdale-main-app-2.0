import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';
/*************************Custom***********************************/
import { AuthenticationService, Register } from '../../../apps/@hipalanetCommons/authentication/authentication.core.module';
import { CustomValidators } from 'ngx-custom-validators';
import { Router } from '@angular/router';
//import { AngularFireAuth } from '@angular/fire/auth';
//import { AngularFireDatabase } from '@angular/fire/database';

@Component({
    selector: 'register-2',
    templateUrl: './register-2.component.html',
    styleUrls: ['./register-2.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class Register2Component implements OnInit, OnDestroy {
    registerForm: FormGroup;

    // Private
    private _unsubscribeAll: Subject<any>;

    constructor(
        private _fuseConfigService: FuseConfigService
        , private _formBuilder: FormBuilder
        // Custom
        //, private auth: AngularFireAuth
        , private service: AuthenticationService
        //, private database: AngularFireDatabase
        , private router: Router
    ) {
        // Configure the layout
        this._fuseConfigService.config = {
            layout: {
                navbar: {
                    hidden: true
                },
                toolbar: {
                    hidden: true
                },
                footer: {
                    hidden: true
                },
                sidepanel: {
                    hidden: true
                }
            }
        };

        // Set the private defaults
        this._unsubscribeAll = new Subject();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        this.registerForm = this._formBuilder.group({
            userName: ['', Validators.required],
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            password: ['', Validators.required],
            passwordConfirm: ['', [Validators.required, confirmPasswordValidator]],
            logoURL: ['', CustomValidators.url]
        });

        // Update the validity of the 'passwordConfirm' field
        // when the 'password' field changes
        this.registerForm.get('password').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(() => {
                this.registerForm.get('passwordConfirm').updateValueAndValidity();
            });
    }

    register() {
        let registerValue = this.registerForm.value;
        let registerData = new Register(<Register>{
            userName: registerValue.userName,
            firstName: registerValue.firstName,
            lastName: registerValue.lastName,
            email: registerValue.email,
            password: registerValue.password,
            confirmPassword: registerValue.passwordConfirm,
            pictureUrl: registerValue.logoURL
        });
        this.service.register(registerData)
            .then(res => {
                console.log('User authenticated', res);
                this.router.navigate(['pages/auth/login-2']);
            })
            .catch(error => {

            });
    }

    /* Custom
     *Register
     * */
    //register() {
    //    debugger;
    //    let registerValue = this.registerForm.value;
    //    this.auth.auth.createUserAndRetrieveDataWithEmailAndPassword(registerValue.email, registerValue.password).then(
    //        res => {
    //            debugger;
    //            console.log(res);
    //            console.log('Account User Id: ', res.user.uid);

    //            this.auth.auth.currentUser.updateProfile({
    //                displayName: registerValue.name,
    //                photoURL: registerValue.logoURL
    //            });

    //            let userId = res.user.uid;
    //            let newUserId = this.database.database.ref('accounts').push().key;
    //            this.database.database.ref(`accounts/${newUserId}`).set({
    //                userId: res.user.uid,
    //                userName: registerValue.name,
    //            });

    //            this.router.navigate(['pages/auth/login-2']);
    //        },
    //        error => {

    //        }
    //    );
    //}

    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }
}

/**
 * Confirm password validator
 *
 * @param {AbstractControl} control
 * @returns {ValidationErrors | null}
 */
export const confirmPasswordValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {

    if (!control.parent || !control) {
        return null;
    }

    const password = control.parent.get('password');
    const passwordConfirm = control.parent.get('passwordConfirm');

    if (!password || !passwordConfirm) {
        return null;
    }

    if (passwordConfirm.value === '') {
        return null;
    }

    if (password.value === passwordConfirm.value) {
        return null;
    }

    return { 'passwordsNotMatching': true };
};
