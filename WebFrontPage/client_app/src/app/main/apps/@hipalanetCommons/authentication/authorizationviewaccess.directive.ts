import { Directive, AfterViewInit, OnInit, EventEmitter, TemplateRef, ViewContainerRef, Input, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AuthenticationService } from './authentication.service';
import { Subscription } from 'rxjs/Subscription';
import { INavigationAccessRights } from './authentication.model';

@Directive({
    selector: '[access],[accessTest]'
})
export class AuthorizationAccessDirective implements OnInit, AfterViewInit, OnDestroy {
    private hasView = false;
    private authPermissionsSubscription: Subscription;

    _permissions: string[];
    @Input('access') set permissions(permissions: string[]) {
        this._permissions = permissions;
    }

    _reverse: boolean = false;
    @Input('accessReverse') set reverse(reverse: boolean) {
        this._reverse = reverse;
    }

    _roles: string[];
    @Input() set roles(roles: string[]) {
        this._roles = roles;
    }

    _groups: string[];
    @Input() set groups(groups: string[]) {
        this._groups = groups;
    }

    _accessExtraFilter: (userInfo) => boolean;
    @Input() set accessExtraFilter(accessExtraFilter: (userInfo) => boolean) {
        this._accessExtraFilter = accessExtraFilter;
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


    ngAfterViewInit() {
        setTimeout(() => {
            this.execute();
        });
    }

    ngOnDestroy() {
        if (this.authPermissionsSubscription) {
            this.authPermissionsSubscription.unsubscribe();
        }
    }

    execute() {
        //let permissions: string[] = [];
        //let roles: string[] = [];

        //if (this._permissions) {
        //    permissions = this._permissions;
        //}

        //if (this._roles) {
        //    roles = this._roles;
        //}

        //let resultPermissions = permissions.length > 0 && this.authTrackerService.userHasPermissions(permissions);
        //let resultRoles = roles.length > 0 && this.authTrackerService.userHasRoles(roles);


        //let accessToView = resultPermissions || resultRoles;

        //if (accessToView && this.accessExtraFilter != null) {
        //    accessToView = this.accessExtraFilter(this.authTrackerService.userInfo);
        //}

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