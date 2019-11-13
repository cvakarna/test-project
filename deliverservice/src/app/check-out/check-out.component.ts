import { Component, OnInit } from "@angular/core";
import { ɵINTERNAL_BROWSER_DYNAMIC_PLATFORM_PROVIDERS } from "@angular/platform-browser-dynamic";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { ProductService } from "../product/product.service";
import { Product } from "../product/product.model";
import { AuthenticationService } from "../auth/authentication.service";
import { DistenceCalculator } from "../appconstants/distence.calculator";
import { GuildGenerator } from "../appconstants/guid.generator";
import { Router } from "@angular/router";

@Component({
  selector: "app-check-out",
  templateUrl: "./check-out.component.html",
  styleUrls: ["./check-out.component.scss"]
})
export class CheckOutComponent implements OnInit {
  addressForm: FormGroup;
  product: Product;

  constructor(
    private productService: ProductService,
    private authService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit() {
    let self = this;
    this.initForm();
    this.product = this.productService.getProduct();
    this.product.productPrice = 999;
    this.addressForm.controls["city"].valueChanges.subscribe(value => {
      console.log(self.addressForm);
      console.log(value);
      self.getProductPrice();
    });
  }

  initForm() {
    this.addressForm = new FormGroup({
      name: new FormControl("", Validators.required),
      pincode: new FormControl("", Validators.required),
      city: new FormControl("", { updateOn: "blur" }),
      state: new FormControl("", Validators.required),
      landmark: new FormControl("", Validators.required)
    });
  }

  getProductPrice() {
    let dietnceinKm = DistenceCalculator.getDistence();
    console.log("distence", dietnceinKm);
    let self = this;
    this.productService
      .getProductCost(dietnceinKm, this.authService.user.id)
      .subscribe(res => {
        if (res != null) {
          self.product.productPrice = res;
        }
        console.log("product cost", res);
      });
  }
  onSubmit() {
    let self = this;
    console.log(this.addressForm);
    let orderId = GuildGenerator.generateGuid();
    let value = this.addressForm.value;
    let orderObj = {
      OrderId: orderId,
      TotalPrice: this.product.productPrice,
      Name: value.name,
      PinCode: value.pincode,
      City: value.pincode,
      State: value.state,
      Landmark: value.landmark,
      OrderDate: new Date(),
      CustomerId: this.authService.user.id
    };
    this.productService.onPlaceOrder(orderObj).subscribe(
      res => {
        console.log(res);
        //this.router.navigate(["order-success"]);
        self.router.navigate(["order-success"]);
      },
      error => {
        console.log(error);
      }
    );
  }
}
