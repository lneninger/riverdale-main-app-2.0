import {
    Directive,
    AfterViewInit,
    OnInit,
    TemplateRef,
    ViewContainerRef,
    Input,
    OnDestroy,
    ChangeDetectorRef
} from "@angular/core";
import { AuthenticationService } from "./authentication.service";
import { Subscription } from "rxjs/Subscription";
import { INavigationAccessRights } from "./authentication.model";

@Directive({
    selector: "[access],[accessTest]"
})
export class AuthorizationAccessDirective
    implements OnInit /*, AfterViewInit*/, OnDestroy {
    private hasView = false;
    private authPermissionsSubscription: Subscription;

    _name: string;
    @Input("accessName") set name(name: string) {
        this._name = name;
    }

    _permissions: string[];
    @Input("access") set permissions(permissions: string[]) {
        this._permissions = permissions;
        this.execute();
    }

    _reverse = false;
    @Input("accessReverse") set reverse(reverse: boolean) {
        this._reverse = reverse;
        this.execute();
    }

    _roles: string[];
    @Input("accessRoles") set roles(roles: string[]) {
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
        private _changeDetectorRef: ChangeDetectorRef,
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private authenticationService: AuthenticationService
    ) {
        // console.log('directive authorization call');
    }

    ngOnInit(): void {
        this.authPermissionsSubscription = this.authenticationService.onChangedUserInfo.subscribe(
            o => {
                console.log(`Last user info: `, o);
                this.execute();
            }
        );
    }

    ngOnDestroy(): void {
        if (this.authPermissionsSubscription) {
            this.authPermissionsSubscription.unsubscribe();
        }
    }

    execute(): void {
        this.executeInternal();
        this._changeDetectorRef.markForCheck();
    }

    executeInternal(): void {
        // debugger;
        const requestedRights = <INavigationAccessRights>{
            permissions: this._permissions,
            roles: this._roles,
            accesExtraFilter: this.accessExtraFilter
        };
        let accessToView = this.authenticationService.validateNavigationPermissions(
            requestedRights
        );

        if (this._reverse) {
            accessToView = !accessToView;
        }

        if (accessToView && !this.hasView) {
            this.viewContainer.createEmbeddedView(this.templateRef);
            this.hasView = true;
            console.log(
                `Show element for rights: `,
                this._name,
                this._permissions && this._permissions[0]
            );
        } else if (!accessToView && this.hasView) {
            console.log(
                `Hide element for rights: `,
                this._name,
                this._permissions && this._permissions[0]
            );
            this.viewContainer.clear();
            this.hasView = false;
        } else if (!accessToView && !this.hasView) {
            console.log(`Doing nothing for: `, this._name);
        } else if (accessToView && this.hasView) {
            console.log(`Doing nothing for: `, this._name);
        }
    }
}
