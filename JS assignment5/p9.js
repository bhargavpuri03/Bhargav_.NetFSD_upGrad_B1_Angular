class Product {
    constructor({ name, price, category = "General" }) {
        this.name = name;
        this.price = price;
        this.category = category;
    }

    show = () => {
        console.log(`${this.name} costs ${this.price} in ${this.category}`);
    };
}

let data = { name: "Laptop", price: 50000 };
let p = new Product(data);
p.show();