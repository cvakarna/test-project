import { Injectable } from "@angular/core";
import { Product } from "./product.model";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Constants } from "../appconstants/constants";

@Injectable({
  providedIn: "root"
})
export class ProductService {
  product: Product = new Product(
    "Clay-Brick",
    "5923ba32-040d-45d6-9421-e29b4eeaa35c",
    "Used in foundation or above-surface level brickwork",
    "https://images.homedepot-static.com/productImages/eafe53a8-213c-472e-a25a-f83430675680/svn/bricks-20050941-64_1000.jpg"
  );
  constructor(private http: HttpClient) {}

  getProduct() {
    return Object.assign({}, this.product);
  }

  getProductCost(distence: number, userId: string): Observable<any> {
    return this.http.get(
      Constants.baseUrl +
        "Orders/order-cost?customerId=" +
        userId +
        "&distence=" +
        distence
    );
  }

  onPlaceOrder(orderData) {
    return this.http.post(Constants.baseUrl + "Orders/place-order", orderData);
  }
}
