import { Component, OnInit } from "@angular/core";
import { ProductService } from "./product.service";
import { Product } from "./product.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-product",
  templateUrl: "./product.component.html",
  styleUrls: ["./product.component.scss"]
})
export class ProductComponent implements OnInit {
  product: Product;
  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {
    this.product = this.productService.getProduct();
  }

  onCheckOut() {
    this.router.navigate(["check-out"]);
  }
}
