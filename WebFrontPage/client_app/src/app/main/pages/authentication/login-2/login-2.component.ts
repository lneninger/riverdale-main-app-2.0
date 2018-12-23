import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';
/*************************Custom***********************************/
import { Router } from '@angular/router';
//import { AngularFireAuth } from '@angular/fire/auth';
//import { AngularFireDatabase } from '@angular/fire/database';
import { AuthenticationService, Register, Authenticate } from '../../../apps/@hipalanetCommons/authentication/authentication.core.module';

@Component({
    selector     : 'login-2',
    templateUrl  : './login-2.component.html',
    styleUrls    : ['./login-2.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class Login2Component implements OnInit
{
    loginForm: FormGroup;

    /**
     * Constructor
     *
     * @param {FuseConfigService} _fuseConfigService
     * @param {FormBuilder} _formBuilder
     */
    constructor(
        private _fuseConfigService: FuseConfigService
        , private _formBuilder: FormBuilder
        // Custom
        //, private auth: AngularFireAuth
        , private service: AuthenticationService
        //, private database: AngularFireDatabase
        , private router: Router
    )
    {
        // Configure the layout
        this._fuseConfigService.config = {
            layout: {
                navbar   : {
                    hidden: true
                },
                toolbar  : {
                    hidden: true
                },
                footer   : {
                    hidden: true
                },
                sidepanel: {
                    hidden: true
                }
            }
        };
    }

    login() {
        //debugger;
        let loginValue = this.loginForm.value;
        //debugger;
        let loginData = new Authenticate({ userName: loginValue.userName, password: loginValue.password });

        this.service.login(loginData)
            .then(res => {
                console.log('User authenticated', res);
                this.router.navigate(['apps/dashboards/analytics']);
            })
            .catch(error => {

            });

        //this.auth.auth.setPersistence('session')
        //    .then(res => {
        //        this.auth.auth.signInAndRetrieveDataWithEmailAndPassword(loginValue.email, loginValue.password).then(
        //            res => {
        //                console.log('User authenticated', res);
        //                this.router.navigate(['apps/dashboards/analytics']);

        //            },
        //            error => {

        //            }
        //        );
        //    });

    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void
    {
        this.loginForm = this._formBuilder.group({
            userName: ['', [Validators.required, Validators.minLength(3)]],
            password: ['', Validators.required]
        });
    }
}
