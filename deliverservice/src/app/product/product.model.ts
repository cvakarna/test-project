export class Product {
  public name: string;
  public id: string;
  public description: string;
  public imagePath: string;
  public productPrice: number;

  constructor(
    name: string,
    id: string,
    description: string,
    imagePath: string
  ) {
    this.name = name;
    this.id = id;
    this.description = description;
    this.imagePath = imagePath;
  }
}
