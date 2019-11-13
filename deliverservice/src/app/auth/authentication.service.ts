import { Injectable } from "@angular/core";
import { Constants } from "../appconstants/constants";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "./user.model";

@Injectable({
  providedIn: "root"
})
export class AuthenticationService {
  isUserLoggedIn: boolean = false;
  userName: string;
  baseUrl = Constants.baseUrl;
  user: User;
  constructor(private http: HttpClient) {}

  loginUser(userLogin): Observable<any> {
    return this.http.post(
      this.baseUrl + "Authentication/validate-user",
      userLogin
    );
  }
  registerUser(userInfo): boolean {
    console.log("User Registered....");
    return true;
  }
}
