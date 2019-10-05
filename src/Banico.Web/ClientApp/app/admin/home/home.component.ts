import { Component } from "@angular/core";
import { ConfigsService } from "../config/services/configs.service";
import { AuthService } from '../../shared/services/auth.service';

@Component({
    selector: 'app-admin-home',
    templateUrl: './home.component.html',
    providers: []
})
export class AdminHomeComponent {
    isInitialized: boolean;
    configsAllowed: boolean = false;
    sectionsAllowed: boolean = false;
    rolesAllowed: boolean = false;
    usersAllowed: boolean = false;

    constructor(
        private configsService: ConfigsService,
        private authService: AuthService
        ) {
    }

    public ngOnInit() {
        this.configsService.initialized()
            .subscribe(result => this.isInitialized = result);
        this.setPermissions();
    }

    private setPermissions() {
        this.authService.canAccess('admin/configs', '', false)
            .subscribe(result => this.configsAllowed = result);
            this.authService.canAccess('admin/sections', '', false)
            .subscribe(result => this.sectionsAllowed = result);
            this.authService.canAccess('admin/roles', '', false)
            .subscribe(result => this.rolesAllowed = result);
            this.authService.canAccess('admin/users', '', false)
            .subscribe(result => this.usersAllowed = result);
    }
}