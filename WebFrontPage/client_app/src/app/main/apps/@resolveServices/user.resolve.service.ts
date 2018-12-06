import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { environment } from 'environments/environment';



@Injectable()
export class UserResolveService implements Resolve<any> {
    list: any[];
    endpoint = `${environment.appApi.apiBaseUrl}masters/user`;

    constructor(private http: HttpClient) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.list != null) {
            return Promise.resolve(this.list);
        }
        else {
            return new Promise((resolve, reject) => {
                this.http.get(this.endpoint).toPromise()
                    .then(res => {
                        this.list = <any[]>res;
                        resolve(res);
                    })
                    .catch(error => reject(error));
            });
        }
    }


}