import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AdminHomeComponent } from "./home/home.component";
import { AdminSectionsSectionComponent } from "./sections/components/section/section.component";
import { AdminSectionsSectionItemComponent } from "./sections/components/section-item/section-item.component";
import { AdminRolesFormComponent } from "./roles/components/form/form.component";
import { AdminRolesHomeComponent } from "./roles/components/home/home.component";
import { AdminUsersFormComponent } from "./users/components/form/form.component";
import { AdminUsersListComponent } from "./users/components/list/list.component";
import { AdminConfigFormComponent } from "./config/components/form/form.component";
import { AdminConfigListComponent } from "./config/components/list/list.component";
import { AuthGuard } from "../shared/auth/auth.guard";

const ADMIN_ROUTES: Routes = [
  {
    path: "sections/section-item/:section",
    component: AdminSectionsSectionItemComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/sections/manage" }
  },
  {
    path: "sections/:path",
    component: AdminSectionsSectionItemComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/sections/manage" }
  },
  {
    path: "sections",
    component: AdminSectionsSectionComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/sections/manage" }
  },
  {
    path: "roles/add",
    component: AdminRolesFormComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/sections/manage" }
  },
  {
    path: "roles/edit/:id",
    component: AdminRolesFormComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/roles/manage" }
  },
  {
    path: "roles",
    component: AdminRolesHomeComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/roles/manage" }
  },
  {
    path: "users/add",
    component: AdminUsersFormComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/users/manage" }
  },
  {
    path: "users/edit/:id",
    component: AdminUsersFormComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/users/manage" }
  },
  {
    path: "users",
    component: AdminUsersListComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/users/manage" }
  },
  {
    path: "configs/add",
    component: AdminConfigFormComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/configs/manage" }
  },
  {
    path: "configs/edit/:id",
    component: AdminConfigFormComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/configs/manage" }
  },
  {
    path: "configs",
    component: AdminConfigListComponent,
    canActivate: [AuthGuard],
    data: { module: "admin/configs/manage" }
  },
  {
    path: "",
    component: AdminHomeComponent,
    canActivate: [AuthGuard],
    data: { module: "admin" }
  }
];

@NgModule({
  imports: [RouterModule.forChild(ADMIN_ROUTES)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}
