import {first} from 'rxjs/operators';
import { Component, Inject } from '@angular/core';
import { NgForm, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import * as toastr from 'toastr';
import { AccountService } from '../../main/account.service';
import { WindowRefService } from '../../../../shared/services/windowref.service';
import { AuthService } from '../../../../shared/services/auth.service';
import { ContentItemService } from '../../../../plugins/services/content-item.service';
import { Observable } from 'rxjs/internal/Observable';
import { combineLatest } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: []
})
export class LoginComponent {
  public isRequesting = false;
  public isSuccessful = false;
  public errors: string[] = new Array<string>();
  public returnUrl = '/';

  public loginForm: FormGroup = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  });

  constructor(
    @Inject(WindowRefService) private windowRefService: WindowRefService,
    private contentItemService: ContentItemService,
    private authService: AuthService,
    private accountService: AccountService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    toastr.options = {
      preventDuplicates: true,
      timeOut: 0,
      extendedTimeOut: 0,
      closeButton: true
    };

    this.route.queryParams
      .subscribe(params => {
        if (params.returnUrl) {
          this.returnUrl = params.returnUrl;
        }
      });
  }

  public async login() {
    this.isRequesting = true;
    try {
      const result = await this.accountService.login(
        this.loginForm.value['email'],
        this.loginForm.value['password']
        ).pipe(first()).toPromise();
      if (result) {
        const myResult: any = result;
        this.authService.setToken(myResult.auth_token);
        this.authService.setUserId(myResult.id);
        this.authService.setIsAdmin(myResult.is_admin);
        this.getProfile(myResult.id);
        this.router.navigate([this.returnUrl]);
      }
    } catch (errors) {
      errors[''].forEach(error => toastr.error(error));
    }
    this.isRequesting = false;
  }

  private getProfile(id: string) {
    this.contentItemService.getProfileById(id)
    .subscribe(user => {
      this.authService.setUserName(user.alias);
      this.authService.setAvatarHash(user.attribute01);
    });
  }
}