import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./auth/login/login.component";
import { LogoutComponent } from "./auth/logout/logout.component";
import { ProductComponent } from "./product/product.component";
import { CheckOutComponent } from "./check-out/check-out.component";
import { AuthgaurdService } from "./authgaurd/authgaurd.service";
import { SuccessMessageComponent } from "./success-message/success-message.component";

const routes: Routes = [
  {
    path: "login",
    component: LoginComponent
  },

  {
    path: "logout",
    component: LogoutComponent
  },
  {
    path: "products",
    component: ProductComponent
  },
  {
    path: "",
    redirectTo: "products",
    pathMatch: "full"
  },
  {
    path: "check-out",
    component: CheckOutComponent,
    canActivate: [AuthgaurdService]
  },
  {
    path: "order-success",
    component: SuccessMessageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
