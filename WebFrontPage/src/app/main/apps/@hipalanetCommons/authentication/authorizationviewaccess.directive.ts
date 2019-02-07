import { Directive, AfterViewInit, OnInit, TemplateRef, ViewContainerRef, Input, OnDestroy } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Subscription } from 'rxjs/Subscription';
import { INavigationAccessRights } from './authentication.model';

@Directive({
    selector: '[access],[accessTest]'
})
export class AuthorizationAccessDirective implements OnInit/*, AfterViewInit*/, OnDestroy {
    private hasView = false;
    private authPermissionsSubscription: Subscription;

    _permissions: string[];
    @Input('access') set permissions(permissions: string[]) {
        this._permissions = permissions;
        this.execute();
    }

    _reverse: boolean = false;
    @Input('accessReverse') set reverse(reverse: boolean) {
        this._reverse = reverse;
        this.execute();
    }

    _roles: string[];
    @Input('accessRoles') set roles(roles: string[]) {
        this._roles = roles;
        this.execute();
    }

    _groups: string[];
    @Input() set groups(groups: string[]) {
        this._groups = groups;
        this.execute();
    }

    _accessExtraFilter: (userInfo) => boolean;
    @Input() set accessExtraFilter(accessExtraFilter: (userInfo) => boolean) {
        this._accessExtraFilter = accessExtraFilter;
        this.execute();
    }

    constructor(
        private templateRef: TemplateRef<any>
        , private viewContainer: ViewContainerRef
        , private authenticationService: AuthenticationService
    ) {
        //console.log('directive authorization call');
    }

    ngOnInit() {
        this.authPermissionsSubscription = this.authenticationService.onChangedUserInfo.subscribe(o => {
            this.execute();
        });
    }


    //ngAfterViewInit() {
    //    setTimeout(() => {
    //        this.execute();
    //    });
    //}

    ngOnDestroy() {
        if (this.authPermissionsSubscription) {
            this.authPermissionsSubscription.unsubscribe();
        }
    }

    execute() {
        //debugger;
        let requestedRights = <INavigationAccessRights>{ permissions: this._permissions, roles: this._roles, accesExtraFilter: this.accessExtraFilter };
        let accessToView = this.authenticationService.validateNavigationPermissions(requestedRights);

        if (this._reverse) {
            accessToView = !accessToView;
        }

        if (accessToView && !this.hasView) {
            this.viewContainer.createEmbeddedView(this.templateRef);
            this.hasView = true;
        } else if (!accessToView && this.hasView) {
            this.viewContainer.clear();
            this.hasView = false;
        }
    }
}
