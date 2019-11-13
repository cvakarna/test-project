import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { AuthenticationService } from "../authentication.service";
import { ActivatedRoute, Router, NavigationEnd } from "@angular/router";
import { filter, pairwise } from "rxjs/operators";
import { User } from "../user.model";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  previousUrl;

  constructor(
    private authService: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.initLoginForm();
    this.previousUrl = this.route.snapshot.queryParams["returnUrl"] || "/";
    console.log(this.previousUrl);
  }

  initLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.email, Validators.required]),
      password: new FormControl("", Validators.required)
    });
  }

  onSubmit() {
    console.log("loginForm", this.loginForm.value);

    this.authService.loginUser(this.loginForm.value).subscribe(res => {
      console.log(res);
      if (res != null) {
        this.authService.user = new User(
          res.Name,
          res.Id,
          res.Golden,
          res.Coupan,
          res.email
        );
        this.authService.isUserLoggedIn = !this.authService.isUserLoggedIn;
        this.router.navigate([this.previousUrl]);
      }
    });
  }
}
