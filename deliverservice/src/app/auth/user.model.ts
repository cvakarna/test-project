export class User {
  name: string;
  id: string;
  golden: boolean;
  coupan: boolean;
  email: string;
  constructor(
    name: string,
    id: string,
    golden: boolean,
    coupan: boolean,
    email: string
  ) {
    this.name = name;
    this.id = id;
    this.golden = golden;
    this.coupan = coupan;
    this.email = email;
  }
}
