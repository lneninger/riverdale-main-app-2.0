import { TestBed, getTestBed  } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { ActivatedRouteSnapshot, RouterStateSnapshot, Router, RouterModule } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { SecureHttpClientService } from '../@hipalanetCommons/authentication/securehttpclient.service';
import { AuthenticationCoreModule } from '../@hipalanetCommons/authentication/authentication.core.module';
import { CustomerService } from './customer.service';
import { NgxWebstorageModule } from 'ngx-webstorage';
import { HttpClientModule } from '@angular/common/http';
import { CustomersComponent } from './customers.component';
describe('CustomerService', () => {
    let injector: TestBed;
    let service: CustomerService;
    const activatedRouteSnapshotStub = { params: {} };
    beforeEach(() => {
    const routerStateSnapshotStub = {};
    const routerStub = {};
    TestBed.configureTestingModule({
        imports: [
            HttpClientModule
            , HttpClientTestingModule
            , AuthenticationCoreModule
            , RouterTestingModule
            , RouterModule
            , NgxWebstorageModule.forRoot()
        ],
        providers: [CustomerService,
            {
                provide: RouterStateSnapshot,
                useValue: {params: {'myId': '123'}}
              },
              {
                provide: ActivatedRouteSnapshot,
                useValue: {params: {'myId': '123'}}
              }
            ]
      });

      injector = getTestBed();
    service = injector.get(CustomerService);
  });

  it('can load instance', () => {
    expect(service).toBeTruthy();
  });


  describe('resolve',() => {
    it('makes expected calls',  async () => {
      const routerStateSnapshotStub: RouterStateSnapshot = TestBed.get(
        RouterStateSnapshot
      );
      //spyOn(service, 'getCustomer').and.returnValue(Promise.resolve(true));
      spyOn(service, 'resolve').and.callThrough();
      await service.getCustomer(1001);
      const route = injector.get(ActivatedRouteSnapshot);
      const state = injector.get(RouterStateSnapshot);
      await service.resolve(route, state);
      expect(service.getCustomer).toHaveBeenCalled();
      expect(service.resolve).toHaveBeenCalled();
    });
  });
});
