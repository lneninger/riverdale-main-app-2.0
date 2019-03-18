import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { EnvironmentResolveService } from '../@resolveServices/resolve.module';

@Component({
    selector: 'environment-info',
    templateUrl: 'environmentinfo.component.html',
    styleUrls: []
})
export class EnvironmentInfoComponent implements OnInit {
    constructor(private route: ActivatedRoute, private router: Router, private matDialog: MatDialog) {}

    ngOnInit(): void {
        this.initializeQueryListeners();
    }

    initializeQueryListeners(): void {
        this.route.queryParams.subscribe(params => {
            //debugger
            if (params['showenvinfo'] === 'true') {
                this.showDialog();
            }
        });
    }
    showDialog(): void {
        const dialogRef = this.matDialog.open(
            EnvironmentInfoModalDialogComponent,
            {
                width: '60%',
                data: {}
            }
        );

        dialogRef.afterClosed().subscribe(() => {
            this.router.navigate([], {queryParams: {showevninfo: null}, queryParamsHandling: 'merge'});
        });
    }
}

@Component({
    selector: 'environment-info-dialog',
    templateUrl: 'environmentinfomodaldialog.component.html'
})
export class EnvironmentInfoModalDialogComponent {

    environment$ = this.environmentResolveService.onList;

    constructor(
        public environmentResolveService: EnvironmentResolveService,
        public dialogRef: MatDialogRef<EnvironmentInfoModalDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {
        //debugger;
        environmentResolveService.noDependencyResolve().subscribe();
    }

    close(): void {
        this.dialogRef.close();
    }
}
