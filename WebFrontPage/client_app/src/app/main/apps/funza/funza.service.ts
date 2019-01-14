import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


/*************************Custom***********************************/
//import { AngularFireDatabase } from '@angular/fire/database';
//import { AngularFireAuth } from '@angular/fire/auth';
import { IPageQueryService } from '../@hipalanetCommons/datatable/model';
import { RolePermissionGrid } from '../role-permissions/rolepermission.core.module';
import { SecureHttpClientService } from '../@hipalanetCommons/authentication/securehttpclient.service';

@Injectable()
export class FunzaService implements IPageQueryService {
    
    /**
     * Constructor
     *
     * @param {SecureHttpClientService} http
     */
    constructor(
        public http: SecureHttpClientService
        , public router: Router
    ) {
        // Set the defaults
    }

    

    /**
     * Get entity
     *
     * @returns {Promise<any>}
     */
    authenticate(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.http.post(`${environment.appApi.apiBaseUrl}funza/authenticate`, null).subscribe(response => {
                debugger;
                resolve(response);
            });
        });
    }

    
}